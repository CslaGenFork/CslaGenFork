
        #Region " TemplateMethods "

        ''' <summary>
        ''' Retrieve extra/custom information for the object.
        ''' </summary>
        ''' <param name="dr">The data reader.</param>
        Protected Overridable Sub ExtraFetchProcessing(dr As SafeDataReader)

        End Sub

        Protected Enum Command
            Insert = 0
            Update
            Delete
            Fetch
        End Enum

        ''' <summary>
        ''' Provides a way to get more control over the database interaction,
        ''' </summary>
        ''' <param name="cmd">The command object associated with current command</param>
        ''' <param name="crit">The criteria it operates on (can be null)</param>
        ''' <param name="action">The type of action is going to be performed</param>
        Protected Overridable Sub ExtraCommandProcessing(cmd As <%= CommandMethod %>, crit As Object, action As Command)
        End Sub

        #End Region
