/****** Object:  StoredProcedure [dbo].[GetProductTypeCachedList] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetProductTypeCachedList]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetProductTypeCachedList]
GO

CREATE PROCEDURE [dbo].[GetProductTypeCachedList]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get ProductTypeCachedInfo from table */
        SELECT
            [ProductTypes].[ProductTypeId],
            [ProductTypes].[Name]
        FROM [dbo].[ProductTypes]

    END
GO

