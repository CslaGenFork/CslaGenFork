/****** Object:  StoredProcedure [GetH05_SubContinent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetH05_SubContinent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetH05_SubContinent_Child]
GO

CREATE PROCEDURE [GetH05_SubContinent_Child]
    @SubContinent_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H05_SubContinent_Child from table */
        SELECT
            [2_SubContinents_Child].[SubContinent_Child_Name]
        FROM [2_SubContinents_Child]
        WHERE
            [2_SubContinents_Child].[SubContinent_ID1] = @SubContinent_ID1 AND
            [2_SubContinents_Child].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddH05_SubContinent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddH05_SubContinent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddH05_SubContinent_Child]
GO

CREATE PROCEDURE [AddH05_SubContinent_Child]
    @SubContinent_ID int,
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
            @SubContinent_ID,
            @SubContinent_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateH05_SubContinent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateH05_SubContinent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateH05_SubContinent_Child]
GO

CREATE PROCEDURE [UpdateH05_SubContinent_Child]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_Child */
        UPDATE [2_SubContinents_Child]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID1] = @SubContinent_ID

    END
GO

/****** Object:  StoredProcedure [DeleteH05_SubContinent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteH05_SubContinent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteH05_SubContinent_Child]
GO

CREATE PROCEDURE [DeleteH05_SubContinent_Child]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H05_SubContinent_Child object as not active */
        UPDATE [2_SubContinents_Child]
        SET    [IsActive] = 'false'
        WHERE
            [2_SubContinents_Child].[SubContinent_ID1] = @SubContinent_ID

    END
GO
