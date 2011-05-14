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

        /*private NewObjectDefaults(List<ObjectProperty> list)
        {
            InitializeComponent();
            _propertyList = list;
            for (int i = 0; i < list.Count; i++)
            {
                ObjectProperty p = list[i];
                var lbl = new Label();
                lbl.Text = ValueProperty.SplitOnCaps(p.PropertyName);
                lbl.Size = new Size(165, 20);
                lbl.Padding = new Padding(3, 6, 0, 0);
                var tBox = new TextBox();
                tBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                tBox.AutoCompleteCustomSource.AddRange(p.ValueList);
                tBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                tBox.Tag = p.PropertyName;
                tBox.Dock = DockStyle.Fill;
                tBox.TabIndex = i;
                tBox.DataBindings.Add("Text", p, "PropertyValue", false, DataSourceUpdateMode.OnValidation);
                tableLayoutPanel1.Controls.Add(lbl, 0, i);
                tableLayoutPanel1.Controls.Add(tBox, 1, i);
                if (i == 0)
                    ActiveControl = tBox;
            }
        }*/

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
                if (i == 1)
                    break;
            }
            if (list.Count > 1)
            {
                for (int i = 2; i < list.Count; i++)
                {
                    ObjectProperty objectProp = list[i];
                    var lbl = new Label();
                    lbl.Text = ValueProperty.SplitOnCaps(objectProp.PropertyName);
                    lbl.Size = new Size(165, 20);
                    lbl.Padding = new Padding(3, 6, 0, 0);
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
            }
            return this;
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

        public static NewObjectDefaults NewReadOnlyChildListProperties()
        {
            _identity = new NewObjectDefaults();
            var list = new List<ObjectProperty>();
            list.Add(new ObjectProperty(_identity, "CollectionName"));
            list.Add(new ObjectProperty(_identity, "ItemName"));
            list.Add(new ObjectProperty(_identity, "ParentType",
                                        GeneratorController.Current.CurrentUnit.CslaObjects.GetAllParentNames(CslaObjectType.ReadOnlyCollection).ToArray()));
            list.Add(new ObjectProperty(_identity, "PropertyNameInParentType"));
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
            return _identity.AssignList(list);
        }

        public static NewObjectDefaults NewReadOnlyListProperties()
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
                : this(parent, propertyName, new string[] {})
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

                    var combo = _parent.tableLayoutPanel1.Controls.Find("PropertyNameInParentType", true)[0] as ComboBox;
                    combo.Items.AddRange(properties);
                    combo.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

            #endregion
        }

        #endregion
    }
}