-- =====================================
-- 🔧 Create Table
-- =====================================
CREATE TABLE InventoryItems (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    LastUpdated DATETIME NOT NULL
);

-- =====================================
-- ⚙ Stored Procedures
-- =====================================

-- Add
GO
CREATE PROCEDURE usp_AddInventoryItem
    @ProductId INT,
    @Quantity INT,
    @LastUpdated DATETIME
AS
BEGIN
    INSERT INTO InventoryItems (ProductId, Quantity, LastUpdated)
    VALUES (@ProductId, @Quantity, @LastUpdated)
END

-- Get All
GO
CREATE PROCEDURE usp_GetAllInventoryItems
AS
BEGIN
    SELECT Id, ProductId, Quantity, LastUpdated
    FROM InventoryItems
END

-- Get By ID
GO
CREATE PROCEDURE usp_GetInventoryItemById
    @Id INT
AS
BEGIN
    SELECT Id, ProductId, Quantity, LastUpdated
    FROM InventoryItems
    WHERE Id = @Id
END

-- Update
GO
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

-- Delete
GO
CREATE PROCEDURE usp_DeleteInventoryItem
    @Id INT
AS
BEGIN
    DELETE FROM InventoryItems
    WHERE Id = @Id
END
