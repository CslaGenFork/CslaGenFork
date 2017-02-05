/****** Object:  StoredProcedure [dbo].[GetCustomerList] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCustomerList]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetCustomerList]
GO

CREATE PROCEDURE [dbo].[GetCustomerList]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get CustomerInfo from table */
        SELECT
            RTRIM([Customers].[CustomerId]) AS [CustomerId],
            [Customers].[Name],
            [Customers].[FiscalNumber]
        FROM [dbo].[Customers]

    END
GO

