-- Ver estructura de role_permissions
\d role_permissions

-- Ver permisos disponibles
SELECT id, code FROM permissions WHERE code = 'PROJECTS_DELETE';

-- Ver id del rol Lead
SELECT id, name FROM roles WHERE name ILIKE '%l%der%';
