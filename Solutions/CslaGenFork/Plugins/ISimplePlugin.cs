using System;
using System.Collections.Generic;
using System.Text;
using CslaGenerator.Metadata;
using DBSchemaInfo.Base;
namespace CslaGenerator.Plugins
{
    public interface ISimplePlugin
    {
        ICatalog Catalog { get; set; }
        CslaGeneratorUnit Unit { get; set; }
        IEnumerable<CslaObjectInfo> SelectedObjects { get; set; }
        IEnumerable<ScriptCommandInfo> GetCommands();
    }
}
