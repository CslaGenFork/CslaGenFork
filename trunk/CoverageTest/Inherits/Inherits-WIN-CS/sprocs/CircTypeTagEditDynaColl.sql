/****** Object:  StoredProcedure [GetCircTypeTagEditDynaColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetCircTypeTagEditDynaColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetCircTypeTagEditDynaColl]
GO

CREATE PROCEDURE [GetCircTypeTagEditDynaColl]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get CircTypeTagEditDyna from table */
        SELECT
            [CircTypeTags].[CircTypeID],
            [CircTypeTags].[CircTypeTag],
            [CircTypeTags].[CreateDate],
            [CircTypeTags].[CreateUserID],
            [CircTypeTags].[ChangeDate],
            [CircTypeTags].[ChangeUserID],
            [CircTypeTags].[RowVersion]
        FROM [CircTypeTags]
        WHERE
            [CircTypeTags].[IsActive] = 'true'

    END
GO

