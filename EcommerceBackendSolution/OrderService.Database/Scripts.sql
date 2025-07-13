-- =============================================
-- 📁 OrderService.Database/Scripts.sql
-- =============================================

-- 🔄 Drop table if exists (for re-run)
IF OBJECT_ID('dbo.Orders', 'U') IS NOT NULL
    DROP TABLE dbo.Orders;
GO

-- 📦 Table: Orders
CREATE TABLE Orders (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    OrderDate DATETIME NOT NULL,
    TotalAmount DECIMAL(10,2) NOT NULL,
    Status NVARCHAR(50) NOT NULL DEFAULT 'Pending'
);
GO

-- =============================================
-- ✅ Stored Procedure: usp_AddOrder
-- =============================================
IF OBJECT_ID('dbo.usp_AddOrder', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_AddOrder;
GO

CREATE PROCEDURE dbo.usp_AddOrder
    @UserId INT,
    @OrderDate DATETIME,
    @TotalAmount DECIMAL(10,2),
    @Status NVARCHAR(50)
AS
BEGIN
    INSERT INTO Orders (UserId, OrderDate, TotalAmount, Status)
    VALUES (@UserId, @OrderDate, @TotalAmount, @Status);
END;
GO

-- =============================================
-- ✅ Stored Procedure: usp_GetAllOrders
-- =============================================
IF OBJECT_ID('dbo.usp_GetAllOrders', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_GetAllOrders;
GO

CREATE PROCEDURE dbo.usp_GetAllOrders
AS
BEGIN
    SELECT * FROM Orders;
END;
GO

-- =============================================
-- ✅ Stored Procedure: usp_GetOrderById
-- =============================================
IF OBJECT_ID('dbo.usp_GetOrderById', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_GetOrderById;
GO

CREATE PROCEDURE dbo.usp_GetOrderById
    @Id INT
AS
BEGIN
    SELECT * FROM Orders WHERE Id = @Id;
END;
GO

-- =============================================
-- ✅ Stored Procedure: usp_UpdateOrder
-- =============================================
IF OBJECT_ID('dbo.usp_UpdateOrder', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_UpdateOrder;
GO

CREATE PROCEDURE dbo.usp_UpdateOrder
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
    WHERE Id = @Id;
END;
GO

-- =============================================
-- ✅ Stored Procedure: usp_DeleteOrder
-- =============================================
IF OBJECT_ID('dbo.usp_DeleteOrder', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_DeleteOrder;
GO

CREATE PROCEDURE dbo.usp_DeleteOrder
    @Id INT
AS
BEGIN
    DELETE FROM Orders WHERE Id = @Id;
END;
GO
