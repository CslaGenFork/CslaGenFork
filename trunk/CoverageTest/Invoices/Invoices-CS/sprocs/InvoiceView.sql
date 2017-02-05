/****** Object:  StoredProcedure [dbo].[GetInvoiceView] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetInvoiceView]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetInvoiceView]
GO

CREATE PROCEDURE [dbo].[GetInvoiceView]
    @InvoiceId uniqueidentifier
AS
    BEGIN

        SET NOCOUNT ON

        /* Get InvoiceView from table */
        SELECT
            [Invoices].[InvoiceId],
            [Invoices].[InvoiceNumber],
            RTRIM([Invoices].[CustomerId]) AS [CustomerId],
            [Invoices].[InvoiceDate],
            [Invoices].[IsActive],
            [Invoices].[CreateDate],
            [Invoices].[CreateUser],
            [Invoices].[ChangeDate],
            [Invoices].[ChangeUser],
            [Invoices].[RowVersion]
        FROM [dbo].[Invoices]
        WHERE
            [Invoices].[InvoiceId] = @InvoiceId

        /* Get InvoiceLineInfo from table */
        SELECT
            [InvoiceLines].[InvoiceLineId],
            [InvoiceLines].[ProductId],
            [InvoiceLines].[Quantity],
            [InvoiceLines].[UnitCost],
            [InvoiceLines].[Cost],
            [InvoiceLines].[PercentDiscount]
        FROM [dbo].[InvoiceLines]
            INNER JOIN [dbo].[Invoices] ON [InvoiceLines].[InvoiceId] = [Invoices].[InvoiceId]
        WHERE
            [Invoices].[InvoiceId] = @InvoiceId

    END
GO

