/****** Object:  StoredProcedure [dbo].[AddProductTypeDyna] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddProductTypeDyna]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddProductTypeDyna]
GO

CREATE PROCEDURE [dbo].[AddProductTypeDyna]
    @ProductTypeId int,
    @Description varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.ProductTypes */
        INSERT INTO [dbo].[ProductTypes]
        (
            [ProductTypeId],
            [Description]
        )
        VALUES
        (
            @ProductTypeId,
            @Description
        )

    END
GO

/****** Object:  StoredProcedure [dbo].[UpdateProductTypeDyna] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateProductTypeDyna]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateProductTypeDyna]
GO

CREATE PROCEDURE [dbo].[UpdateProductTypeDyna]
    @ProductTypeId int,
    @Description varchar(50)
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
            RAISERROR ('''dbo.ProductTypeDyna'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in dbo.ProductTypes */
        UPDATE [dbo].[ProductTypes]
        SET
            [Description] = @Description
        WHERE
            [ProductTypeId] = @ProductTypeId

    END
GO

/****** Object:  StoredProcedure [dbo].[DeleteProductTypeDyna] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteProductTypeDyna]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[DeleteProductTypeDyna]
GO

CREATE PROCEDURE [dbo].[DeleteProductTypeDyna]
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
            RAISERROR ('''dbo.ProductTypeDyna'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete ProductTypeDyna object from ProductTypes */
        DELETE
        FROM [dbo].[ProductTypes]
        WHERE
            [dbo].[ProductTypes].[ProductTypeId] = @ProductTypeId

    END
GO
