using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CslaGenerator.Metadata;
namespace CslaGenerator.Controls
{
    public partial class NewObjectDefaults : Form
    {
        public NewObjectDefaults()
        {
            InitializeComponent();
        }


        private List<ObjectProperty> _propertyList;
        private class ObjectProperty
        {
            private string _propertyName;
            private string _propertyValue;
            private string[] _valueList;
            public string[] ValueList
            {
                get
                {
                    return _valueList;
                }
            }
            public string PropertyName
            {
                get { return _propertyName; }
            }
            public string PropertyValue
            {
                get { return _propertyValue; }
                set { _propertyValue = value; }
            }

            public ObjectProperty(string propertyName, string[] valueList)
            {
                _propertyName = propertyName;
                _valueList = valueList;
            }
            public ObjectProperty(string propertyName)
                : this(propertyName, new string[] { })
            {
            }
        }
        NewObjectDefaults(List<ObjectProperty> list)
        {
            InitializeComponent();
            _propertyList = list;
            for (int i = 0; i < list.Count; i++)
            {
                ObjectProperty p = list[i];
                Label lbl = new Label();
                lbl.Text = ValueProperty.SplitOnCaps(p.PropertyName);
                TextBox tBox = new TextBox();
                tBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                tBox.AutoCompleteCustomSource.AddRange(p.ValueList);
                tBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                tBox.Tag = p.PropertyName;
                tBox.Width = 300;
                tBox.TabIndex = i;
                tBox.DataBindings.Add("Text", p, "PropertyValue", false, DataSourceUpdateMode.OnPropertyChanged);
                tableLayoutPanel1.Controls.Add(lbl, 0, i);
                tableLayoutPanel1.Controls.Add(tBox, 1, i);
                if (i == 0)
                    ActiveControl = tBox;
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
        public static NewObjectDefaults NewChildListProperties()
        {
            List<ObjectProperty> list = new List<ObjectProperty>();
            list.Add(new ObjectProperty("CollectionName"));
            list.Add(new ObjectProperty("ItemName"));
            list.Add(new ObjectProperty("ParentType", GeneratorController.Current.CurrentUnit.CslaObjects.GetAllObjectNames().ToArray()));
            list.Add(new ObjectProperty("PropertyNameInParentType"));
            return new NewObjectDefaults(list);
        }

        public static NewObjectDefaults NewReadOnlyListProperties()
        {
            List<ObjectProperty> list = new List<ObjectProperty>();
            list.Add(new ObjectProperty("CollectionName"));
            list.Add(new ObjectProperty("ItemName"));
            return new NewObjectDefaults(list);
        }
        public static NewObjectDefaults NewNVLProperties()
        {
            List<ObjectProperty> list = new List<ObjectProperty>();
            list.Add(new ObjectProperty("CollectionName"));
            return new NewObjectDefaults(list);
        }
    }
}