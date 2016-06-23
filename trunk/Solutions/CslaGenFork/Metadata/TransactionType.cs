using System.ComponentModel;

namespace CslaGenerator.Metadata
{
    public enum TransactionType
    {
        None = 1,
        [Description("ADO.NET")]
        ADO = 2,
        TransactionScope = 3,
        EnterpriseServices = 4,
        TransactionalAttribute = 5
    }
}