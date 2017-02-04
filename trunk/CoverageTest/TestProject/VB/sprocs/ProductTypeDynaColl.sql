/****** Object:  StoredProcedure [dbo].[GetProductTypeDynaColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetProductTypeDynaColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetProductTypeDynaColl]
GO

CREATE PROCEDURE [dbo].[GetProductTypeDynaColl]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get ProductTypeDyna from table */
        SELECT
            [ProductTypes].[ProductTypeId],
            [ProductTypes].[Description]
        FROM [dbo].[ProductTypes]

    END
GO

