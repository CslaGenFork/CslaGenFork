/****** Object:  StoredProcedure [dbo].[GetInvoiceList] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetInvoiceList]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetInvoiceList]
GO

CREATE PROCEDURE [dbo].[GetInvoiceList]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get InvoiceInfo from table */
        SELECT
            [Invoices].[InvoiceId],
            [Invoices].[InvoiceNumber],
            RTRIM([Invoices].[CustomerId]) AS [CustomerId],
            [Invoices].[InvoiceDate],
            [Invoices].[IsActive],
            [Invoices].[CreateDate],
            [Invoices].[CreateUser],
            [Invoices].[ChangeDate],
            [Invoices].[ChangeUser]
        FROM [dbo].[Invoices]

    END
GO

