/****** Object:  StoredProcedure [dbo].[AddSupplierProductItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddSupplierProductItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddSupplierProductItem]
GO

CREATE PROCEDURE [dbo].[AddSupplierProductItem]
    @ProductSupplierId int OUTPUT,
    @SupplierId int,
    @ProductId uniqueidentifier
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.ProductsSuppliers */
        INSERT INTO [dbo].[ProductsSuppliers]
        (
            [SupplierId],
            [ProductId]
        )
        VALUES
        (
            @SupplierId,
            @ProductId
        )

        /* Return new primary key */
        SET @ProductSupplierId = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [dbo].[UpdateSupplierProductItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateSupplierProductItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateSupplierProductItem]
GO

CREATE PROCEDURE [dbo].[UpdateSupplierProductItem]
    @ProductSupplierId int,
    @ProductId uniqueidentifier
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
            RAISERROR ('''dbo.SupplierProductItem'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in dbo.ProductsSuppliers */
        UPDATE [dbo].[ProductsSuppliers]
        SET
            [ProductId] = @ProductId
        WHERE
            [ProductSupplierId] = @ProductSupplierId

    END
GO

/****** Object:  StoredProcedure [dbo].[DeleteSupplierProductItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteSupplierProductItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[DeleteSupplierProductItem]
GO

CREATE PROCEDURE [dbo].[DeleteSupplierProductItem]
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
            RAISERROR ('''dbo.SupplierProductItem'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete SupplierProductItem object from ProductsSuppliers */
        DELETE
        FROM [dbo].[ProductsSuppliers]
        WHERE
            [dbo].[ProductsSuppliers].[ProductSupplierId] = @ProductSupplierId

    END
GO
