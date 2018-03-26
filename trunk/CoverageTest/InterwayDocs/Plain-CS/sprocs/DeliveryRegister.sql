/****** Object:  StoredProcedure [dbo].[GetDeliveryRegister] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDeliveryRegister]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetDeliveryRegister]
GO

CREATE PROCEDURE [dbo].[GetDeliveryRegister]
    @RegisterId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get DeliveryRegister from table */
        SELECT
            [DeliveryRegisters].[RegisterId],
            [DeliveryRegisters].[RegisterDate],
            [DeliveryRegisters].[DocumentType],
            [DeliveryRegisters].[DocumentReference],
            [DeliveryRegisters].[DocumentEntity],
            [DeliveryRegisters].[DocumentDept],
            [DeliveryRegisters].[DocumentClass],
            [DeliveryRegisters].[DocumentDate],
            [DeliveryRegisters].[RecipientName],
            [DeliveryRegisters].[ExpeditorName],
            [DeliveryRegisters].[ReceptionName],
            [DeliveryRegisters].[ReceptionDate],
            [DeliveryRegisters].[CreateDate],
            [DeliveryRegisters].[ChangeDate]
        FROM [dbo].[DeliveryRegisters]
        WHERE
            [DeliveryRegisters].[RegisterId] = @RegisterId

    END
GO

/****** Object:  StoredProcedure [dbo].[AddDeliveryRegister] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddDeliveryRegister]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddDeliveryRegister]
GO

CREATE PROCEDURE [dbo].[AddDeliveryRegister]
    @RegisterId int OUTPUT,
    @RegisterDate date,
    @DocumentType varchar(25),
    @DocumentReference varchar(20),
    @DocumentEntity varchar(150),
    @DocumentDept varchar(150),
    @DocumentClass varchar(50),
    @DocumentDate date,
    @RecipientName varchar(150),
    @ExpeditorName varchar(50),
    @ReceptionName varchar(50),
    @ReceptionDate date,
    @CreateDate datetime2,
    @ChangeDate datetime2
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.DeliveryRegisters */
        INSERT INTO [dbo].[DeliveryRegisters]
        (
            [RegisterDate],
            [DocumentType],
            [DocumentReference],
            [DocumentEntity],
            [DocumentDept],
            [DocumentClass],
            [DocumentDate],
            [RecipientName],
            [ExpeditorName],
            [ReceptionName],
            [ReceptionDate],
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
            @RecipientName,
            @ExpeditorName,
            @ReceptionName,
            @ReceptionDate,
            @CreateDate,
            @ChangeDate
        )

        /* Return new primary key */
        SET @RegisterId = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [dbo].[UpdateDeliveryRegister] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateDeliveryRegister]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateDeliveryRegister]
GO

CREATE PROCEDURE [dbo].[UpdateDeliveryRegister]
    @RegisterId int,
    @RegisterDate date,
    @DocumentType varchar(25),
    @DocumentReference varchar(20),
    @DocumentEntity varchar(150),
    @DocumentDept varchar(150),
    @DocumentClass varchar(50),
    @DocumentDate date,
    @RecipientName varchar(150),
    @ExpeditorName varchar(50),
    @ReceptionName varchar(50),
    @ReceptionDate date,
    @ChangeDate datetime2
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [RegisterId] FROM [dbo].[DeliveryRegisters]
            WHERE
                [RegisterId] = @RegisterId
        )
        BEGIN
            RAISERROR ('''dbo.DeliveryRegister'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in dbo.DeliveryRegisters */
        UPDATE [dbo].[DeliveryRegisters]
        SET
            [RegisterDate] = @RegisterDate,
            [DocumentType] = @DocumentType,
            [DocumentReference] = @DocumentReference,
            [DocumentEntity] = @DocumentEntity,
            [DocumentDept] = @DocumentDept,
            [DocumentClass] = @DocumentClass,
            [DocumentDate] = @DocumentDate,
            [RecipientName] = @RecipientName,
            [ExpeditorName] = @ExpeditorName,
            [ReceptionName] = @ReceptionName,
            [ReceptionDate] = @ReceptionDate,
            [ChangeDate] = @ChangeDate
        WHERE
            [RegisterId] = @RegisterId

    END
GO

