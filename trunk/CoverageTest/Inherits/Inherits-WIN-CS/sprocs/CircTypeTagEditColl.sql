/****** Object:  StoredProcedure [GetCircTypeTagEditColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetCircTypeTagEditColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetCircTypeTagEditColl]
GO

CREATE PROCEDURE [GetCircTypeTagEditColl]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get CircTypeTagEdit from table */
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

