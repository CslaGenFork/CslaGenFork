//using System;
//using System.Collections;
//using System.ComponentModel;
//using System.Drawing.Design;
//using System.Windows.Forms;
//using System.Windows.Forms.Design;
//using SchemaExplorer;
//using CslaGenerator.Metadata;
//using CslaGenerator.Util;

//namespace CslaGenerator.Design
//{
//    /// <summary>
//    /// Summary description for CommandResultSchemaEditor.
//    /// </summary>
//    public class CommandResultSchemaEditor : UITypeEditor
//    {
//        private IWindowsFormsEditorService editorService = null;
//        private ListBox lstCommandResults = new ListBox();

//        public CommandResultSchemaEditor()
//        {
//            lstCommandResults.DisplayMember = "key";
//            lstCommandResults.ValueMember = "value";
//            lstCommandResults.SelectedValueChanged += new EventHandler(lstCommandResults_SelectedValueChanged);
//        }

//        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) 
//        {
//            if (provider != null)
//            {
//                editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
//                if (editorService != null) 
//                {
//                    DatabaseSchema schema = GeneratorController.Schema;
//                    if (schema == null)
//                    {
//                        throw new InvalidOperationException("You must connect to a datasource first.");
//                    }

//                    CommandSchema[] commands = new CommandSchema[schema.Commands.Count];
//                    schema.Commands.CopyTo(commands,0);
//                    Array.Sort(commands,new CommandSchemaComparer());

//                    lstCommandResults.Items.Clear();
//                    for (int i=0; i < commands.Length; i++)
//                    {
//                        foreach(CommandResultSchema result in commands[i].CommandResults)
//                        {
//                            string name = commands[i].Name + ":" + result.Name;
//                            lstCommandResults.Items.Add(new DictionaryEntry(name,result));
//                        }
//                    }
//                    editorService.DropDownControl(lstCommandResults);
					
//                    if (lstCommandResults.SelectedItem != null)
//                    {
//                        return ((DictionaryEntry)lstCommandResults.SelectedItem).Value;
//                    }
//                    else { return null; }
//                }
//            }
			
//            return value;
//        }
		
//        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) 
//        {
//            return UITypeEditorEditStyle.DropDown;
//        }

//        private void lstCommandResults_SelectedValueChanged(object sender, EventArgs e)
//        {
//            if (editorService != null)
//            {
//                editorService.CloseDropDown();
//            }
//        }
//    }
//}
