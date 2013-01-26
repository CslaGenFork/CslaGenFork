/****** Object:  StoredProcedure [AddF09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddF09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddF09_Region_Child]
GO

CREATE PROCEDURE [AddF09_Region_Child]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions_Child */
        INSERT INTO [4_Regions_Child]
        (
            [Region_ID1],
            [Region_Child_Name]
        )
        VALUES
        (
            @Region_ID,
            @Region_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateF09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateF09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateF09_Region_Child]
GO

CREATE PROCEDURE [UpdateF09_Region_Child]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_Child */
        UPDATE [4_Regions_Child]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID1] = @Region_ID

    END
GO

/****** Object:  StoredProcedure [DeleteF09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteF09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteF09_Region_Child]
GO

CREATE PROCEDURE [DeleteF09_Region_Child]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F09_Region_Child object as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID

    END
GO
