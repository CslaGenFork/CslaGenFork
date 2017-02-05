/****** Object:  StoredProcedure [GetDocClassEditDynaColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetDocClassEditDynaColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetDocClassEditDynaColl]
GO

CREATE PROCEDURE [GetDocClassEditDynaColl]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get DocClassEditDyna from table */
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

