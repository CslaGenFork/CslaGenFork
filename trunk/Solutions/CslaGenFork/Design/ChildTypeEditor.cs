using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Linq;
using CslaGenerator.CodeGen;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class ChildTypeEditor : UITypeEditor, IDisposable
    {
        private IWindowsFormsEditorService _editorService;
        private ListBox _lstProperties;

        public ChildTypeEditor()
        {
            _lstProperties = new ListBox();
            _lstProperties.DoubleClick += LstPropertiesDoubleClick;
            _lstProperties.SelectionMode = SelectionMode.One;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _editorService = (IWindowsFormsEditorService) provider.GetService(typeof(IWindowsFormsEditorService));
            if (_editorService != null)
            {
                if (context.Instance != null)
                {
                    // CR modifying to accomodate PropertyBag
                    Type instanceType = null;
                    object objinfo = null;
                    ContextHelper.GetChildPropertyContextInstanceObject(context, ref objinfo, ref instanceType);
                    var prop = (ChildProperty) objinfo;
                    _lstProperties.Items.Clear();
                    _lstProperties.Items.Add("(None)");

                    var currentCslaObject = GeneratorController.Current.CurrentCslaObject;
                    currentCslaObject.ChildCollectionProperties.MarkAllAsCollection();
                    currentCslaObject.InheritedChildCollectionProperties.MarkAllAsCollection();
                    var isCollection = ((ChildProperty) objinfo).IsCollection;
                    var objectTree = currentCslaObject.GetObjectTree();

                    foreach (var obj in GeneratorController.Current.CurrentUnit.CslaObjects)
                    {
                        var added = false;
                        var ancestor = obj.FindAncestor();

                        if (((isCollection && obj.ObjectType.IsCollectionType()) ||
                             (!isCollection && !obj.ObjectType.IsCollectionType())) &&
                            ReferenceEquals(obj, ancestor) &&
                            !objectTree.Contains(obj.ObjectName) &&
                            RelationRulesEngine.IsParentAllowed(currentCslaObject.ObjectType, obj.ObjectType))
                        {
                            _lstProperties.Items.Add(obj.ObjectName);
                            added = true;
                        }

                        if (added)
                        {
                            var candidateTree = ancestor.GetDescendents();
                            foreach (var descendent in candidateTree)
                            {
                                if (!objectTree.Contains(descendent))
                                    continue;

                                var position = _lstProperties.Items.IndexOf(obj.ObjectName);
                                if (position > -1)
                                    _lstProperties.Items[position] = string.Format("* * * {0} - tree error",                                         obj.ObjectName);
                            }
                        }
                    }
                    _lstProperties.Sorted = true;

                    _lstProperties.SelectedItem = prop.TypeName;
                    _editorService.DropDownControl(_lstProperties);
                    if (_lstProperties.SelectedIndex < 0 || _lstProperties.SelectedItem.ToString() == "(None)")
                        return string.Empty;

                    return _lstProperties.SelectedItem.ToString();
                }
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        void LstPropertiesDoubleClick(object sender, EventArgs e)
        {
            _editorService.CloseDropDown();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                if (_lstProperties != null)
                {
                    _lstProperties.Dispose();
                    _lstProperties = null;
                }
            }
            // free native resources
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}