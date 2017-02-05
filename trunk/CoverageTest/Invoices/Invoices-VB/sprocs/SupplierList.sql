/****** Object:  StoredProcedure [dbo].[GetSupplierList] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSupplierList]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetSupplierList]
GO

CREATE PROCEDURE [dbo].[GetSupplierList]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get SupplierInfo from table */
        SELECT
            [Suppliers].[SupplierId],
            [Suppliers].[Name]
        FROM [dbo].[Suppliers]

    END
GO

