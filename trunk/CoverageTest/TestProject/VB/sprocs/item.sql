/****** Object:  StoredProcedure [dbo].[Additem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Additem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[Additem]
GO

CREATE PROCEDURE [dbo].[Additem]
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

/****** Object:  StoredProcedure [dbo].[Updateitem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Updateitem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[Updateitem]
GO

CREATE PROCEDURE [dbo].[Updateitem]
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
            RAISERROR ('''dbo.item'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [dbo].[Deleteitem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Deleteitem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[Deleteitem]
GO

CREATE PROCEDURE [dbo].[Deleteitem]
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
            RAISERROR ('''dbo.item'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete item object from ProductTypes */
        DELETE
        FROM [dbo].[ProductTypes]
        WHERE
            [dbo].[ProductTypes].[ProductTypeId] = @ProductTypeId

    END
GO
