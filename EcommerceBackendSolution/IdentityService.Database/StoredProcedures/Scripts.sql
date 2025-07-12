
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100) NOT NULL,
    PasswordHash NVARCHAR(200) NOT NULL,
    Role NVARCHAR(50) NOT NULL DEFAULT 'User'
);
GO


CREATE PROCEDURE sp_RegisterUser
    @Username NVARCHAR(100),
    @PasswordHash NVARCHAR(200)
AS
BEGIN
    INSERT INTO Users (Username, PasswordHash, Role)
    VALUES (@Username, @PasswordHash, 'User');
END;
GO


CREATE PROCEDURE sp_ValidateUser
    @Username NVARCHAR(100),
    @PasswordHash NVARCHAR(200)
AS
BEGIN
    SELECT Role FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash;
END;
GO
