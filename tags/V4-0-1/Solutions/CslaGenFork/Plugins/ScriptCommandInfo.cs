using System;
using System.Collections.Generic;
using System.Text;

namespace CslaGenerator.Plugins
{
    public class ScriptCommandInfo
    {

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the ScriptCommandInfo class.
        /// </summary>
        /// <param name="commandTitle"></param>
        /// <param name="commandDescription"></param>
        /// <param name="command"></param>
        public ScriptCommandInfo(string commandTitle, string commandDescription, RunCommandDelegate command)
        {
            _CommandTitle = commandTitle;
            _CommandDescription = commandDescription;
            _command = command;
        }
        #endregion

        private string _CommandTitle;
        public string CommandTitle
        {
            get { return _CommandTitle; }
            set
            {
                _CommandTitle = value;
            }
        }
        private string _CommandDescription;
        public string CommandDescription
        {
            get { return _CommandDescription; }
            set
            {
                _CommandDescription = value;
            }
        }

        public delegate void RunCommandDelegate();
        RunCommandDelegate _command;
        public void SetCommand(RunCommandDelegate command)
        {
            _command = command;
        }
        public virtual void RunCommand()
        {
            if (_command == null)
                throw new ApplicationException("Undefined command!");
            _command();
        }

    }
}
