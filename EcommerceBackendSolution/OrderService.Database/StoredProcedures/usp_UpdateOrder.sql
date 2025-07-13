CREATE PROCEDURE usp_UpdateOrder
    @Id INT,
    @UserId INT,
    @OrderDate DATETIME,
    @TotalAmount DECIMAL(10,2),
    @Status NVARCHAR(50)
AS
BEGIN
    UPDATE Orders
    SET UserId = @UserId,
        OrderDate = @OrderDate,
        TotalAmount = @TotalAmount,
        Status = @Status
    WHERE Id = @Id
END
