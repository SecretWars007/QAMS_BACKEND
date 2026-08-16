-- Agregar permiso PROJECTS_DELETE al rol Líder de Pruebas (Lead)
INSERT INTO role_permissions (role_id, permission_id, assigned_at, "CreatedAt", "IsDeleted")
VALUES (
  '33333333-3333-3333-3333-333333333333',
  '4a4f5250-4345-5354-5f44-454c45544500',
  NOW(),
  NOW(),
  false
)
ON CONFLICT (role_id, permission_id) DO NOTHING;

-- Verificar
SELECT r.name, p.code
FROM roles r
JOIN role_permissions rp ON rp.role_id = r.id
JOIN permissions p ON p.id = rp.permission_id
WHERE r.id = '33333333-3333-3333-3333-333333333333' AND p.code LIKE 'PROJECTS_%'
ORDER BY p.code;
