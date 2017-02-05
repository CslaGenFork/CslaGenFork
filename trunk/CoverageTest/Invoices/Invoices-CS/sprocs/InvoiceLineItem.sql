/****** Object:  StoredProcedure [dbo].[AddInvoiceLineItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddInvoiceLineItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddInvoiceLineItem]
GO

CREATE PROCEDURE [dbo].[AddInvoiceLineItem]
    @InvoiceId uniqueidentifier,
    @InvoiceLineId uniqueidentifier,
    @ProductId uniqueidentifier,
    @Cost money,
    @PercentDiscount tinyint
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.InvoiceLines */
        INSERT INTO [dbo].[InvoiceLines]
        (
            [InvoiceId],
            [InvoiceLineId],
            [ProductId],
            [Cost],
            [PercentDiscount]
        )
        VALUES
        (
            @InvoiceId,
            @InvoiceLineId,
            @ProductId,
            @Cost,
            @PercentDiscount
        )

    END
GO

/****** Object:  StoredProcedure [dbo].[UpdateInvoiceLineItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateInvoiceLineItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateInvoiceLineItem]
GO

CREATE PROCEDURE [dbo].[UpdateInvoiceLineItem]
    @InvoiceLineId uniqueidentifier,
    @ProductId uniqueidentifier,
    @Cost money,
    @PercentDiscount tinyint
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [InvoiceLineId] FROM [dbo].[InvoiceLines]
            WHERE
                [InvoiceLineId] = @InvoiceLineId
        )
        BEGIN
            RAISERROR ('''dbo.InvoiceLineItem'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in dbo.InvoiceLines */
        UPDATE [dbo].[InvoiceLines]
        SET
            [ProductId] = @ProductId,
            [Cost] = @Cost,
            [PercentDiscount] = @PercentDiscount
        WHERE
            [InvoiceLineId] = @InvoiceLineId

    END
GO

/****** Object:  StoredProcedure [dbo].[DeleteInvoiceLineItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteInvoiceLineItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[DeleteInvoiceLineItem]
GO

CREATE PROCEDURE [dbo].[DeleteInvoiceLineItem]
    @InvoiceLineId uniqueidentifier
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [InvoiceLineId] FROM [dbo].[InvoiceLines]
            WHERE
                [InvoiceLineId] = @InvoiceLineId
        )
        BEGIN
            RAISERROR ('''dbo.InvoiceLineItem'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete InvoiceLineItem object from InvoiceLines */
        DELETE
        FROM [dbo].[InvoiceLines]
        WHERE
            [dbo].[InvoiceLines].[InvoiceLineId] = @InvoiceLineId

    END
GO
