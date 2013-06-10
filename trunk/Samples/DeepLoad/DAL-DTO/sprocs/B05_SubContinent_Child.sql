/****** Object:  StoredProcedure [AddB05_SubContinent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddB05_SubContinent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddB05_SubContinent_Child]
GO

CREATE PROCEDURE [AddB05_SubContinent_Child]
    @SubContinent_ID1 int,
    @SubContinent_Child_Name varchar(50)
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
            @SubContinent_ID1,
            @SubContinent_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateB05_SubContinent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateB05_SubContinent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateB05_SubContinent_Child]
GO

CREATE PROCEDURE [UpdateB05_SubContinent_Child]
    @SubContinent_ID1 int,
    @SubContinent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID1
        )
        BEGIN
            RAISERROR ('''B05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_Child */
        UPDATE [2_SubContinents_Child]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID1] = @SubContinent_ID1

    END
GO

/****** Object:  StoredProcedure [DeleteB05_SubContinent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteB05_SubContinent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteB05_SubContinent_Child]
GO

CREATE PROCEDURE [DeleteB05_SubContinent_Child]
    @SubContinent_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID1
        )
        BEGIN
            RAISERROR ('''B05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B05_SubContinent_Child object from 2_SubContinents_Child */
        DELETE
        FROM [2_SubContinents_Child]
        WHERE
            [2_SubContinents_Child].[SubContinent_ID1] = @SubContinent_ID1

    END
GO
