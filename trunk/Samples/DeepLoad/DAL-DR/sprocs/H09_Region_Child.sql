/****** Object:  StoredProcedure [GetH09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetH09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetH09_Region_Child]
GO

CREATE PROCEDURE [GetH09_Region_Child]
    @Region_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H09_Region_Child from table */
        SELECT
            [4_Regions_Child].[Region_Child_Name]
        FROM [4_Regions_Child]
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID1 AND
            [4_Regions_Child].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddH09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddH09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddH09_Region_Child]
GO

CREATE PROCEDURE [AddH09_Region_Child]
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

/****** Object:  StoredProcedure [UpdateH09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateH09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateH09_Region_Child]
GO

CREATE PROCEDURE [UpdateH09_Region_Child]
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
            RAISERROR ('''H09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteH09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteH09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteH09_Region_Child]
GO

CREATE PROCEDURE [DeleteH09_Region_Child]
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
            RAISERROR ('''H09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H09_Region_Child object as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID

    END
GO
