/****** Object:  StoredProcedure [dbo].[AddProductTypeItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddProductTypeItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddProductTypeItem]
GO

CREATE PROCEDURE [dbo].[AddProductTypeItem]
    @ProductTypeId int OUTPUT,
    @Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.ProductTypes */
        INSERT INTO [dbo].[ProductTypes]
        (
            [Name]
        )
        VALUES
        (
            @Name
        )

        /* Return new primary key */
        SET @ProductTypeId = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [dbo].[UpdateProductTypeItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateProductTypeItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateProductTypeItem]
GO

CREATE PROCEDURE [dbo].[UpdateProductTypeItem]
    @ProductTypeId int,
    @Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [ProductTypeId] FROM [dbo].[ProductTypes]
            WHERE
                [ProductTypeId] = @ProductTypeId
        )
        BEGIN
            RAISERROR ('''dbo.ProductTypeItem'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in dbo.ProductTypes */
        UPDATE [dbo].[ProductTypes]
        SET
            [Name] = @Name
        WHERE
            [ProductTypeId] = @ProductTypeId

    END
GO

/****** Object:  StoredProcedure [dbo].[DeleteProductTypeItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteProductTypeItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[DeleteProductTypeItem]
GO

CREATE PROCEDURE [dbo].[DeleteProductTypeItem]
    @ProductTypeId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [ProductTypeId] FROM [dbo].[ProductTypes]
            WHERE
                [ProductTypeId] = @ProductTypeId
        )
        BEGIN
            RAISERROR ('''dbo.ProductTypeItem'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete ProductTypeItem object from ProductTypes */
        DELETE
        FROM [dbo].[ProductTypes]
        WHERE
            [dbo].[ProductTypes].[ProductTypeId] = @ProductTypeId

    END
GO
