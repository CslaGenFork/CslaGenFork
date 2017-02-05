/****** Object:  StoredProcedure [GetCircTypeTagNVL] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetCircTypeTagNVL]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetCircTypeTagNVL]
GO

CREATE PROCEDURE [GetCircTypeTagNVL]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get CircTypeTagNVL from table */
        SELECT
            [CircTypeTags].[CircTypeID],
            [CircTypeTags].[CircTypeTag]
        FROM [CircTypeTags]
        WHERE
            [CircTypeTags].[IsActive] = 'true'

    END
GO

