/****** Object:  StoredProcedure [GetDocTypeEditDynaColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetDocTypeEditDynaColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetDocTypeEditDynaColl]
GO

CREATE PROCEDURE [GetDocTypeEditDynaColl]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get DocTypeEditDyna from table */
        SELECT
            [DocTypes].[DocTypeID],
            [DocTypes].[DocTypeName],
            [DocTypes].[CreateDate],
            [DocTypes].[CreateUserID],
            [DocTypes].[ChangeDate],
            [DocTypes].[ChangeUserID],
            [DocTypes].[RowVersion]
        FROM [DocTypes]
        WHERE
            [DocTypes].[IsActive] = 'true'

    END
GO

