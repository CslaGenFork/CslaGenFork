using System;

namespace Invoices.Business
{
    public interface ILog
    {
        LogActions LogAction { get; set; }

        DateTime LogDateTime { get; set; }

        int LogUser { get; set; }
    }
}