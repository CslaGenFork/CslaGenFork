/****** Object:  StoredProcedure [dbo].[AddProductSupplierItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddProductSupplierItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddProductSupplierItem]
GO

CREATE PROCEDURE [dbo].[AddProductSupplierItem]
    @ProductSupplierId int OUTPUT,
    @ProductId uniqueidentifier,
    @SupplierId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.ProductsSuppliers */
        INSERT INTO [dbo].[ProductsSuppliers]
        (
            [ProductId],
            [SupplierId]
        )
        VALUES
        (
            @ProductId,
            @SupplierId
        )

        /* Return new primary key */
        SET @ProductSupplierId = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [dbo].[UpdateProductSupplierItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateProductSupplierItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateProductSupplierItem]
GO

CREATE PROCEDURE [dbo].[UpdateProductSupplierItem]
    @ProductSupplierId int,
    @SupplierId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [ProductSupplierId] FROM [dbo].[ProductsSuppliers]
            WHERE
                [ProductSupplierId] = @ProductSupplierId
        )
        BEGIN
            RAISERROR ('''dbo.ProductSupplierItem'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in dbo.ProductsSuppliers */
        UPDATE [dbo].[ProductsSuppliers]
        SET
            [SupplierId] = @SupplierId
        WHERE
            [ProductSupplierId] = @ProductSupplierId

    END
GO

/****** Object:  StoredProcedure [dbo].[DeleteProductSupplierItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteProductSupplierItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[DeleteProductSupplierItem]
GO

CREATE PROCEDURE [dbo].[DeleteProductSupplierItem]
    @ProductSupplierId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [ProductSupplierId] FROM [dbo].[ProductsSuppliers]
            WHERE
                [ProductSupplierId] = @ProductSupplierId
        )
        BEGIN
            RAISERROR ('''dbo.ProductSupplierItem'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete ProductSupplierItem object from ProductsSuppliers */
        DELETE
        FROM [dbo].[ProductsSuppliers]
        WHERE
            [dbo].[ProductsSuppliers].[ProductSupplierId] = @ProductSupplierId

    END
GO
