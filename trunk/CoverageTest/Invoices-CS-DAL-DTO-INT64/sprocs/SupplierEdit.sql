/****** Object:  StoredProcedure [dbo].[GetSupplierEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSupplierEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetSupplierEdit]
GO

CREATE PROCEDURE [dbo].[GetSupplierEdit]
    @SupplierId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get SupplierEdit from table */
        SELECT
            [Suppliers].[SupplierId],
            [Suppliers].[Name],
            [Suppliers].[AddressLine1],
            [Suppliers].[AddressLine2],
            [Suppliers].[ZipCode],
            [Suppliers].[State],
            [Suppliers].[Country]
        FROM [dbo].[Suppliers]
        WHERE
            [Suppliers].[SupplierId] = @SupplierId

    END
GO

/****** Object:  StoredProcedure [dbo].[AddSupplierEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddSupplierEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddSupplierEdit]
GO

CREATE PROCEDURE [dbo].[AddSupplierEdit]
    @SupplierId int,
    @Name varchar(50),
    @AddressLine1 varchar(100),
    @AddressLine2 varchar(100),
    @ZipCode varchar(15),
    @State varchar(15),
    @Country tinyint
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.Suppliers */
        INSERT INTO [dbo].[Suppliers]
        (
            [SupplierId],
            [Name],
            [AddressLine1],
            [AddressLine2],
            [ZipCode],
            [State],
            [Country]
        )
        VALUES
        (
            @SupplierId,
            @Name,
            @AddressLine1,
            @AddressLine2,
            @ZipCode,
            @State,
            @Country
        )

    END
GO

/****** Object:  StoredProcedure [dbo].[UpdateSupplierEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateSupplierEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateSupplierEdit]
GO

CREATE PROCEDURE [dbo].[UpdateSupplierEdit]
    @SupplierId int,
    @Name varchar(50),
    @AddressLine1 varchar(100),
    @AddressLine2 varchar(100),
    @ZipCode varchar(15),
    @State varchar(15),
    @Country tinyint
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SupplierId] FROM [dbo].[Suppliers]
            WHERE
                [SupplierId] = @SupplierId
        )
        BEGIN
            RAISERROR ('''dbo.SupplierEdit'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in dbo.Suppliers */
        UPDATE [dbo].[Suppliers]
        SET
            [Name] = @Name,
            [AddressLine1] = @AddressLine1,
            [AddressLine2] = @AddressLine2,
            [ZipCode] = @ZipCode,
            [State] = @State,
            [Country] = @Country
        WHERE
            [SupplierId] = @SupplierId

    END
GO

