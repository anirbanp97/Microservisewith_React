CREATE PROCEDURE usp_AddOrder
    @UserId INT,
    @OrderDate DATETIME,
    @TotalAmount DECIMAL(10,2),
    @Status NVARCHAR(50)
AS
BEGIN
    INSERT INTO Orders (UserId, OrderDate, TotalAmount, Status)
    VALUES (@UserId, @OrderDate, @TotalAmount, @Status)
END
