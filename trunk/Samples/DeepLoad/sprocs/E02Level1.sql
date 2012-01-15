/****** Object:  StoredProcedure [GetE02Level1] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetE02Level1]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetE02Level1]
GO

CREATE PROCEDURE [GetE02Level1]
    @Level_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get E02Level1 from table */
        SELECT
            [Level_1].[Level_1_ID],
            [Level_1].[Level_1_Name]
        FROM [Level_1]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID AND
            [Level_1].[IsActive] = 'true'

        /* Get E03Level11Child from table */
        SELECT
            [Level_1_1_Child].[Level_1_1_Child_Name]
        FROM [Level_1_1_Child]
            INNER JOIN [Level_1] ON [Level_1_1_Child].[CParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID AND
            [Level_1_1_Child].[IsActive] = 'true'

        /* Get E03Level11ReChild from table */
        SELECT
            [Level_1_1_ReChild].[Level_1_1_Child_Name]
        FROM [Level_1_1_ReChild]
            INNER JOIN [Level_1] ON [Level_1_1_ReChild].[CParentID2] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID AND
            [Level_1_1_ReChild].[IsActive] = 'true'

        /* Get E04Level11 from table */
        SELECT
            [Level_1_1].[Level_1_1_ID],
            [Level_1_1].[Level_1_1_Name]
        FROM [Level_1_1]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID AND
            [Level_1_1].[IsActive] = 'true'

        /* Get E05Level111Child from table */
        SELECT
            [Level_1_1_1_Child].[CMarentID1],
            [Level_1_1_1_Child].[Level_1_1_1_Child_Name],
            [Level_1_1_1_Child].[RowVersion]
        FROM [Level_1_1_1_Child]
            INNER JOIN [Level_1_1] ON [Level_1_1_1_Child].[CMarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID AND
            [Level_1_1_1_Child].[IsActive] = 'true'

        /* Get E05Level111ReChild from table */
        SELECT
            [Level_1_1_1_ReChild].[CMarentID2],
            [Level_1_1_1_ReChild].[Level_1_1_1_Child_Name],
            [Level_1_1_1_ReChild].[RowVersion]
        FROM [Level_1_1_1_ReChild]
            INNER JOIN [Level_1_1] ON [Level_1_1_1_ReChild].[CMarentID2] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID AND
            [Level_1_1_1_ReChild].[IsActive] = 'true'

        /* Get E06Level111 from table */
        SELECT
            [Level_1_1_1].[MarentID1],
            [Level_1_1_1].[Level_1_1_1_ID],
            [Level_1_1_1].[Level_1_1_1_Name],
            [Level_1_1_1].[RowVersion]
        FROM [Level_1_1_1]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID AND
            [Level_1_1_1].[IsActive] = 'true'

        /* Get E07Level1111Child from table */
        SELECT
            [Level_1_1_1_1_Child].[CLarentID1],
            [Level_1_1_1_1_Child].[Level_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1_Child].[CLarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID AND
            [Level_1_1_1_1_Child].[IsActive] = 'true'

        /* Get E07Level1111ReChild from table */
        SELECT
            [Level_1_1_1_1_ReChild].[CLarentID2],
            [Level_1_1_1_1_ReChild].[Level_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1_ReChild].[CLarentID2] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID AND
            [Level_1_1_1_1_ReChild].[IsActive] = 'true'

        /* Get E08Level1111 from table */
        SELECT
            [Level_1_1_1_1].[LarentID1],
            [Level_1_1_1_1].[Level_1_1_1_1_ID],
            [Level_1_1_1_1].[Level_1_1_1_1_Name]
        FROM [Level_1_1_1_1]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID AND
            [Level_1_1_1_1].[IsActive] = 'true'

        /* Get E09Level11111Child from table */
        SELECT
            [Level_1_1_1_1_1_Child].[CNarentID1],
            [Level_1_1_1_1_1_Child].[Level_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1_Child].[CNarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID AND
            [Level_1_1_1_1_1_Child].[IsActive] = 'true'

        /* Get E09Level11111ReChild from table */
        SELECT
            [Level_1_1_1_1_1_ReChild].[CNarentID2],
            [Level_1_1_1_1_1_ReChild].[Level_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1_ReChild].[CNarentID2] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID AND
            [Level_1_1_1_1_1_ReChild].[IsActive] = 'true'

        /* Get E10Level11111 from table */
        SELECT
            [Level_1_1_1_1_1].[NarentID1],
            [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID],
            [Level_1_1_1_1_1].[Level_1_1_1_1_1_Name]
        FROM [Level_1_1_1_1_1]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID AND
            [Level_1_1_1_1_1].[IsActive] = 'true'

        /* Get E11Level111111Child from table */
        SELECT
            [Level_1_1_1_1_1_1_Child].[CQarentID1],
            [Level_1_1_1_1_1_1_Child].[Level_1_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1_Child].[CQarentID1] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID AND
            [Level_1_1_1_1_1_1_Child].[IsActive] = 'true'

        /* Get E11Level111111ReChild from table */
        SELECT
            [Level_1_1_1_1_1_1_ReChild].[CQarentID2],
            [Level_1_1_1_1_1_1_ReChild].[Level_1_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1_ReChild].[CQarentID2] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID AND
            [Level_1_1_1_1_1_1_ReChild].[IsActive] = 'true'

        /* Get E12Level111111 from table */
        SELECT
            [Level_1_1_1_1_1_1].[QarentID1],
            [Level_1_1_1_1_1_1].[Level_1_1_1_1_1_1_ID],
            [Level_1_1_1_1_1_1].[Level_1_1_1_1_1_1_Name]
        FROM [Level_1_1_1_1_1_1]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1].[QarentID1] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID AND
            [Level_1_1_1_1_1_1].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddE02Level1] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddE02Level1]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddE02Level1]
