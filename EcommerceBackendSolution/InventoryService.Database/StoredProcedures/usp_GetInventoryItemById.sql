CREATE PROCEDURE usp_GetInventoryItemById
    @Id INT
AS
BEGIN
    SELECT Id, ProductId, Quantity, LastUpdated
    FROM InventoryItems
    WHERE Id = @Id
END
