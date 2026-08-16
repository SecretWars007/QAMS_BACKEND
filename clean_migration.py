import re
import sys

filepath = r"src\QAMS.Infrastructure\Migrations\20260805001721_AddTestPlanCatalogs.cs"
with open(filepath, "r", encoding="utf-8") as f:
    content = f.read()

# Regular expression to match migrationBuilder.InsertData, UpdateData, DeleteData blocks
# It matches 'migrationBuilder.<Method>(' and non-greedily consumes until '});'
pattern = r"\s*migrationBuilder\.(InsertData|UpdateData|DeleteData)\(.*?\}\);"
new_content = re.sub(pattern, "", content, flags=re.DOTALL)

with open(filepath, "w", encoding="utf-8") as f:
    f.write(new_content)
print("Cleaned migration file.")
