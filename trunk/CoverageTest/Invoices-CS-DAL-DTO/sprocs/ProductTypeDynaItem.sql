/****** Object:  StoredProcedure [dbo].[AddProductTypeDynaItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddProductTypeDynaItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddProductTypeDynaItem]
GO

CREATE PROCEDURE [dbo].[AddProductTypeDynaItem]
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

/****** Object:  StoredProcedure [dbo].[UpdateProductTypeDynaItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateProductTypeDynaItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateProductTypeDynaItem]
GO

CREATE PROCEDURE [dbo].[UpdateProductTypeDynaItem]
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
            RAISERROR ('''dbo.ProductTypeDynaItem'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [dbo].[DeleteProductTypeDynaItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteProductTypeDynaItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[DeleteProductTypeDynaItem]
GO

CREATE PROCEDURE [dbo].[DeleteProductTypeDynaItem]
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
            RAISERROR ('''dbo.ProductTypeDynaItem'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete ProductTypeDynaItem object from ProductTypes */
        DELETE
        FROM [dbo].[ProductTypes]
        WHERE
            [dbo].[ProductTypes].[ProductTypeId] = @ProductTypeId

    END
GO
