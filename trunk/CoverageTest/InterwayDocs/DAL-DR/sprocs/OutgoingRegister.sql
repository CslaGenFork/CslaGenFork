/****** Object:  StoredProcedure [dbo].[GetOutgoingRegister] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetOutgoingRegister]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetOutgoingRegister]
GO

CREATE PROCEDURE [dbo].[GetOutgoingRegister]
    @RegisterId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get OutgoingRegister from table */
        SELECT
            [OutgoingRegisters].[RegisterId],
            [OutgoingRegisters].[RegisterDate],
            [OutgoingRegisters].[DocumentType],
            [OutgoingRegisters].[DocumentReference],
            [OutgoingRegisters].[DocumentEntity],
            [OutgoingRegisters].[DocumentDept],
            [OutgoingRegisters].[DocumentClass],
            [OutgoingRegisters].[DocumentDate],
            [OutgoingRegisters].[Subject],
            [OutgoingRegisters].[SendDate],
            [OutgoingRegisters].[RecipientName],
            [OutgoingRegisters].[RecipientTown],
            [OutgoingRegisters].[Notes],
            [OutgoingRegisters].[ArchiveLocation],
            [OutgoingRegisters].[CreateDate],
            [OutgoingRegisters].[ChangeDate]
        FROM [dbo].[OutgoingRegisters]
        WHERE
            [OutgoingRegisters].[RegisterId] = @RegisterId

    END
GO

/****** Object:  StoredProcedure [dbo].[AddOutgoingRegister] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddOutgoingRegister]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddOutgoingRegister]
GO

CREATE PROCEDURE [dbo].[AddOutgoingRegister]
    @RegisterId int OUTPUT,
    @RegisterDate date,
    @DocumentType varchar(25),
    @DocumentReference varchar(20),
    @DocumentEntity varchar(150),
    @DocumentDept varchar(150),
    @DocumentClass varchar(50),
    @DocumentDate date,
    @Subject varchar(500),
    @SendDate date,
    @RecipientName varchar(150),
    @RecipientTown varchar(50),
    @Notes varchar(500),
    @ArchiveLocation varchar(50),
    @CreateDate datetime2,
    @ChangeDate datetime2
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.OutgoingRegisters */
        INSERT INTO [dbo].[OutgoingRegisters]
        (
            [RegisterDate],
            [DocumentType],
            [DocumentReference],
            [DocumentEntity],
            [DocumentDept],
            [DocumentClass],
            [DocumentDate],
            [Subject],
            [SendDate],
            [RecipientName],
            [RecipientTown],
            [Notes],
            [ArchiveLocation],
            [CreateDate],
            [ChangeDate]
        )
        VALUES
        (
            @RegisterDate,
            @DocumentType,
            @DocumentReference,
            @DocumentEntity,
            @DocumentDept,
            @DocumentClass,
            @DocumentDate,
            @Subject,
            @SendDate,
            @RecipientName,
            @RecipientTown,
            @Notes,
            @ArchiveLocation,
            @CreateDate,
            @ChangeDate
        )

        /* Return new primary key */
        SET @RegisterId = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [dbo].[UpdateOutgoingRegister] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateOutgoingRegister]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateOutgoingRegister]
GO

CREATE PROCEDURE [dbo].[UpdateOutgoingRegister]
    @RegisterId int,
    @RegisterDate date,
    @DocumentType varchar(25),
    @DocumentReference varchar(20),
    @DocumentEntity varchar(150),
    @DocumentDept varchar(150),
    @DocumentClass varchar(50),
    @DocumentDate date,
    @Subject varchar(500),
    @SendDate date,
    @RecipientName varchar(150),
    @RecipientTown varchar(50),
    @Notes varchar(500),
    @ArchiveLocation varchar(50),
    @ChangeDate datetime2
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [RegisterId] FROM [dbo].[OutgoingRegisters]
            WHERE
                [RegisterId] = @RegisterId
        )
        BEGIN
            RAISERROR ('''dbo.OutgoingRegister'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in dbo.OutgoingRegisters */
        UPDATE [dbo].[OutgoingRegisters]
        SET
            [RegisterDate] = @RegisterDate,
            [DocumentType] = @DocumentType,
            [DocumentReference] = @DocumentReference,
            [DocumentEntity] = @DocumentEntity,
            [DocumentDept] = @DocumentDept,
            [DocumentClass] = @DocumentClass,
            [DocumentDate] = @DocumentDate,
            [Subject] = @Subject,
            [SendDate] = @SendDate,
            [RecipientName] = @RecipientName,
            [RecipientTown] = @RecipientTown,
            [Notes] = @Notes,
            [ArchiveLocation] = @ArchiveLocation,
            [ChangeDate] = @ChangeDate
        WHERE
            [RegisterId] = @RegisterId

    END
GO

