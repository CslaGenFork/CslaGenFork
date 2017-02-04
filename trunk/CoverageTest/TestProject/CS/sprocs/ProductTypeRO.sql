/****** Object:  StoredProcedure [dbo].[GetProductTypeRO] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetProductTypeRO]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetProductTypeRO]
GO

CREATE PROCEDURE [dbo].[GetProductTypeRO]
    @ProductTypeId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get ProductTypeRO from table */
        SELECT
            [ProductTypes].[ProductTypeId],
            [ProductTypes].[Name]
        FROM [dbo].[ProductTypes]
        WHERE
            [ProductTypes].[ProductTypeId] = @ProductTypeId

    END
GO

