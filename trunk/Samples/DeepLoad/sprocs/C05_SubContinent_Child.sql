/****** Object:  StoredProcedure [GetC05_SubContinent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetC05_SubContinent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetC05_SubContinent_Child]
GO

CREATE PROCEDURE [GetC05_SubContinent_Child]
    @SubContinent_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C05_SubContinent_Child from table */
        SELECT
            [2_SubContinents_Child].[SubContinent_Child_Name],
            [2_SubContinents_Child].[SubContinent_ID1],
            [2_SubContinents_Child].[RowVersion]
        FROM [2_SubContinents_Child]
        WHERE
            [2_SubContinents_Child].[SubContinent_ID1] = @SubContinent_ID1

    END
GO

/****** Object:  StoredProcedure [AddC05_SubContinent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddC05_SubContinent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddC05_SubContinent_Child]
GO

CREATE PROCEDURE [AddC05_SubContinent_Child]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50),
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents_Child */
        INSERT INTO [2_SubContinents_Child]
        (
            [SubContinent_ID1],
            [SubContinent_Child_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @SubContinent_Child_Name
        )

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_Child]
        WHERE
            [SubContinent_ID1] = @SubContinent_ID

    END
GO

/****** Object:  StoredProcedure [UpdateC05_SubContinent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateC05_SubContinent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateC05_SubContinent_Child]
GO

CREATE PROCEDURE [UpdateC05_SubContinent_Child]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50),
    @SubContinent_ID1 int,
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1], [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID AND
                [SubContinent_ID1] = @SubContinent_ID1
        )
        BEGIN
            RAISERROR ('''C05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1], [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID AND
                [SubContinent_ID1] = @SubContinent_ID1 AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''C05_SubContinent_Child'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_Child */
        UPDATE [2_SubContinents_Child]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID1] = @SubContinent_ID AND
            [SubContinent_ID1] = @SubContinent_ID1 AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_Child]
        WHERE
            [SubContinent_ID1] = @SubContinent_ID AND
            [SubContinent_ID1] = @SubContinent_ID1

    END
GO

/****** Object:  StoredProcedure [DeleteC05_SubContinent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteC05_SubContinent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteC05_SubContinent_Child]
GO

CREATE PROCEDURE [DeleteC05_SubContinent_Child]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''C05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C05_SubContinent_Child object from 2_SubContinents_Child */
        DELETE
        FROM [2_SubContinents_Child]
        WHERE
            [2_SubContinents_Child].[SubContinent_ID1] = @SubContinent_ID

    END
GO
