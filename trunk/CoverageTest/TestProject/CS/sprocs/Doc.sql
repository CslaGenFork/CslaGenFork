/****** Object:  StoredProcedure [GetDoc] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetDoc]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetDoc]
GO

CREATE PROCEDURE [GetDoc]
    @DocID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get Doc from table */
        SELECT
            [Docs].[DocID],
            [Docs].[DocTypeID],
            [Docs].[DocRef],
            [Docs].[DocDate],
            [Docs].[Subject]
        FROM [Docs]
        WHERE
            [Docs].[DocID] = @DocID

        /* Get DocFolder from table */
        SELECT
            [DocsFolders].[FolderID],
            [Folders].[FolderRef],
            [Folders].[Year],
            [Folders].[Subject]
        FROM [DocsFolders]
            INNER JOIN [Docs] ON [DocsFolders].[DocID] = [Docs].[DocID]
            INNER JOIN [Folders] ON [DocsFolders].[FolderID] = [Folders].[FolderID]
        WHERE
            [Docs].[DocID] = @DocID AND
            [DocsFolders].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddDoc] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddDoc]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddDoc]
GO

CREATE PROCEDURE [AddDoc]
    @DocID int OUTPUT,
    @DocTypeID int,
    @DocRef varchar(40),
    @DocDate date,
    @Subject varchar(255)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Docs */
        INSERT INTO [Docs]
        (
            [DocTypeID],
            [DocRef],
            [DocDate],
            [Subject]
        )
        VALUES
        (
            @DocTypeID,
            @DocRef,
            @DocDate,
            @Subject
        )

        /* Return new primary key */
        SET @DocID = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [UpdateDoc] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateDoc]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateDoc]
GO

CREATE PROCEDURE [UpdateDoc]
    @DocID int,
    @DocTypeID int,
    @DocRef varchar(40),
    @DocDate date,
    @Subject varchar(255)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [DocID] FROM [Docs]
            WHERE
                [DocID] = @DocID
        )
        BEGIN
            RAISERROR ('''Doc'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Docs */
        UPDATE [Docs]
        SET
            [DocTypeID] = @DocTypeID,
            [DocRef] = @DocRef,
            [DocDate] = @DocDate,
            [Subject] = @Subject
        WHERE
            [DocID] = @DocID

    END
GO

