/****** Object:  StoredProcedure [GetDocRO] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetDocRO]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetDocRO]
GO

CREATE PROCEDURE [GetDocRO]
    @DocID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get DocRO from table */
        SELECT
            [Docs].[DocID],
            [Docs].[DocTypeID],
            [Docs].[DocRef],
            [Docs].[DocDate],
            [Docs].[Subject]
        FROM [Docs]
        WHERE
            [Docs].[DocID] = @DocID

        /* Get DocFolderRO from table */
        SELECT
            [DocsFolders].[FolderID]
        FROM [DocsFolders]
            INNER JOIN [Docs] ON [DocsFolders].[DocID] = [Docs].[DocID]
        WHERE
            [Docs].[DocID] = @DocID AND
            [DocsFolders].[IsActive] = 'true'

    END
GO

