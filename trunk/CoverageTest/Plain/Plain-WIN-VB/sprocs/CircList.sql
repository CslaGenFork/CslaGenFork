/****** Object:  StoredProcedure [GetCircList] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetCircList]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetCircList]
GO

CREATE PROCEDURE [GetCircList]
    @DocID int = NULL,
    @FolderID int = NULL
AS
    BEGIN

        SET NOCOUNT ON

        /* Get CircInfo from table */
        SELECT
            [Circ].[CircID],
            [Circ].[DocID],
            [Circ].[FolderID],
            [Circ].[NeedsReply],
            [Circ].[NeedsReplyDecision],
            [Circ].[CircTypeTag],
            [Circ].[SenderEntityID],
            [Circ].[SentDateTime],
            [Circ].[DaysToReply],
            [Circ].[DaysToLive]
        FROM [Circ]
        WHERE
            [Circ].[DocID] = ISNULL(@DocID, [Circ].[DocID]) AND
            [Circ].[FolderID] = ISNULL(@FolderID, [Circ].[FolderID]) AND
            [Circ].[IsActive] = 'true'

    END
GO

