SELECT r.name as role_name, p.code as permission_code 
FROM roles r 
JOIN role_permissions rp ON rp.role_id = r.id 
JOIN permissions p ON p.id = rp.permission_id 
WHERE r.name ILIKE '%lead%' OR r.name ILIKE '%lider%' OR r.name ILIKE '%líder%'
ORDER BY r.name, p.code;

SELECT name FROM roles ORDER BY name;
