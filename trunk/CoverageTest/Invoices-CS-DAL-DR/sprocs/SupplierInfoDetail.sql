/****** Object:  StoredProcedure [dbo].[GetSupplierInfoDetal] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSupplierInfoDetal]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetSupplierInfoDetal]
GO

CREATE PROCEDURE [dbo].[GetSupplierInfoDetal]
    @SupplierId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get SupplierInfoDetail from table */
        SELECT
            [Suppliers].[SupplierId],
            [Suppliers].[Name],
            [Suppliers].[AddressLine1],
            [Suppliers].[AddressLine2],
            [Suppliers].[ZipCode],
            [Suppliers].[State],
            [Suppliers].[Country]
        FROM [dbo].[Suppliers]
        WHERE
            [Suppliers].[SupplierId] = @SupplierId

    END
GO

