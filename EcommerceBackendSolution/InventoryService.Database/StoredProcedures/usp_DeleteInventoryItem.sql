CREATE PROCEDURE usp_DeleteInventoryItem
    @Id INT
AS
BEGIN
    DELETE FROM InventoryItems
    WHERE Id = @Id
END
