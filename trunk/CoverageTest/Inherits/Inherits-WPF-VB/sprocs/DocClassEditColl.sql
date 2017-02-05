/****** Object:  StoredProcedure [GetDocClassEditColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetDocClassEditColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetDocClassEditColl]
GO

CREATE PROCEDURE [GetDocClassEditColl]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get DocClassEdit from table */
        SELECT
            [DocClasses].[DocClassID],
            [DocClasses].[DocClassName],
            [DocClasses].[CreateDate],
            [DocClasses].[CreateUserID],
            [DocClasses].[ChangeDate],
            [DocClasses].[ChangeUserID],
            [DocClasses].[RowVersion]
        FROM [DocClasses]
        WHERE
            [DocClasses].[IsActive] = 'true'

    END
GO

