/****** Object:  StoredProcedure [dbo].[GetProductTypeUpdatedByRootList] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetProductTypeUpdatedByRootList]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetProductTypeUpdatedByRootList]
GO

CREATE PROCEDURE [dbo].[GetProductTypeUpdatedByRootList]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get ProductTypeUpdatedByRootInfo from table */
        SELECT
            [ProductTypes].[ProductTypeId],
            [ProductTypes].[Name]
        FROM [dbo].[ProductTypes]

    END
GO

