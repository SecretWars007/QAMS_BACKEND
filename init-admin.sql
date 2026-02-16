-- Initialize admin user with correct password hash for Admin123!
-- Using $2b$ prefix as verified to work with the current BCrypt implementation

UPDATE users 
SET password_hash = '$2b$12$0jdJPZWmFkqBX5PmpGsjaeXoZqGvvD1fUOifS6Foj9guzZVPZzo.C'
WHERE username = 'admin';
