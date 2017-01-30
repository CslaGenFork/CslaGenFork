/****** Object:  StoredProcedure [AddA05_SubContinent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddA05_SubContinent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddA05_SubContinent_Child]
GO

CREATE PROCEDURE [AddA05_SubContinent_Child]
    @SubContinent_ID1 int,
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
            @SubContinent_ID1,
            @SubContinent_Child_Name
        )

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_Child]
        WHERE
            [SubContinent_ID1] = @SubContinent_ID1

    END
GO

/****** Object:  StoredProcedure [UpdateA05_SubContinent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateA05_SubContinent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateA05_SubContinent_Child]
GO

CREATE PROCEDURE [UpdateA05_SubContinent_Child]
    @SubContinent_ID1 int,
    @SubContinent_Child_Name varchar(50),
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID1
        )
        BEGIN
            RAISERROR ('''A05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID1 AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''A05_SubContinent_Child'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_Child */
        UPDATE [2_SubContinents_Child]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID1] = @SubContinent_ID1 AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_Child]
        WHERE
            [SubContinent_ID1] = @SubContinent_ID1

    END
GO

/****** Object:  StoredProcedure [DeleteA05_SubContinent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteA05_SubContinent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteA05_SubContinent_Child]
GO

CREATE PROCEDURE [DeleteA05_SubContinent_Child]
    @SubContinent_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID1
        )
        BEGIN
            RAISERROR ('''A05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete A05_SubContinent_Child object from 2_SubContinents_Child */
        DELETE
        FROM [2_SubContinents_Child]
        WHERE
            [2_SubContinents_Child].[SubContinent_ID1] = @SubContinent_ID1

    END
GO
