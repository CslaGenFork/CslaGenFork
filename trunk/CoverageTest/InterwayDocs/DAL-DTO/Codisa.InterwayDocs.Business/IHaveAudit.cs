using Csla;

namespace Codisa.InterwayDocs.Business
{
    public interface IHaveAudit
    {
        SmartDate CreateDate { get; }
        SmartDate ChangeDate { get; }
    }
}