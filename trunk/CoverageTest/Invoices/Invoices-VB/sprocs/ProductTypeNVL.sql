/****** Object:  StoredProcedure [dbo].[GetProductTypeNVL] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetProductTypeNVL]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetProductTypeNVL]
GO

CREATE PROCEDURE [dbo].[GetProductTypeNVL]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get ProductTypeNVL from table */
        SELECT
            [ProductTypes].[ProductTypeId],
            [ProductTypes].[Name]
        FROM [dbo].[ProductTypes]

    END
GO

