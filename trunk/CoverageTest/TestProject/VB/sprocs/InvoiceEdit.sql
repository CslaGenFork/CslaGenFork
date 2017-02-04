/****** Object:  StoredProcedure [dbo].[GetInvoiceEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetInvoiceEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetInvoiceEdit]
GO

CREATE PROCEDURE [dbo].[GetInvoiceEdit]
    @InvoiceId uniqueidentifier
AS
    BEGIN

        SET NOCOUNT ON

        /* Get InvoiceEdit from table */
        SELECT
            [Invoices].[InvoiceId],
            [Invoices].[InvoiceNumber],
            [Invoices].[CustomerName],
            [Invoices].[InvoiceDate],
            [Invoices].[CreateDate],
            [Invoices].[CreateUser],
            [Invoices].[ChangeDate],
            [Invoices].[ChangeUser],
            [Invoices].[RowVersion]
        FROM [dbo].[Invoices]
        WHERE
            [Invoices].[InvoiceId] = @InvoiceId AND
            [Invoices].[IsActive] = 'true'

        /* Get InvoiceLineItem from table */
        SELECT
            [InvoiceLines].[InvoiceLineId],
            [InvoiceLines].[ProductId],
            [InvoiceLines].[Cost],
            [InvoiceLines].[PercentDiscount]
        FROM [dbo].[InvoiceLines]
            INNER JOIN [dbo].[Invoices] ON [InvoiceLines].[InvoiceId] = [Invoices].[InvoiceId]
        WHERE
            [Invoices].[InvoiceId] = @InvoiceId

    END
GO

/****** Object:  StoredProcedure [dbo].[AddInvoiceEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddInvoiceEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddInvoiceEdit]
GO

CREATE PROCEDURE [dbo].[AddInvoiceEdit]
    @InvoiceId uniqueidentifier,
    @InvoiceNumber varchar(20),
    @CustomerName nvarchar(50),
    @InvoiceDate date,
    @CreateDate datetime2,
    @CreateUser int,
    @ChangeDate datetime2,
    @ChangeUser int,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.Invoices */
        INSERT INTO [dbo].[Invoices]
        (
            [InvoiceId],
            [InvoiceNumber],
            [CustomerName],
            [InvoiceDate],
            [CreateDate],
            [CreateUser],
            [ChangeDate],
            [ChangeUser]
        )
        VALUES
        (
            @InvoiceId,
            @InvoiceNumber,
            @CustomerName,
            @InvoiceDate,
            @CreateDate,
            @CreateUser,
            @ChangeDate,
            @ChangeUser
        )

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [dbo].[Invoices]
        WHERE
            [InvoiceId] = @InvoiceId

    END
GO

/****** Object:  StoredProcedure [dbo].[UpdateInvoiceEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateInvoiceEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateInvoiceEdit]
GO

CREATE PROCEDURE [dbo].[UpdateInvoiceEdit]
    @InvoiceId uniqueidentifier,
    @InvoiceNumber varchar(20),
    @CustomerName nvarchar(50),
    @InvoiceDate date,
    @ChangeDate datetime2,
    @ChangeUser int,
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [InvoiceId] FROM [dbo].[Invoices]
            WHERE
                [InvoiceId] = @InvoiceId AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''dbo.InvoiceEdit'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [InvoiceId] FROM [dbo].[Invoices]
            WHERE
                [InvoiceId] = @InvoiceId AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''dbo.InvoiceEdit'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in dbo.Invoices */
        UPDATE [dbo].[Invoices]
        SET
            [InvoiceNumber] = @InvoiceNumber,
            [CustomerName] = @CustomerName,
            [InvoiceDate] = @InvoiceDate,
            [ChangeDate] = @ChangeDate,
            [ChangeUser] = @ChangeUser
        WHERE
            [InvoiceId] = @InvoiceId AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [dbo].[Invoices]
        WHERE
            [InvoiceId] = @InvoiceId

    END
GO

/****** Object:  StoredProcedure [dbo].[DeleteInvoiceEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteInvoiceEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[DeleteInvoiceEdit]
GO

CREATE PROCEDURE [dbo].[DeleteInvoiceEdit]
    @InvoiceId uniqueidentifier
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [InvoiceId] FROM [dbo].[Invoices]
            WHERE
                [InvoiceId] = @InvoiceId AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''dbo.InvoiceEdit'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child InvoiceLineItem from InvoiceLines */
        DELETE
            [dbo].[InvoiceLines]
        FROM [dbo].[InvoiceLines]
            INNER JOIN [dbo].[Invoices] ON [InvoiceLines].[InvoiceId] = [Invoices].[InvoiceId]
        WHERE
            [dbo].[Invoices].[InvoiceId] = @InvoiceId

        /* Mark InvoiceEdit object as not active */
        UPDATE [dbo].[Invoices]
        SET    [IsActive] = 'false'
        WHERE
            [dbo].[Invoices].[InvoiceId] = @InvoiceId

    END
GO
