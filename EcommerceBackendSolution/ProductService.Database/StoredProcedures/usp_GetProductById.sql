CREATE PROCEDURE usp_GetProductById
    @Id INT
AS
BEGIN
    SELECT * FROM Products WHERE Id = @Id;
END
