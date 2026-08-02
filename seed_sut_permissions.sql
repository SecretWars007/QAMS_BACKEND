INSERT INTO permissions (id, code, description, module, created_at, "Name", "IsDeleted")
VALUES 
('5355545f-5649-4557-0000-000000000000', 'SUT_VIEW', 'Ver sistemas bajo prueba', 'SUT', NOW(), 'Ver SUT', false),
('5355545f-4352-4541-5445-000000000000', 'SUT_CREATE', 'Crear sistemas bajo prueba', 'SUT', NOW(), 'Crear SUT', false),
('5355545f-5550-4441-5445-000000000000', 'SUT_UPDATE', 'Actualizar sistemas bajo prueba', 'SUT', NOW(), 'Actualizar SUT', false),
('5355545f-4445-4c45-5445-000000000000', 'SUT_DELETE', 'Eliminar sistemas bajo prueba', 'SUT', NOW(), 'Eliminar SUT', false)
ON CONFLICT (id) DO NOTHING;

INSERT INTO role_permissions (role_id, permission_id, assigned_at)
SELECT r.id, p.id, NOW()
FROM roles r
CROSS JOIN permissions p
WHERE p.code IN ('SUT_VIEW', 'SUT_CREATE', 'SUT_UPDATE', 'SUT_DELETE')
ON CONFLICT DO NOTHING;
