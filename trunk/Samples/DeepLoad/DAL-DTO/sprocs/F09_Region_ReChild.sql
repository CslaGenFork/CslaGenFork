/****** Object:  StoredProcedure [AddF09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddF09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddF09_Region_ReChild]
GO

CREATE PROCEDURE [AddF09_Region_ReChild]
    @Region_ID2 int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions_ReChild */
        INSERT INTO [4_Regions_ReChild]
        (
            [Region_ID2],
            [Region_Child_Name]
        )
        VALUES
        (
            @Region_ID2,
            @Region_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateF09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateF09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateF09_Region_ReChild]
GO

CREATE PROCEDURE [UpdateF09_Region_ReChild]
    @Region_ID2 int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID2 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_ReChild */
        UPDATE [4_Regions_ReChild]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID2] = @Region_ID2

    END
GO

/****** Object:  StoredProcedure [DeleteF09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteF09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteF09_Region_ReChild]
GO

CREATE PROCEDURE [DeleteF09_Region_ReChild]
    @Region_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID2 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F09_Region_ReChild object as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID2

    END
GO
