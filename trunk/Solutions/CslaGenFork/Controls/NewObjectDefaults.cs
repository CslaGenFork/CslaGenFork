using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CslaGenerator.Metadata;

namespace CslaGenerator.Controls
{
    public partial class NewObjectDefaults : Form
    {
        private static NewObjectDefaults _identity;
        private List<ObjectProperty> _propertyList;

        public NewObjectDefaults()
        {
            InitializeComponent();
        }

        private NewObjectDefaults AssignList(List<ObjectProperty> list)
        {
            _propertyList = list;
            for (int i = 0; i < list.Count; i++)
            {
                ObjectProperty objectProp = list[i];
                var lbl = new Label();
                lbl.Text = ValueProperty.SplitOnCaps(objectProp.PropertyName);
                lbl.Size = new Size(165, 20);
                lbl.Padding = new Padding(3, 6, 0, 0);
                if (objectProp.PropertyName == "ParentType")
                {
                    var combo = new ComboBox();
                    combo.Name = objectProp.PropertyName;
                    combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    combo.Items.AddRange(objectProp.ValueList);
                    combo.AutoCompleteSource = AutoCompleteSource.ListItems;
                    combo.Tag = objectProp.PropertyName;
                    combo.Dock = DockStyle.Fill;
                    combo.TabIndex = i;
                    combo.DataBindings.Add("Text", objectProp, "PropertyValue", false, DataSourceUpdateMode.OnValidation);
                    tableLayoutPanel1.Controls.Add(lbl, 0, i);
                    tableLayoutPanel1.Controls.Add(combo, 1, i);
                }
                else if (objectProp.PropertyName == "ParentProperties")
                {
                    var lstBox = new ListBox();
                    lstBox.Name = objectProp.PropertyName;
                    lstBox.Items.AddRange(objectProp.ValueList);
                    lstBox.Tag = objectProp.PropertyName;
                    lstBox.Dock = DockStyle.Fill;
                    lstBox.TabIndex = i;
                    lstBox.DataBindings.Add("SelectedItem", objectProp, "PropertyValue", false, DataSourceUpdateMode.OnValidation);
                    lstBox.SelectionMode = SelectionMode.MultiSimple;
                    //                    lstBox.Leave += ListBox_Leaving;
                    lstBox.Validating += ListBox_Validating;
                    tableLayoutPanel1.Controls.Add(lbl, 0, i);
                    tableLayoutPanel1.Controls.Add(lstBox, 1, i);
                }
                else
                {
                    var tBox = new TextBox();
                    tBox.Name = objectProp.PropertyName;
                    tBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tBox.AutoCompleteCustomSource.AddRange(objectProp.ValueList);
                    tBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    tBox.Tag = objectProp.PropertyName;
                    tBox.Dock = DockStyle.Fill;
                    tBox.TabIndex = i;
                    tBox.DataBindings.Add("Text", objectProp, "PropertyValue", false, DataSourceUpdateMode.OnValidation);
                    tableLayoutPanel1.Controls.Add(lbl, 0, i);
                    tableLayoutPanel1.Controls.Add(tBox, 1, i);
                    if (i == 0)
                        ActiveControl = tBox;
                }
            }

            return this;
        }

        private void ListBox_Leaving(object sender, EventArgs e)
        {
            var lstBox = sender as ListBox;
            var parentProps = string.Empty;
            if (lstBox != null)
            {
                var first = true;
                foreach (var item in lstBox.SelectedItems)
                {
                    if (!first) parentProps += ", ";
                    else first = false;
                    parentProps += item.ToString();
                }
                lstBox.Tag = parentProps;
            }
        }

        private void ListBox_Validating(object sender, CancelEventArgs e)
        {
            var lstBox = sender as ListBox;
            var parentProps = string.Empty;
            if (lstBox != null)
            {
                var first = true;
                foreach (var item in lstBox.SelectedItems)
                {
                    if (!first) parentProps += ", ";
                    else first = false;
                    parentProps += item.ToString();
                }
                lstBox.Tag = parentProps;
            }
        }

        public string GetPropertyValue(string propertyName)
        {
            foreach (ObjectProperty prop in _propertyList)
            {
                if (prop.PropertyName.Equals(propertyName))
                    return prop.PropertyValue;
            }
            return String.Empty;
        }

        public static NewObjectDefaults NewEditableChildProperties()
        {
            _identity = new NewObjectDefaults();
            var list = new List<ObjectProperty>();
            list.Add(new ObjectProperty(_identity, "ObjectName"));
            list.Add(new ObjectProperty(_identity, "ParentType",
                                        GeneratorController.Current.CurrentUnit.CslaObjects.GetAllParentNames(CslaObjectType.EditableChild).ToArray()));
            list.Add(new ObjectProperty(_identity, "PropertyNameInParentType"));
            list.Add(new ObjectProperty(_identity, "ParentProperties"));
            return _identity.AssignList(list);
        }

