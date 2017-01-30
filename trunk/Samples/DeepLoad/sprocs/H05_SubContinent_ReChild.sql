/****** Object:  StoredProcedure [GetH05_SubContinent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetH05_SubContinent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetH05_SubContinent_ReChild]
GO

CREATE PROCEDURE [GetH05_SubContinent_ReChild]
    @SubContinent_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H05_SubContinent_ReChild from table */
        SELECT
            [2_SubContinents_ReChild].[SubContinent_Child_Name]
        FROM [2_SubContinents_ReChild]
        WHERE
            [2_SubContinents_ReChild].[SubContinent_ID2] = @SubContinent_ID2 AND
            [2_SubContinents_ReChild].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddH05_SubContinent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddH05_SubContinent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddH05_SubContinent_ReChild]
GO

CREATE PROCEDURE [AddH05_SubContinent_ReChild]
    @SubContinent_ID2 int,
    @SubContinent_Child_Name varchar(50)
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

    END
GO

/****** Object:  StoredProcedure [UpdateH05_SubContinent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateH05_SubContinent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateH05_SubContinent_ReChild]
GO

CREATE PROCEDURE [UpdateH05_SubContinent_ReChild]
    @SubContinent_ID2 int,
    @SubContinent_Child_Name varchar(50)
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
            RAISERROR ('''H05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_ReChild */
        UPDATE [2_SubContinents_ReChild]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID2] = @SubContinent_ID2

    END
GO

/****** Object:  StoredProcedure [DeleteH05_SubContinent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteH05_SubContinent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteH05_SubContinent_ReChild]
GO

CREATE PROCEDURE [DeleteH05_SubContinent_ReChild]
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
            RAISERROR ('''H05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H05_SubContinent_ReChild object as not active */
        UPDATE [2_SubContinents_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [2_SubContinents_ReChild].[SubContinent_ID2] = @SubContinent_ID2

    END
GO
