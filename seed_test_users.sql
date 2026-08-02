DO $$ 
DECLARE 
    tester3_id UUID := gen_random_uuid();
    tester4_id UUID := gen_random_uuid();
    dev3_id UUID := gen_random_uuid();
    dev4_id UUID := gen_random_uuid();
    hash VARCHAR := '$2a$12$0jdJPZWmFkqBX5PmpGsjaeXoZqGvvD1fUOifS6Foj9guzZVPZzo.C';
    tester_role_id UUID := '22222222-2222-2222-2222-222222222222';
    dev_role_id UUID := '44444444-4444-4444-4444-444444444444';
BEGIN
    INSERT INTO users (id, username, full_name, email, is_active, password_hash, created_at)
    VALUES 
        (tester3_id, 'tester3', 'Tester Three', 'tester3@qams.com', true, hash, NOW()),
        (tester4_id, 'tester4', 'Tester Four', 'tester4@qams.com', true, hash, NOW()),
        (dev3_id, 'dev3', 'Developer Three', 'dev3@qams.com', true, hash, NOW()),
        (dev4_id, 'dev4', 'Developer Four', 'dev4@qams.com', true, hash, NOW());

    INSERT INTO user_roles (user_id, role_id, assigned_at)
    VALUES 
        (tester3_id, tester_role_id, NOW()),
        (tester4_id, tester_role_id, NOW()),
        (dev3_id, dev_role_id, NOW()),
        (dev4_id, dev_role_id, NOW());
END $$;
