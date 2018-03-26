namespace Codisa.InterwayDocs.Rules
{
    /// <summary>
    /// Interface that defines an archive location where to search.
    /// </summary>
    public interface IHaveArchiveLocation
    {
        /// <summary>
        /// Gets or sets the archive location where to search.
        /// </summary>
        /// <value>
        /// The archive location where to search.
        /// </value>
        string ArchiveLocation { get; set; }
    }
}