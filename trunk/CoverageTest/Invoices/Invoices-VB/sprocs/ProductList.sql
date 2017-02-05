/****** Object:  StoredProcedure [dbo].[GetProductList] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetProductList]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetProductList]
GO

CREATE PROCEDURE [dbo].[GetProductList]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get ProductInfo from table */
        SELECT
            [Products].[ProductId],
            RTRIM([Products].[ProductCode]) AS [ProductCode],
            [Products].[Name],
            [Products].[ProductTypeId],
            RTRIM([Products].[UnitCost]) AS [UnitCost],
            [Products].[StockByteNull],
            [Products].[StockByte],
            [Products].[StockShortNull],
            [Products].[StockShort],
            [Products].[StockIntNull],
            [Products].[StockInt],
            [Products].[StockLongNull],
            [Products].[StockLong]
        FROM [dbo].[Products]

    END
GO

