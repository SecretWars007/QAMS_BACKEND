-- ============================================================
-- Migración: SUT Global (de relación SUT→Proyecto a Proyecto→SUT)
-- Fecha: 2026-08-01
-- ============================================================

-- 1. Convertir systems_under_test a tabla global (quitar NOT NULL de project_id y luego remover FK)
--    Primero guardamos los datos existentes para migrarlos

-- Crear tabla temporal con SUTs únicos por nombre (para evitar duplicados)
CREATE TEMP TABLE sut_migration AS
SELECT DISTINCT ON (name) 
    id,
    name,
    description,
    version,
    environment,
    base_url,
    is_active,
    is_deleted,
    deleted_at,
    deleted_by_user_id,
    created_at,
    created_by_user_id,
    updated_at,
    updated_by_user_id,
    executable_path,
    platform_type_id,
    process_name,
    project_id as original_project_id
FROM systems_under_test
ORDER BY name, created_at;

-- 2. Agregar columna system_under_test_id a projects (nullable)
ALTER TABLE projects ADD COLUMN IF NOT EXISTS system_under_test_id UUID;

-- 3. Hacer project_id nullable en systems_under_test (transición)
ALTER TABLE systems_under_test ALTER COLUMN project_id DROP NOT NULL;

-- 4. Asignar el SUT al proyecto correspondiente (basado en los datos existentes)
UPDATE projects p
SET system_under_test_id = sm.id
FROM sut_migration sm
WHERE sm.original_project_id = p.id;

-- 5. Eliminar el FK antiguo de systems_under_test → projects
ALTER TABLE systems_under_test DROP CONSTRAINT IF EXISTS "FK_systems_under_test_projects_project_id";

-- 6. Eliminar el índice antiguo
DROP INDEX IF EXISTS "IX_systems_under_test_project_id";

-- 7. Eliminar la columna project_id de systems_under_test
ALTER TABLE systems_under_test DROP COLUMN IF EXISTS project_id;

-- 8. Agregar FK de projects → systems_under_test
ALTER TABLE projects 
    ADD CONSTRAINT "FK_projects_systems_under_test_system_under_test_id" 
    FOREIGN KEY (system_under_test_id) 
    REFERENCES systems_under_test(id) 
    ON DELETE RESTRICT;

-- 9. Crear índice para la nueva FK
CREATE INDEX IF NOT EXISTS "IX_projects_system_under_test_id" ON projects(system_under_test_id);

-- 10. Verificar resultado
SELECT 
    'systems_under_test rows' as tabla, COUNT(*) as cantidad FROM systems_under_test
UNION ALL
SELECT 
    'projects with SUT' as tabla, COUNT(*) FROM projects WHERE system_under_test_id IS NOT NULL
UNION ALL
SELECT 
    'projects without SUT' as tabla, COUNT(*) FROM projects WHERE system_under_test_id IS NULL;
