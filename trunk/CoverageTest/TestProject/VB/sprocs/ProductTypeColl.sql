/****** Object:  StoredProcedure [dbo].[GetProductTypeColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetProductTypeColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetProductTypeColl]
GO

CREATE PROCEDURE [dbo].[GetProductTypeColl]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get ProductTypeItem from table */
        SELECT
            [ProductTypes].[ProductTypeId],
            [ProductTypes].[Description]
        FROM [dbo].[ProductTypes]

    END
GO

