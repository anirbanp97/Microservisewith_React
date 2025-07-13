CREATE PROCEDURE usp_UpdateInventoryItem
    @Id INT,
    @ProductId INT,
    @Quantity INT,
    @LastUpdated DATETIME
AS
BEGIN
    UPDATE InventoryItems
    SET ProductId = @ProductId,
        Quantity = @Quantity,
        LastUpdated = @LastUpdated
    WHERE Id = @Id
END
