using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Controls
{
    public partial class NewObjectProperties : Form
    {
        private static NewObjectProperties _identity;
        private List<ObjectProperty> _propertyList;

        public NewObjectProperties()
        {
            InitializeComponent();
        }

        private NewObjectProperties AssignList(List<ObjectProperty> list)
        {
            _propertyList = list;
            for (int i = 0; i < list.Count; i++)
            {
                var objectProp = list[i];
                var lbl = new Label();
                lbl.Text = PropertyHelper.SplitOnCaps(objectProp.PropertyName);
                lbl.Size = new Size(165, 20);
                lbl.Padding = new Padding(3, 6, 0, 0);
                if (objectProp.PropertyName == "ParentType")
                {
                    var combo = new ComboBox();
                    combo.Name = objectProp.PropertyName;
                    combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    combo.Items.AddRange(objectProp.ResultValueList);
                    combo.AutoCompleteSource = AutoCompleteSource.ListItems;
                    combo.Tag = objectProp.PropertyName;
                    combo.Dock = DockStyle.Fill;
                    combo.TabIndex = i;
                    combo.DataBindings.Add("Text", objectProp, "PropertyValue", false, DataSourceUpdateMode.OnValidation);
                    tableLayoutPanel.Controls.Add(lbl, 0, i);
                    tableLayoutPanel.Controls.Add(combo, 1, i);
                }
                else if (objectProp.PropertyName == "ParentProperties")
                {
                    var lstBox = new ListBox();
                    lstBox.Enabled = false;
                    lstBox.Name = objectProp.PropertyName;
                    lstBox.Items.AddRange(objectProp.ResultValueList);
                    lstBox.Tag = objectProp.PropertyName;
                    lstBox.Dock = DockStyle.Fill;
                    lstBox.TabIndex = i;
                    lstBox.DataBindings.Add("SelectedItem", objectProp, "PropertyValue", false, DataSourceUpdateMode.OnValidation);
                    lstBox.SelectionMode = SelectionMode.MultiExtended;
                    lstBox.Validating += ListBox_Validating;
                    tableLayoutPanel.Controls.Add(lbl, 0, i);
                    tableLayoutPanel.Controls.Add(lstBox, 1, i);
                }
                else
                {
                    var tBox = new TextBox();
                    tBox.Name = objectProp.PropertyName;
                    tBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tBox.AutoCompleteCustomSource.AddRange(objectProp.ResultValueList);
                    tBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    tBox.Tag = objectProp.PropertyName;
                    tBox.Dock = DockStyle.Fill;
                    tBox.TabIndex = i;
                    tBox.DataBindings.Add("Text", objectProp, "PropertyValue", false, DataSourceUpdateMode.OnValidation);
                    tableLayoutPanel.Controls.Add(lbl, 0, i);
                    tableLayoutPanel.Controls.Add(tBox, 1, i);
                    if (i == 0)
                        ActiveControl = tBox;
                }
            }

            return this;
        }

        private static void ListBox_Validating(object sender, CancelEventArgs e)
        {
            var lstBox = sender as ListBox;
            var parentProps = string.Empty;
            if (lstBox != null)
            {
                var first = true;
                foreach (var item in lstBox.SelectedItems)
                {
                    if (!first) parentProps += ",";
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

        public static NewObjectProperties NewEditableChildProperties()
        {
            _identity = new NewObjectProperties();
            _identity.Text = @"New Editable Child Properties";
            var list = new List<ObjectProperty>();
            list.Add(new ObjectProperty(_identity, "ObjectName"));
            list.Add(new ObjectProperty(_identity, "ParentType",
                                        GeneratorController.Current.CurrentUnit.CslaObjects.GetAllParentNames(CslaObjectType.EditableChildCollection).ToArray()));
            list.Add(new ObjectProperty(_identity, "PropertyNameInParentType"));
            list.Add(new ObjectProperty(_identity, "ParentProperties"));
            return _identity.AssignList(list);
        }

        public static NewObjectProperties NewEditableChildListProperties()
        {
            _identity = new NewObjectProperties();
            _identity.Text = @"New Editable Child Collection Properties";
            var list = new List<ObjectProperty>();
            list.Add(new ObjectProperty(_identity, "CollectionName"));
            list.Add(new ObjectProperty(_identity, "ItemName"));
            list.Add(new ObjectProperty(_identity, "ParentType",
                                        GeneratorController.Current.CurrentUnit.CslaObjects.GetAllParentNames(CslaObjectType.EditableChildCollection).ToArray()));
            list.Add(new ObjectProperty(_identity, "PropertyNameInParentType"));
            list.Add(new ObjectProperty(_identity, "ParentProperties"));
            return _identity.AssignList(list);
        }

        public static NewObjectProperties NewReadOnlyChildProperties()
        {
            _identity = new NewObjectProperties();
            _identity.Text = @"New Read Only Child Object Properties";
            var list = new List<ObjectProperty>();
            list.Add(new ObjectProperty(_identity, "ObjectName"));
            list.Add(new ObjectProperty(_identity, "ParentType",
                                        GeneratorController.Current.CurrentUnit.CslaObjects.GetAllParentNames(CslaObjectType.ReadOnlyCollection).ToArray()));
            list.Add(new ObjectProperty(_identity, "PropertyNameInParentType"));
            list.Add(new ObjectProperty(_identity, "ParentProperties"));
            return _identity.AssignList(list);
        }

        public static NewObjectProperties NewReadOnlyChildListProperties()
        {
            _identity = new NewObjectProperties();
            _identity.Text = @"New Read Only Child Collection Properties";
            var list = new List<ObjectProperty>();
            list.Add(new ObjectProperty(_identity, "CollectionName"));
            list.Add(new ObjectProperty(_identity, "ItemName"));
            list.Add(new ObjectProperty(_identity, "ParentType",
                                        GeneratorController.Current.CurrentUnit.CslaObjects.GetAllParentNames(CslaObjectType.ReadOnlyCollection).ToArray()));
            list.Add(new ObjectProperty(_identity, "PropertyNameInParentType"));
            list.Add(new ObjectProperty(_identity, "ParentProperties"));
            return _identity.AssignList(list);
        }

        public static NewObjectProperties NewRootListProperties(string objectType)
        {
            _identity = new NewObjectProperties();
            _identity.Text = @"New " + objectType + @" Properties";
            var list = new List<ObjectProperty>();
            list.Add(new ObjectProperty(_identity, "CollectionName"));
            list.Add(new ObjectProperty(_identity, "ItemName"));
            return _identity.AssignList(list);
        }

        public static NewObjectProperties NewRootObjectProperties(string objectType)
        {
            _identity = new NewObjectProperties();
            _identity.Text = @"New " + objectType + @" Properties";
            var list = new List<ObjectProperty>();
            list.Add(new ObjectProperty(_identity, "ObjectName"));
            return _identity.AssignList(list);
        }

        public static NewObjectProperties NewNVLProperties()
        {
            _identity = new NewObjectProperties();
            _identity.Text = @"New Name Value List Properties";
            var list = new List<ObjectProperty>();
            list.Add(new ObjectProperty(_identity, "CollectionName"));
            return _identity.AssignList(list);
        }

        #region Nested type: ObjectProperty

        private class ObjectProperty : INotifyPropertyChanged
        {
            private readonly NewObjectProperties _parent;
            private readonly string _propertyName;
            private readonly string[] _resultValueList;
            private string _propertyValue;

            public ObjectProperty(NewObjectProperties parent, string propertyName, string[] resultValueList)
            {
                _parent = parent;
                _propertyName = propertyName;
                _resultValueList = resultValueList;
            }

            public ObjectProperty(NewObjectProperties parent, string propertyName)
                : this(parent, propertyName, new string[] { })
            {
            }

            public string[] ResultValueList
            {
                get { return _resultValueList; }
            }

            public string PropertyName
            {
                get { return _propertyName; }
            }

            public string PropertyValue
            {
                get
                {
                    if (_propertyName == "ParentProperties")
                    {
                        var lstBox = _parent.tableLayoutPanel.Controls.Find("ParentProperties", true)[0] as ListBox;
                        if (lstBox != null)
                            return lstBox.Tag.ToString();
                    }

                    return _propertyValue;
                }
                // ReSharper disable UnusedMember.Local
                set
                // ReSharper restore UnusedMember.Local
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
                    var parentInfo = GeneratorController.Current.CurrentUnit.CslaObjects.Find(_propertyValue);
                    var lstBox = _parent.tableLayoutPanel.Controls.Find("ParentProperties", true)[0] as ListBox;
                    if (lstBox != null)
                    {
                        lstBox.Items.Clear();

                        if (parentInfo.ObjectType.IsCollectionType())
                        {
                            lstBox.Enabled = false;
                        }
                        else
                        {
                            lstBox.Enabled = true;

                            var valProps = parentInfo.GetAllValueProperties();
                            foreach (var prop in valProps)
                                lstBox.Items.Add(prop.Name);

                            var first = true;
                            var parentProps = string.Empty;
                            foreach (var prop in parentInfo.ValueProperties)
                            {
                                if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
                                {
                                    lstBox.SelectedItems.Add(prop.Name);
                                    if (!first) parentProps += ",";
                                    else first = false;
                                    parentProps += prop.Name;
                                }
                            }

                            lstBox.Tag = parentProps;
                        }
                    }
                }

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

            #endregion

        }

        #endregion

    }
}
