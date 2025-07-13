CREATE PROCEDURE usp_GetAllInventoryItems
AS
BEGIN
    SELECT Id, ProductId, Quantity, LastUpdated
    FROM InventoryItems
END
