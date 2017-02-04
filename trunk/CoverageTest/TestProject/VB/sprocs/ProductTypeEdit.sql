/****** Object:  StoredProcedure [dbo].[GetProductTypeEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetProductTypeEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetProductTypeEdit]
GO

CREATE PROCEDURE [dbo].[GetProductTypeEdit]
    @ProductTypeId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get ProductTypeEdit from table */
        SELECT
            [ProductTypes].[ProductTypeId],
            [ProductTypes].[Description]
        FROM [dbo].[ProductTypes]
        WHERE
            [ProductTypes].[ProductTypeId] = @ProductTypeId

    END
GO

/****** Object:  StoredProcedure [dbo].[AddProductTypeEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddProductTypeEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddProductTypeEdit]
GO

CREATE PROCEDURE [dbo].[AddProductTypeEdit]
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

/****** Object:  StoredProcedure [dbo].[UpdateProductTypeEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateProductTypeEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateProductTypeEdit]
GO

CREATE PROCEDURE [dbo].[UpdateProductTypeEdit]
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
            RAISERROR ('''dbo.ProductTypeEdit'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [dbo].[DeleteProductTypeEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteProductTypeEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[DeleteProductTypeEdit]
GO

CREATE PROCEDURE [dbo].[DeleteProductTypeEdit]
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
            RAISERROR ('''dbo.ProductTypeEdit'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete ProductTypeEdit object from ProductTypes */
        DELETE
        FROM [dbo].[ProductTypes]
        WHERE
            [dbo].[ProductTypes].[ProductTypeId] = @ProductTypeId

    END
GO
