/****** Object:  StoredProcedure [GetD05_SubContinent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD05_SubContinent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD05_SubContinent_ReChild]
GO

CREATE PROCEDURE [GetD05_SubContinent_ReChild]
    @SubContinent_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D05_SubContinent_ReChild from table */
        SELECT
            [2_SubContinents_ReChild].[SubContinent_Child_Name]
        FROM [2_SubContinents_ReChild]
        WHERE
            [2_SubContinents_ReChild].[SubContinent_ID2] = @SubContinent_ID2

    END
GO

/****** Object:  StoredProcedure [AddD05_SubContinent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddD05_SubContinent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddD05_SubContinent_ReChild]
GO

CREATE PROCEDURE [AddD05_SubContinent_ReChild]
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

/****** Object:  StoredProcedure [UpdateD05_SubContinent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateD05_SubContinent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateD05_SubContinent_ReChild]
GO

CREATE PROCEDURE [UpdateD05_SubContinent_ReChild]
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
                [SubContinent_ID2] = @SubContinent_ID2
        )
        BEGIN
            RAISERROR ('''D05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteD05_SubContinent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteD05_SubContinent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteD05_SubContinent_ReChild]
GO

CREATE PROCEDURE [DeleteD05_SubContinent_ReChild]
    @SubContinent_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID2
        )
        BEGIN
            RAISERROR ('''D05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D05_SubContinent_ReChild object from 2_SubContinents_ReChild */
        DELETE
        FROM [2_SubContinents_ReChild]
        WHERE
            [2_SubContinents_ReChild].[SubContinent_ID2] = @SubContinent_ID2

    END
GO
