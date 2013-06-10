/****** Object:  StoredProcedure [AddA09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddA09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddA09_Region_Child]
GO

CREATE PROCEDURE [AddA09_Region_Child]
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

/****** Object:  StoredProcedure [UpdateA09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateA09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateA09_Region_Child]
GO

CREATE PROCEDURE [UpdateA09_Region_Child]
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
            RAISERROR ('''A09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteA09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteA09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteA09_Region_Child]
GO

CREATE PROCEDURE [DeleteA09_Region_Child]
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
            RAISERROR ('''A09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete A09_Region_Child object from 4_Regions_Child */
        DELETE
        FROM [4_Regions_Child]
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID1

    END
GO
