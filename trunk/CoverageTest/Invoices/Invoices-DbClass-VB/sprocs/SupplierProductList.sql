/****** Object:  StoredProcedure [dbo].[GetSupplierProductList] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSupplierProductList]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetSupplierProductList]
GO

CREATE PROCEDURE [dbo].[GetSupplierProductList]
    @SupplierId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get SupplierProductItnfo from table */
        SELECT
            [ProductsSuppliers].[ProductSupplierId],
            [ProductsSuppliers].[ProductId]
        FROM [dbo].[ProductsSuppliers]
        WHERE
            [ProductsSuppliers].[SupplierId] = @SupplierId

    END
GO

