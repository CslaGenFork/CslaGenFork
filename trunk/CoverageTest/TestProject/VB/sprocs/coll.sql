/****** Object:  StoredProcedure [dbo].[Getcoll] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Getcoll]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[Getcoll]
GO

CREATE PROCEDURE [dbo].[Getcoll]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get item from table */
        SELECT
            [ProductTypes].[ProductTypeId],
            [ProductTypes].[Description]
        FROM [dbo].[ProductTypes]

    END
GO

