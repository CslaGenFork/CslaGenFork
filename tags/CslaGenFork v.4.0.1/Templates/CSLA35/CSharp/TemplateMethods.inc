
		#region TemplateMethods 
		/// <summary>
		/// Retrieve extra/custom information for the object. 
		/// </summary>
		protected virtual void ExtraFetchProcessing(SafeDataReader dr)
		{
			
		}
		
			
		protected enum Command
		{
			Insert = 0,
			Update,
			Delete,
			Fetch
		}

		/// <summary>
		/// Provides a way to get more control over the database interaction, 
		/// </summary>
		/// <param name="cmd">command object associated with current commad</param>
		/// <param name="crit">criteria it operates on (can be null)</param>
		/// <param name="action">What type of action is going to be performed</param>
		protected virtual void ExtraCommandProcessing(SqlCommand cmd, object crit, Command action)
		{
		}
		#endregion