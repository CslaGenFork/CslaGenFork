/****** Object:  StoredProcedure [GetDocClassList] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetDocClassList]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetDocClassList]
GO

CREATE PROCEDURE [GetDocClassList]
    @DocClassName varchar(20) = NULL
AS
    BEGIN

        SET NOCOUNT ON

        /* Search Variables */
        IF (@DocClassName <> '')
            SET @DocClassName = @DocClassName + '%'
        ELSE
            SET @DocClassName = '%'

        /* Get DocClassInfo from table */
        SELECT
            [DocClasses].[DocClassID],
            [DocClasses].[DocClassName],
            [DocClasses].[IsActive]
        FROM [DocClasses]
        WHERE
            ISNULL([DocClasses].[DocClassName], '') LIKE @DocClassName

    END
GO

