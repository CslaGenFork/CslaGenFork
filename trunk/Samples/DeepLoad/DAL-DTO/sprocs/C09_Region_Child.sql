/****** Object:  StoredProcedure [GetC09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetC09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetC09_Region_Child]
GO

CREATE PROCEDURE [GetC09_Region_Child]
    @Region_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C09_Region_Child from table */
        SELECT
            [4_Regions_Child].[Region_Child_Name]
        FROM [4_Regions_Child]
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID1

    END
GO

/****** Object:  StoredProcedure [AddC09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddC09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddC09_Region_Child]
GO

CREATE PROCEDURE [AddC09_Region_Child]
    @Region_ID1 int,
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
            @Region_ID1,
            @Region_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateC09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateC09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateC09_Region_Child]
GO

CREATE PROCEDURE [UpdateC09_Region_Child]
    @Region_ID1 int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID1
        )
        BEGIN
            RAISERROR ('''C09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_Child */
        UPDATE [4_Regions_Child]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID1] = @Region_ID1

    END
GO

/****** Object:  StoredProcedure [DeleteC09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteC09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteC09_Region_Child]
GO

CREATE PROCEDURE [DeleteC09_Region_Child]
    @Region_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID1
        )
        BEGIN
            RAISERROR ('''C09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C09_Region_Child object from 4_Regions_Child */
        DELETE
        FROM [4_Regions_Child]
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID1

    END
GO
