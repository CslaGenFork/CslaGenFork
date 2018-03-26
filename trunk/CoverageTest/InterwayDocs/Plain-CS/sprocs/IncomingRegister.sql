/****** Object:  StoredProcedure [dbo].[GetIncomingRegister] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetIncomingRegister]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetIncomingRegister]
GO

CREATE PROCEDURE [dbo].[GetIncomingRegister]
    @RegisterId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get IncomingRegister from table */
        SELECT
            [IncomingRegisters].[RegisterId],
            [IncomingRegisters].[RegisterDate],
            [IncomingRegisters].[DocumentType],
            [IncomingRegisters].[DocumentReference],
            [IncomingRegisters].[DocumentEntity],
            [IncomingRegisters].[DocumentDept],
            [IncomingRegisters].[DocumentClass],
            [IncomingRegisters].[DocumentDate],
            [IncomingRegisters].[Subject],
            [IncomingRegisters].[SenderName],
            [IncomingRegisters].[ReceptionDate],
            [IncomingRegisters].[RoutedTo],
            [IncomingRegisters].[Notes],
            [IncomingRegisters].[ArchiveLocation],
            [IncomingRegisters].[CreateDate],
            [IncomingRegisters].[ChangeDate]
        FROM [dbo].[IncomingRegisters]
        WHERE
            [IncomingRegisters].[RegisterId] = @RegisterId

    END
GO

/****** Object:  StoredProcedure [dbo].[AddIncomingRegister] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddIncomingRegister]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddIncomingRegister]
GO

CREATE PROCEDURE [dbo].[AddIncomingRegister]
    @RegisterId int OUTPUT,
    @RegisterDate date,
    @DocumentType varchar(25),
    @DocumentReference varchar(20),
    @DocumentEntity varchar(150),
    @DocumentDept varchar(150),
    @DocumentClass varchar(50),
    @DocumentDate date,
    @Subject varchar(500),
    @SenderName varchar(150),
    @ReceptionDate date,
    @RoutedTo varchar(50),
    @Notes varchar(500),
    @ArchiveLocation varchar(50),
    @CreateDate datetime2,
    @ChangeDate datetime2
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.IncomingRegisters */
        INSERT INTO [dbo].[IncomingRegisters]
        (
            [RegisterDate],
            [DocumentType],
            [DocumentReference],
            [DocumentEntity],
            [DocumentDept],
            [DocumentClass],
            [DocumentDate],
            [Subject],
            [SenderName],
            [ReceptionDate],
            [RoutedTo],
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
            @SenderName,
            @ReceptionDate,
            @RoutedTo,
            @Notes,
            @ArchiveLocation,
            @CreateDate,
            @ChangeDate
        )

        /* Return new primary key */
        SET @RegisterId = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [dbo].[UpdateIncomingRegister] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateIncomingRegister]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateIncomingRegister]
GO

CREATE PROCEDURE [dbo].[UpdateIncomingRegister]
    @RegisterId int,
    @RegisterDate date,
    @DocumentType varchar(25),
    @DocumentReference varchar(20),
    @DocumentEntity varchar(150),
    @DocumentDept varchar(150),
    @DocumentClass varchar(50),
    @DocumentDate date,
    @Subject varchar(500),
    @SenderName varchar(150),
    @ReceptionDate date,
    @RoutedTo varchar(50),
    @Notes varchar(500),
    @ArchiveLocation varchar(50),
    @ChangeDate datetime2
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [RegisterId] FROM [dbo].[IncomingRegisters]
            WHERE
                [RegisterId] = @RegisterId
        )
        BEGIN
            RAISERROR ('''dbo.IncomingRegister'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in dbo.IncomingRegisters */
        UPDATE [dbo].[IncomingRegisters]
        SET
            [RegisterDate] = @RegisterDate,
            [DocumentType] = @DocumentType,
            [DocumentReference] = @DocumentReference,
            [DocumentEntity] = @DocumentEntity,
            [DocumentDept] = @DocumentDept,
            [DocumentClass] = @DocumentClass,
            [DocumentDate] = @DocumentDate,
            [Subject] = @Subject,
            [SenderName] = @SenderName,
            [ReceptionDate] = @ReceptionDate,
            [RoutedTo] = @RoutedTo,
            [Notes] = @Notes,
            [ArchiveLocation] = @ArchiveLocation,
            [ChangeDate] = @ChangeDate
        WHERE
            [RegisterId] = @RegisterId

    END
GO

