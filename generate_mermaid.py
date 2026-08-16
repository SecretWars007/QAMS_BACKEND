import subprocess
import json

# Get all tables
tables_result = subprocess.run(
    ["docker", "exec", "qams-postgres", "psql", "-U", "postgres", "-d", "qams_db", "-t", "-c", 
     "SELECT table_name FROM information_schema.tables WHERE table_schema='public' AND table_type='BASE TABLE';"],
    capture_output=True, text=True
)

tables = [t.strip() for t in tables_result.stdout.split('\n') if t.strip() and t.strip() != '__EFMigrationsHistory']

mermaid = "erDiagram\n"

for table in tables:
    # Get columns
    cols_result = subprocess.run(
        ["docker", "exec", "qams-postgres", "psql", "-U", "postgres", "-d", "qams_db", "-t", "-c", 
         f"SELECT column_name, data_type FROM information_schema.columns WHERE table_schema='public' AND table_name='{table}';"],
        capture_output=True, text=True
    )
    columns = []
    for line in cols_result.stdout.split('\n'):
        if line.strip():
            parts = line.split('|')
            if len(parts) == 2:
                col_name = parts[0].strip().replace(" ", "")
                data_type = parts[1].strip().split(' ')[0] # simplify data type
                columns.append(f"    {data_type} {col_name}")
    
    mermaid += f"  {table} {{\n"
    for col in columns:
        mermaid += f"{col}\n"
    mermaid += "  }\n\n"

# Get foreign keys
fk_query = """
SELECT
    tc.table_name, kcu.column_name,
    ccu.table_name AS foreign_table_name,
    ccu.column_name AS foreign_column_name
FROM
    information_schema.table_constraints AS tc
    JOIN information_schema.key_column_usage AS kcu
      ON tc.constraint_name = kcu.constraint_name
      AND tc.table_schema = kcu.table_schema
    JOIN information_schema.constraint_column_usage AS ccu
      ON ccu.constraint_name = tc.constraint_name
      AND ccu.table_schema = tc.table_schema
WHERE tc.constraint_type = 'FOREIGN KEY';
"""
with open("c:\\diplomado\\QAMS\\fk_query.sql", "w", encoding="utf-8") as f:
    f.write(fk_query)

subprocess.run(["docker", "cp", "c:\\diplomado\\QAMS\\fk_query.sql", "qams-postgres:/fk_query.sql"])
fk_result = subprocess.run(
    ["docker", "exec", "qams-postgres", "psql", "-U", "postgres", "-d", "qams_db", "-t", "-f", "/fk_query.sql"],
    capture_output=True, text=True
)

for line in fk_result.stdout.split('\n'):
    if line.strip():
        parts = line.split('|')
        if len(parts) == 4:
            table_name = parts[0].strip()
            col_name = parts[1].strip()
            foreign_table = parts[2].strip()
            foreign_col = parts[3].strip()
            mermaid += f"  {table_name} }}o--|| {foreign_table} : \"{col_name} -> {foreign_col}\"\n"

with open("c:\\diplomado\\QAMS\\mermaid.txt", "w", encoding="utf-8") as f:
    f.write(mermaid)
print("Mermaid diagram generated in mermaid.txt")
