CREATE PROCEDURE usp_AddProduct
    @Name NVARCHAR(100),
    @Price DECIMAL(18,2),
    @Category NVARCHAR(50),
    @Description NVARCHAR(500),
    @Stock INT
AS
BEGIN
    INSERT INTO Products (Name, Price, Category, Description, Stock)
    VALUES (@Name, @Price, @Category, @Description, @Stock);
END
