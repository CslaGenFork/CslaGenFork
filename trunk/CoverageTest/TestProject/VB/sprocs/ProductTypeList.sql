/****** Object:  StoredProcedure [dbo].[GetProductTypeList] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetProductTypeList]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetProductTypeList]
GO

CREATE PROCEDURE [dbo].[GetProductTypeList]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get ProductTypeInfo from table */
        SELECT
            [ProductTypes].[ProductTypeId],
            [ProductTypes].[Description]
        FROM [dbo].[ProductTypes]

    END
GO

