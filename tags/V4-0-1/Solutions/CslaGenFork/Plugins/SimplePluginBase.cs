using System;
using System.Collections.Generic;
using System.Text;
using DBSchemaInfo.Base;
using CslaGenerator.Metadata;

namespace CslaGenerator.Plugins
{
    public class SimplePluginBase : ISimplePlugin
    {
        ICatalog _Catalog;
        CslaGeneratorUnit _Unit;
        IEnumerable<CslaObjectInfo> _SelectedObjects;
        List<ScriptCommandInfo> _Commands = new List<ScriptCommandInfo>();


        #region ISimplePlugin Members

        public ICatalog Catalog
        {
            get
            {
                return _Catalog;
            }
            set
            {
                _Catalog = value;
            }
        }

        public CslaGeneratorUnit Unit
        {
            get
            {
                return _Unit;
            }
            set
            {
                _Unit = value;
            }
        }

        public IEnumerable<CslaObjectInfo> SelectedObjects
        {
            get
            {
                return _SelectedObjects;
            }
            set
            {
                _SelectedObjects = value;
            }
        }

        public IEnumerable<ScriptCommandInfo> GetCommands()
        {
            return _Commands;
        }

        #endregion

        protected List<ScriptCommandInfo> Commands
        {
            get
            {
                return _Commands;
            }
        }
        protected void AddCommand(ScriptCommandInfo command)
        {
            _Commands.Add(command);
        }
        protected void AddCommand(string title, string description, ScriptCommandInfo.RunCommandDelegate command)
        {
            ScriptCommandInfo cmd = new ScriptCommandInfo(title, description, command);
            AddCommand(cmd);
        }
        protected void AddCommand(string title, ScriptCommandInfo.RunCommandDelegate command)
        {
            ScriptCommandInfo cmd = new ScriptCommandInfo(title, string.Empty, command);
            AddCommand(cmd);
        }

    }
}
