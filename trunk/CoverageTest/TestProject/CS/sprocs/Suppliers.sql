/****** Object:  StoredProcedure [dbo].[GetSuppliers] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSuppliers]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetSuppliers]
GO

CREATE PROCEDURE [dbo].[GetSuppliers]
    @SupplierId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get Suppliers from table */
        SELECT
            [Suppliers].[SupplierId],
            [Suppliers].[Name],
            [Suppliers].[AddressLine1],
            [Suppliers].[AddressLine2],
            [Suppliers].[ZipCode],
            [Suppliers].[State],
            [Suppliers].[Coutry]
        FROM [dbo].[Suppliers]
        WHERE
            [Suppliers].[SupplierId] = @SupplierId

        /* Get SupplierProductItem from table */
        SELECT
            [ProductsSuppliers].[ProductSupplierId],
            [ProductsSuppliers].[ProductId]
        FROM [dbo].[ProductsSuppliers]
            INNER JOIN [dbo].[Suppliers] ON [ProductsSuppliers].[SupplierId] = [Suppliers].[SupplierId]
        WHERE
            [Suppliers].[SupplierId] = @SupplierId

    END
GO

/****** Object:  StoredProcedure [dbo].[AddSuppliers] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddSuppliers]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddSuppliers]
GO

CREATE PROCEDURE [dbo].[AddSuppliers]
    @SupplierId int,
    @Name varchar(50),
    @AddressLine1 varchar(100),
    @AddressLine2 varchar(100),
    @ZipCode varchar(15),
    @State varchar(15),
    @Coutry tinyint
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
            [Coutry]
        )
        VALUES
        (
            @SupplierId,
            @Name,
            @AddressLine1,
            @AddressLine2,
            @ZipCode,
            @State,
            @Coutry
        )

    END
GO

/****** Object:  StoredProcedure [dbo].[UpdateSuppliers] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateSuppliers]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateSuppliers]
GO

CREATE PROCEDURE [dbo].[UpdateSuppliers]
    @SupplierId int,
    @Name varchar(50),
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
            SELECT [SupplierId] FROM [dbo].[Suppliers]
            WHERE
                [SupplierId] = @SupplierId
        )
        BEGIN
            RAISERROR ('''dbo.Suppliers'' object not found. It was probably removed by another user.', 16, 1)
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
            [Coutry] = @Coutry
        WHERE
            [SupplierId] = @SupplierId

    END
GO

