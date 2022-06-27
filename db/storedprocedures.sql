IF OBJECT_ID('ADD_ORDER') IS NOT NULL
    DROP PROCEDURE ADD_ORDER
GO


CREATE PROCEDURE ADD_ORDER
    @pOrderID INT,
    @pCustID NVARCHAR(100),
    @pProdID NVARCHAR(100),
    @pOrderDate DATE,
    @pQuantity INT,
    @pShipDate DATE,
    @pShipMode NVARCHAR(100)
AS
BEGIN
    BEGIN TRY
        INSERT INTO [Order]
        (OrderID, CustID, ProdID, OrderDate, Quantity, ShipDate, ShipMode)
    VALUES
        (@pOrderID,@pCustID, @pProdID, @pOrderDate, @pQuantity, @pShipDate, @pShipMode)
    END TRY
    BEGIN CATCH
    END CATCH
END
GO
-- delete order

IF OBJECT_ID('DELETE_ORDER') IS NOT NULL
    DROP PROCEDURE DELETE_ORDER
GO
CREATE PROCEDURE DELETE_ORDER
    @pOrderID INT
AS
BEGIN
    BEGIN TRY
        DELETE FROM [Order]
        WHERE OrderID = @pOrderID;
        IF @@ROWCOUNT = 0
            THROW 50060, 'Team not found', 1
    END TRY
    BEGIN CATCH
        IF ERROR_NUMBER() = 50060
            THROW
    END CATCH
END
GO