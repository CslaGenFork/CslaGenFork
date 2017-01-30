/****** Object:  StoredProcedure [AddE05_SubContinent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddE05_SubContinent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddE05_SubContinent_ReChild]
GO

CREATE PROCEDURE [AddE05_SubContinent_ReChild]
    @SubContinent_ID2 int,
    @SubContinent_Child_Name varchar(50),
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents_ReChild */
        INSERT INTO [2_SubContinents_ReChild]
        (
            [SubContinent_ID2],
            [SubContinent_Child_Name]
        )
        VALUES
        (
            @SubContinent_ID2,
            @SubContinent_Child_Name
        )

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_ReChild]
        WHERE
            [SubContinent_ID2] = @SubContinent_ID2

    END
GO

/****** Object:  StoredProcedure [UpdateE05_SubContinent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateE05_SubContinent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateE05_SubContinent_ReChild]
GO

CREATE PROCEDURE [UpdateE05_SubContinent_ReChild]
    @SubContinent_ID2 int,
    @SubContinent_Child_Name varchar(50),
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID2 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID2 AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''E05_SubContinent_ReChild'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_ReChild */
        UPDATE [2_SubContinents_ReChild]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID2] = @SubContinent_ID2 AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_ReChild]
        WHERE
            [SubContinent_ID2] = @SubContinent_ID2

    END
GO

/****** Object:  StoredProcedure [DeleteE05_SubContinent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteE05_SubContinent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteE05_SubContinent_ReChild]
GO

CREATE PROCEDURE [DeleteE05_SubContinent_ReChild]
    @SubContinent_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID2 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark E05_SubContinent_ReChild object as not active */
        UPDATE [2_SubContinents_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [2_SubContinents_ReChild].[SubContinent_ID2] = @SubContinent_ID2

    END
GO
