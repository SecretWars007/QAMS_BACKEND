
INSERT INTO test_strategies ("Id", "Code", "Name", "SortOrder", "IsDeleted", "CreatedAt", "IsActive") VALUES
(1, 'FUNCIONAL', 'Pruebas Funcionales', 1, false, NOW(), true),
(2, 'REGRESION', 'Pruebas de Regresión', 2, false, NOW(), true),
(3, 'SEGURIDAD', 'Pruebas de Seguridad', 3, false, NOW(), true),
(4, 'AUTOMATIZADA', 'Pruebas Automatizadas', 4, false, NOW(), true),
(5, 'RENDIMIENTO', 'Pruebas de Rendimiento / Carga', 5, false, NOW(), true),
(6, 'EXPLORATORIA', 'Pruebas Exploratorias', 6, false, NOW(), true),
(7, 'UAT', 'Pruebas de Aceptación (UAT)', 7, false, NOW(), true),
(8, 'INTEGRACION', 'Pruebas de Integración', 8, false, NOW(), true),
(9, 'MIXTA', 'Estrategia Mixta', 9, false, NOW(), true)
ON CONFLICT ("Code") DO NOTHING;

INSERT INTO risk_levels ("Id", "Code", "Name", "SortOrder", "IsDeleted", "CreatedAt", "IsActive") VALUES
(1, 'NO_RISK', 'Sin Riesgo Identificado', 1, false, NOW(), true),
(2, 'LOW', 'Riesgo Bajo', 2, false, NOW(), true),
(3, 'MEDIUM', 'Riesgo Medio', 3, false, NOW(), true),
(4, 'HIGH', 'Riesgo Alto', 4, false, NOW(), true),
(5, 'CRITICAL', 'Riesgo Crítico / Bloqueante', 5, false, NOW(), true)
ON CONFLICT ("Code") DO NOTHING;

INSERT INTO test_plan_environments ("Id", "Code", "Name", "SortOrder", "IsDeleted", "CreatedAt", "IsActive") VALUES
(1, 'LOCAL', 'Entorno Local (Development)', 1, false, NOW(), true),
(2, 'QA', 'Entorno QA / Testing', 2, false, NOW(), true),
(3, 'STAGING', 'Entorno Staging / Pre-producción', 3, false, NOW(), true),
(4, 'PROD', 'Entorno de Producción (Smoke Testing)', 4, false, NOW(), true),
(5, 'MULTIPLATFORM', 'Entorno Multi-plataforma (Web + Mobile)', 5, false, NOW(), true),
(6, 'CLOUD', 'Ambiente Cloud (AWS / GCP / Azure)', 6, false, NOW(), true)
ON CONFLICT ("Code") DO NOTHING;