        public static NewObjectDefaults NewEditableChildListProperties()
        {
            _identity = new NewObjectDefaults();
            var list = new List<ObjectProperty>();
            list.Add(new ObjectProperty(_identity, "CollectionName"));
            list.Add(new ObjectProperty(_identity, "ItemName"));
            list.Add(new ObjectProperty(_identity, "ParentType",
                                        GeneratorController.Current.CurrentUnit.CslaObjects.GetAllParentNames(CslaObjectType.EditableChildCollection).ToArray()));
            list.Add(new ObjectProperty(_identity, "PropertyNameInParentType"));
            list.Add(new ObjectProperty(_identity, "ParentProperties"));
            return _identity.AssignList(list);
        }

        public static NewObjectDefaults NewReadOnlyChildProperties()
        {
            _identity = new NewObjectDefaults();
            var list = new List<ObjectProperty>();
            list.Add(new ObjectProperty(_identity, "ObjectName"));
            list.Add(new ObjectProperty(_identity, "ParentType",
                                        GeneratorController.Current.CurrentUnit.CslaObjects.GetAllParentNames(CslaObjectType.ReadOnlyObject).ToArray()));
            list.Add(new ObjectProperty(_identity, "PropertyNameInParentType"));
            list.Add(new ObjectProperty(_identity, "ParentProperties"));
            return _identity.AssignList(list);
        }

        public static NewObjectDefaults NewReadOnlyChildListProperties()
        {
            _identity = new NewObjectDefaults();
            var list = new List<ObjectProperty>();
            list.Add(new ObjectProperty(_identity, "CollectionName"));
            list.Add(new ObjectProperty(_identity, "ItemName"));
            list.Add(new ObjectProperty(_identity, "ParentType",
                                        GeneratorController.Current.CurrentUnit.CslaObjects.GetAllParentNames(CslaObjectType.ReadOnlyCollection).ToArray()));
            list.Add(new ObjectProperty(_identity, "PropertyNameInParentType"));
            list.Add(new ObjectProperty(_identity, "ParentProperties"));
            return _identity.AssignList(list);
        }

        public static NewObjectDefaults NewListProperties()
        {
            _identity = new NewObjectDefaults();
            var list = new List<ObjectProperty>();
            list.Add(new ObjectProperty(_identity, "CollectionName"));
            list.Add(new ObjectProperty(_identity, "ItemName"));
            return _identity.AssignList(list);
        }

        public static NewObjectDefaults NewNVLProperties()
        {
            _identity = new NewObjectDefaults();
            var list = new List<ObjectProperty>();
            list.Add(new ObjectProperty(_identity, "CollectionName"));
            return _identity.AssignList(list);
        }

        #region Nested type: ObjectProperty

        private class ObjectProperty : INotifyPropertyChanged
        {
            private readonly NewObjectDefaults _parent;
            private readonly string _propertyName;
            private readonly string[] _valueList;
            private string _propertyValue;

            public ObjectProperty(NewObjectDefaults parent, string propertyName, string[] valueList)
            {
                _parent = parent;
                _propertyName = propertyName;
                _valueList = valueList;
            }

            public ObjectProperty(NewObjectDefaults parent, string propertyName)
                : this(parent, propertyName, new string[] { })
            {
            }

            public string[] ValueList
            {
                get { return _valueList; }
            }

            public string PropertyName
            {
                get { return _propertyName; }
            }

            public string PropertyValue
            {
                get { return _propertyValue; }
                set
                {
                    if (_propertyValue == value)
                        return;
                    _propertyValue = value;
                    OnPropertyChanged("PropertyValue");
                }
            }

            #region Implementation of INotifyPropertyChanged

            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyChanged(string propertyName)
            {
                if (propertyName == "PropertyValue" && _propertyName == "ParentType" &&
                    !string.IsNullOrEmpty(_propertyValue))
                {
                    CslaObjectInfo info = GeneratorController.Current.CurrentUnit.CslaObjects.Find(_propertyValue);
                    ValuePropertyCollection vp = info.GetAllValueProperties();
                    var properties = new string[vp.Count];
                    for (int index = 0; index < vp.Count; index++)
                    {
                        properties[index] = vp[index].Name;
                    }

                    var lstBx = _parent.tableLayoutPanel1.Controls.Find("ParentProperties", true)[0] as ListBox;
                    lstBx.Items.Clear();
                    lstBx.Items.AddRange(properties);
                }
                else if (propertyName == "PropertyValue" && _propertyName == "ParentProperties")
                {
                    var lstBox = _parent.tableLayoutPanel1.Controls.Find("ParentProperties", true)[0] as ListBox;
                    if (lstBox != null)
                        _propertyValue = lstBox.Tag.ToString();
                }
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

            #endregion
        }

        #endregion

    }
}
