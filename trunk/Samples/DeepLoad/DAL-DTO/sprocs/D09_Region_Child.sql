/****** Object:  StoredProcedure [GetD09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD09_Region_Child]
GO

CREATE PROCEDURE [GetD09_Region_Child]
    @Region_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D09_Region_Child from table */
        SELECT
            [4_Regions_Child].[Region_Child_Name]
        FROM [4_Regions_Child]
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID1

    END
GO

/****** Object:  StoredProcedure [AddD09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddD09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddD09_Region_Child]
GO

CREATE PROCEDURE [AddD09_Region_Child]
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

/****** Object:  StoredProcedure [UpdateD09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateD09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateD09_Region_Child]
GO

CREATE PROCEDURE [UpdateD09_Region_Child]
    @Region_ID1 int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID1
        )
        BEGIN
            RAISERROR ('''D09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteD09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteD09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteD09_Region_Child]
GO

CREATE PROCEDURE [DeleteD09_Region_Child]
    @Region_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID1
        )
        BEGIN
            RAISERROR ('''D09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D09_Region_Child object from 4_Regions_Child */
        DELETE
        FROM [4_Regions_Child]
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID1

    END
GO
