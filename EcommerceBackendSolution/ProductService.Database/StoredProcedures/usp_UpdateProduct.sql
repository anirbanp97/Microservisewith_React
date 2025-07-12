CREATE PROCEDURE usp_UpdateProduct
    @Id INT,
    @Name NVARCHAR(100),
    @Price DECIMAL(18,2),
    @Category NVARCHAR(50),
    @Description NVARCHAR(500),
    @Stock INT
AS
BEGIN
    UPDATE Products
    SET Name = @Name,
        Price = @Price,
        Category = @Category,
        Description = @Description,
        Stock = @Stock
    WHERE Id = @Id;
END
