/****** Object:  StoredProcedure [dbo].[GetSupplierProductColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSupplierProductColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetSupplierProductColl]
GO

CREATE PROCEDURE [dbo].[GetSupplierProductColl]
    @SupplierId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get SupplierProductItem from table */
        SELECT
            [ProductsSuppliers].[ProductSupplierId],
            [ProductsSuppliers].[ProductId]
        FROM [dbo].[ProductsSuppliers]
        WHERE
            [ProductsSuppliers].[SupplierId] = @SupplierId

    END
GO

