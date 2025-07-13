CREATE PROCEDURE usp_AddInventoryItem
    @ProductId INT,
    @Quantity INT,
    @LastUpdated DATETIME
AS
BEGIN
    INSERT INTO InventoryItems (ProductId, Quantity, LastUpdated)
    VALUES (@ProductId, @Quantity, @LastUpdated)
END
