/****** Object:  StoredProcedure [dbo].[GetProductTypeCachedNVL] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetProductTypeCachedNVL]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetProductTypeCachedNVL]
GO

CREATE PROCEDURE [dbo].[GetProductTypeCachedNVL]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get ProductTypeCachedNVL from table */
        SELECT
            [ProductTypes].[ProductTypeId],
            [ProductTypes].[Name]
        FROM [dbo].[ProductTypes]

    END
GO