GO

CREATE PROCEDURE [AddE02Level1]
    @Level_1_ID int OUTPUT,
    @Level_1_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1 */
        INSERT INTO [Level_1]
        (
            [Level_1_Name]
        )
        VALUES
        (
            @Level_1_Name
        )

        /* Return new primary key */
        SET @Level_1_ID = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [UpdateE02Level1] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateE02Level1]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateE02Level1]
GO

CREATE PROCEDURE [UpdateE02Level1]
    @Level_1_ID int,
    @Level_1_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Level_1_ID] FROM [Level_1]
            WHERE
                [Level_1_ID] = @Level_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E02Level1'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1 */
        UPDATE [Level_1]
        SET
            [Level_1_Name] = @Level_1_Name
        WHERE
            [Level_1_ID] = @Level_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteE02Level1] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteE02Level1]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteE02Level1]
GO

CREATE PROCEDURE [DeleteE02Level1]
    @Level_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Level_1_ID] FROM [Level_1]
            WHERE
                [Level_1_ID] = @Level_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E02Level1'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child E12Level111111 as not active */
        UPDATE [Level_1_1_1_1_1_1]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_1_1_1]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1].[QarentID1] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child E11Level111111ReChild as not active */
        UPDATE [Level_1_1_1_1_1_1_ReChild]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1_ReChild].[CQarentID2] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child E11Level111111Child as not active */
        UPDATE [Level_1_1_1_1_1_1_Child]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1_Child].[CQarentID1] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child E10Level11111 as not active */
        UPDATE [Level_1_1_1_1_1]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_1_1]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child E09Level11111ReChild as not active */
        UPDATE [Level_1_1_1_1_1_ReChild]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1_ReChild].[CNarentID2] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child E09Level11111Child as not active */
        UPDATE [Level_1_1_1_1_1_Child]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1_Child].[CNarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child E08Level1111 as not active */
        UPDATE [Level_1_1_1_1]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_1]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child E07Level1111ReChild as not active */
        UPDATE [Level_1_1_1_1_ReChild]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1_ReChild].[CLarentID2] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child E07Level1111Child as not active */
        UPDATE [Level_1_1_1_1_Child]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1_Child].[CLarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child E06Level111 as not active */
        UPDATE [Level_1_1_1]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child E05Level111ReChild as not active */
        UPDATE [Level_1_1_1_ReChild]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_ReChild]
            INNER JOIN [Level_1_1] ON [Level_1_1_1_ReChild].[CMarentID2] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child E05Level111Child as not active */
        UPDATE [Level_1_1_1_Child]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_Child]
            INNER JOIN [Level_1_1] ON [Level_1_1_1_Child].[CMarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child E04Level11 as not active */
        UPDATE [Level_1_1]
        SET    [IsActive] = 'false'
        FROM [Level_1_1]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child E03Level11ReChild as not active */
        UPDATE [Level_1_1_ReChild]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_ReChild]
            INNER JOIN [Level_1] ON [Level_1_1_ReChild].[CParentID2] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child E03Level11Child as not active */
        UPDATE [Level_1_1_Child]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_Child]
            INNER JOIN [Level_1] ON [Level_1_1_Child].[CParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark E02Level1 object as not active */
        UPDATE [Level_1]
        SET    [IsActive] = 'false'
        WHERE
            [Level_1_ID] = @Level_1_ID

    END
GO
