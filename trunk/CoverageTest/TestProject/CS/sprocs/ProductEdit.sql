/****** Object:  StoredProcedure [dbo].[GetProductEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetProductEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetProductEdit]
GO

CREATE PROCEDURE [dbo].[GetProductEdit]
    @ProductId uniqueidentifier
AS
    BEGIN

        SET NOCOUNT ON

        /* Get ProductEdit from table */
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
        WHERE
            [Products].[ProductId] = @ProductId

        /* Get ProductSupplierItem from table */
        SELECT
            [ProductsSuppliers].[ProductSupplierId],
            [ProductsSuppliers].[SupplierId]
        FROM [dbo].[ProductsSuppliers]
            INNER JOIN [dbo].[Products] ON [ProductsSuppliers].[ProductId] = [Products].[ProductId]
        WHERE
            [Products].[ProductId] = @ProductId

    END
GO

/****** Object:  StoredProcedure [dbo].[AddProductEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddProductEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddProductEdit]
GO

CREATE PROCEDURE [dbo].[AddProductEdit]
    @ProductId uniqueidentifier,
    @ProductCode nchar(10),
    @Name varchar(50),
    @ProductTypeId int,
    @UnitCost nchar(10),
    @StockByteNull tinyint,
    @StockByte tinyint,
    @StockShortNull smallint,
    @StockShort smallint,
    @StockIntNull int,
    @StockInt int,
    @StockLongNull bigint,
    @StockLong bigint
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.Products */
        INSERT INTO [dbo].[Products]
        (
            [ProductId],
            [ProductCode],
            [Name],
            [ProductTypeId],
            [UnitCost],
            [StockByteNull],
            [StockByte],
            [StockShortNull],
            [StockShort],
            [StockIntNull],
            [StockInt],
            [StockLongNull],
            [StockLong]
        )
        VALUES
        (
            @ProductId,
            @ProductCode,
            @Name,
            @ProductTypeId,
            @UnitCost,
            @StockByteNull,
            @StockByte,
            @StockShortNull,
            @StockShort,
            @StockIntNull,
            @StockInt,
            @StockLongNull,
            @StockLong
        )

    END
GO

/****** Object:  StoredProcedure [dbo].[UpdateProductEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateProductEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateProductEdit]
GO

CREATE PROCEDURE [dbo].[UpdateProductEdit]
    @ProductId uniqueidentifier,
    @ProductCode nchar(10),
    @Name varchar(50),
    @ProductTypeId int,
    @UnitCost nchar(10),
    @StockByteNull tinyint,
    @StockByte tinyint,
    @StockShortNull smallint,
    @StockShort smallint,
    @StockIntNull int,
    @StockInt int,
    @StockLongNull bigint,
    @StockLong bigint
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [ProductId] FROM [dbo].[Products]
            WHERE
                [ProductId] = @ProductId
        )
        BEGIN
            RAISERROR ('''dbo.ProductEdit'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in dbo.Products */
        UPDATE [dbo].[Products]
        SET
            [ProductCode] = @ProductCode,
            [Name] = @Name,
            [ProductTypeId] = @ProductTypeId,
            [UnitCost] = @UnitCost,
            [StockByteNull] = @StockByteNull,
            [StockByte] = @StockByte,
            [StockShortNull] = @StockShortNull,
            [StockShort] = @StockShort,
            [StockIntNull] = @StockIntNull,
            [StockInt] = @StockInt,
            [StockLongNull] = @StockLongNull,
            [StockLong] = @StockLong
        WHERE
            [ProductId] = @ProductId

    END
GO

