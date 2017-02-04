/****** Object:  StoredProcedure [dbo].[GetCustomerEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCustomerEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetCustomerEdit]
GO

CREATE PROCEDURE [dbo].[GetCustomerEdit]
    @CustomerId char(10)
AS
    BEGIN

        SET NOCOUNT ON

        /* Get CustomerEdit from table */
        SELECT
            RTRIM([Customers].[CustomerId]) AS [CustomerId],
            [Customers].[Name],
            [Customers].[FiscalNumber],
            [Customers].[AddressLine1],
            [Customers].[AddressLine2],
            [Customers].[ZipCode],
            [Customers].[State],
            [Customers].[Coutry]
        FROM [dbo].[Customers]
        WHERE
            [Customers].[CustomerId] = @CustomerId

    END
GO

/****** Object:  StoredProcedure [dbo].[AddCustomerEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddCustomerEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddCustomerEdit]
GO

CREATE PROCEDURE [dbo].[AddCustomerEdit]
    @CustomerId char(10),
    @Name varchar(50),
    @FiscalNumber varchar(20),
    @AddressLine1 varchar(100),
    @AddressLine2 varchar(100),
    @ZipCode varchar(15),
    @State varchar(15),
    @Coutry tinyint
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.Customers */
        INSERT INTO [dbo].[Customers]
        (
            [CustomerId],
            [Name],
            [FiscalNumber],
            [AddressLine1],
            [AddressLine2],
            [ZipCode],
            [State],
            [Coutry]
        )
        VALUES
        (
            @CustomerId,
            @Name,
            @FiscalNumber,
            @AddressLine1,
            @AddressLine2,
            @ZipCode,
            @State,
            @Coutry
        )

    END
GO

/****** Object:  StoredProcedure [dbo].[UpdateCustomerEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateCustomerEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateCustomerEdit]
GO

CREATE PROCEDURE [dbo].[UpdateCustomerEdit]
    @CustomerId char(10),
    @Name varchar(50),
    @FiscalNumber varchar(20),
    @AddressLine1 varchar(100),
    @AddressLine2 varchar(100),
    @ZipCode varchar(15),
    @State varchar(15),
    @Coutry tinyint
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CustomerId] FROM [dbo].[Customers]
            WHERE
                [CustomerId] = @CustomerId
        )
        BEGIN
            RAISERROR ('''dbo.CustomerEdit'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in dbo.Customers */
        UPDATE [dbo].[Customers]
        SET
            [Name] = @Name,
            [FiscalNumber] = @FiscalNumber,
            [AddressLine1] = @AddressLine1,
            [AddressLine2] = @AddressLine2,
            [ZipCode] = @ZipCode,
            [State] = @State,
            [Coutry] = @Coutry
        WHERE
            [CustomerId] = @CustomerId

    END
GO

