using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using CslaGenerator.Metadata;
using CslaGenerator.Util;
using CslaGenerator.Util.PropertyBags;

namespace CslaGenerator.Design
{
    /// <summary>
    /// A custom collection editor using the PropertyGrid control.
    /// </summary>
    /// <remarks>
    /// NOTE - Set here form height and width.
    /// </remarks>
    public class PropertyCollectionForm : CollectionEditor
    {
        //http://social.msdn.microsoft.com/forums/en-us/winforms/thread/488CEDB4-B8CE-457C-B550-E3738752A1CA

        private CollectionForm _form;
        private PropertyGrid _propGrid;
        private Type _collectionType;
        private readonly Dictionary<string, Button> _exitButton = new Dictionary<string, Button>();
        private static string _parentValProp = string.Empty;
        private static string _parentProperty;

        public static string ParentValProp
        {
            get { return _parentValProp; }
            set { _parentValProp = value; }
        }

        public static string ParentProperty
        {
            get { return _parentProperty; }
            set { _parentProperty = value; }
        }

        #region Constructor

        /// <summary>
        /// Creates a new instance of the <see cref="PropertyCollectionForm"/> class
        /// </summary>
        /// <param name="type"></param>
        public PropertyCollectionForm(Type type)
            : base(type) { }

        #endregion

        #region Protected Overridden Methods

        /// <summary>
        /// Creates a new CollectionForm to display the collection editor
        /// </summary>
        /// <remarks>
        /// This methods uses reflection to access non-public fields/properties within the CollectionForm.
        /// This method can also be used to alter other visual aspects of the Form.
        /// </remarks>
        /// <returns>CollectionForm</returns>
        protected override CollectionForm CreateCollectionForm()
        {
            _form = base.CreateCollectionForm();

            HandleFormCollectionType();

            // hook events for expanding Criteria properties hierarchy
            if (_collectionType == typeof (Criteria))
            {
                foreach (Control control in _form.Controls)
                {
                    if (control is TableLayoutPanel)
                    {
                        foreach (var panelControl in control.Controls)
                        {
                            if (panelControl is ListBox)
                            {
                                ((ListBox) panelControl).SelectedIndexChanged += OnIndexChanged;
                            }
                            else if (panelControl is TableLayoutPanel)
                            {
                                var layoutPanel = (TableLayoutPanel) panelControl;
                                foreach (var tableControl in layoutPanel.Controls)
                                {
                                    if (tableControl is Button)
                                    {
                                        var button = (Button) tableControl;
                                        if (button.Text.IndexOf("Add", StringComparison.InvariantCulture) > 0 ||
                                            button.Text.IndexOf("Remove", StringComparison.InvariantCulture) > 0)
                                            button.Click += OnItemAddedOrRemoved;
                                    }
                                }
                            }
                            else if (panelControl is PropertyGrid)
                            {
                                ((PropertyGrid) panelControl).SelectedGridItemChanged += OnGridItemChanged;
                            }
                        }
                    }
                }
            }
            else if (_collectionType == typeof(ValueProperty) || _collectionType == typeof(ChildProperty))
            {
                foreach (Control control in _form.Controls)
                {
                    if (control is TableLayoutPanel)
                    {
                        foreach (var panelControl in control.Controls)
                        {
                            if (panelControl is PropertyGrid)
                            {
                                ((PropertyGrid) panelControl).SelectedGridItemChanged += OnGridItemChangedProperty;
                            }
                            
                            if (panelControl is TableLayoutPanel)
                            {
                                var layoutPanel = (TableLayoutPanel)panelControl;
                                if (layoutPanel.Name == "okCancelTableLayoutPanel")
                                {
                                    foreach (var tableControl in layoutPanel.Controls)
                                    {
                                        if (tableControl is Button)
                                        {
                                            var button = (Button) tableControl;
                                            if (button.Name == "cancelButton" || button.Name == "okButton")
                                            {
                                                _exitButton[button.Name] = button;
                                                button.Click += ExitButtonClickHandler;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            /*else if (_collectionType == typeof (BusinessRuleProperty))
            {
                // hide Add & Remove buttons
                foreach (Control control in _form.Controls)
                {
                    if (control is TableLayoutPanel)
                    {
                        foreach (var panelControl in control.Controls)
                        {
                            if (panelControl is TableLayoutPanel)
                            {
                                var layoutPanel = (TableLayoutPanel) panelControl;
                                foreach (var tableControl in layoutPanel.Controls)
                                {
                                    if (tableControl is Button)
                                    {
                                        var button = (Button) tableControl;
                                        if (button.Text.IndexOf("Add") > 0 || button.Text.IndexOf("Remove") > 0)
                                        {
                                            button.Hide();
                                            button.Enabled = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }*/
            else if (_collectionType == typeof(BusinessRuleConstructor))
            {
                // hide Add & Remove buttons
                foreach (Control control in _form.Controls)
                {
                    if (control is TableLayoutPanel)
                    {
                        foreach (var panelControl in control.Controls)
                        {
                            if (panelControl is TableLayoutPanel)
                            {
                                var layoutPanel = (TableLayoutPanel)panelControl;
                                if (layoutPanel.Name == "addRemoveTableLayoutPanel")
                                {
                                    foreach (var tableControl in layoutPanel.Controls)
                                    {
                                        if (tableControl is Button)
                                        {
                                            var button = (Button) tableControl;
                                            if (button.Name == "addButton" || button.Name == "removeButton")
                                            {
                                                button.Hide();
                                                button.Enabled = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            var formType = _form.GetType();

            //Get a reference to the private fieldtype propertyBrowser
            //This is the PropertGrid inside the CollectionForm
            var fieldInfo = formType.GetField("propertyBrowser", BindingFlags.NonPublic | BindingFlags.Instance);

            if (fieldInfo != null)
            {
                _propGrid = (PropertyGrid) fieldInfo.GetValue(_form);

                if (_propGrid != null)
                {
                    _propGrid.ToolbarVisible = true;
                    _propGrid.HelpVisible = true;
                    _propGrid.PropertySort = PropertySort.Categorized;
                    _propGrid.PropertySortChanged += OnSort;
                    _propGrid.SelectedObjectsChanged += OnSelect;

                    /*//Get the property grid's type.
                    //This is a vsPropertyGrid located in System.Windows.Forms.Design
                    Type propertyGridType = _propGrid.GetType();

                    //Get a reference to the non-public property ToolStripRenderer
                    PropertyInfo propertyInfo = propertyGridType.GetProperty("ToolStripRenderer", BindingFlags.NonPublic | BindingFlags.Instance);

                    if (propertyInfo != null)
                    {
                        //Assign a ToolStripProfessionalRenderer with our custom color table
                        propertyInfo.SetValue(_propGrid, new ToolStripProfessionalRenderer(new CustomColorTable()), null);
                    }*/
                }
            }
            _form.Shown += OnFormShow;

            return _form;
        }

        private void ExitButtonClickHandler(object sender, EventArgs e)
        {
            _parentValProp = string.Empty;
            DetachExitButtonClickHandler();
        }

        private void DetachExitButtonClickHandler()
        {
            foreach (var button in _exitButton)
            {
                button.Value.Click -= ExitButtonClickHandler;
            }
        }

        public void OnSelect(object sender, EventArgs e)
        {
            _propGrid.SelectedObjectsChanged -= OnSelect;

            if (_collectionType == typeof (ValueProperty))
            {
                var selectedObject = (ValueProperty) _propGrid.SelectedObject;
                //Get the property grid's type.
                //This is a vsPropertyGrid located in System.Windows.Forms.Design
                var propertyInfo = _propGrid.GetType().GetProperty("SelectedObject", BindingFlags.Public | BindingFlags.Instance);
                if (selectedObject != null)
                {
                    propertyInfo.SetValue(_propGrid, new ValuePropertyBag(selectedObject), null);
                    _parentValProp = selectedObject.Name;
                }
            }
            else if (_collectionType == typeof (ChildProperty))
            {
                var selectedObject = (ChildProperty) _propGrid.SelectedObject;
                //Get the property grid's type.
                //This is a vsPropertyGrid located in System.Windows.Forms.Design
                var propertyInfo = _propGrid.GetType().GetProperty("SelectedObject", BindingFlags.Public | BindingFlags.Instance);
                if (selectedObject != null)
                {
                    propertyInfo.SetValue(_propGrid, new ChildPropertyBag(selectedObject), null);
                    _parentValProp = selectedObject.Name;
                }
            }
            else if (_collectionType == typeof (UnitOfWorkProperty))
            {
                var selectedObject = (UnitOfWorkProperty) _propGrid.SelectedObject;
                //Get the property grid's type.
                //This is a vsPropertyGrid located in System.Windows.Forms.Design
                var propertyInfo = _propGrid.GetType().GetProperty("SelectedObject", BindingFlags.Public | BindingFlags.Instance);
                if (selectedObject != null)
                    propertyInfo.SetValue(_propGrid, new UnitOfWorkPropertyBag(selectedObject), null);
            }
            else if (_collectionType == typeof (Criteria))
            {
                var selectedObject = (Criteria) _propGrid.SelectedObject;
                //Get the property grid's type.
                //This is a vsPropertyGrid located in System.Windows.Forms.Design
                var propertyInfo = _propGrid.GetType().GetProperty("SelectedObject", BindingFlags.Public | BindingFlags.Instance);
                if (selectedObject != null)
                    propertyInfo.SetValue(_propGrid, new CriteriaBag(selectedObject), null);
            }
            else if (_collectionType == typeof (CriteriaProperty))
            {
                var selectedObject = (CriteriaProperty) _propGrid.SelectedObject;
                //Get the property grid's type.
                //This is a vsPropertyGrid located in System.Windows.Forms.Design
                var propertyInfo = _propGrid.GetType().GetProperty("SelectedObject", BindingFlags.Public | BindingFlags.Instance);
                if (selectedObject != null)
                    propertyInfo.SetValue(_propGrid, new CriteriaPropertyBag(selectedObject), null);
            }
            else if (_collectionType == typeof (ConvertValueProperty))
            {
                var selectedObject = (ConvertValueProperty) _propGrid.SelectedObject;
                //Get the property grid's type.
                //This is a vsPropertyGrid located in System.Windows.Forms.Design
                var propertyInfo = _propGrid.GetType().GetProperty("SelectedObject", BindingFlags.Public | BindingFlags.Instance);
                if (selectedObject != null)
                {
                    propertyInfo.SetValue(_propGrid, new ConvertValuePropertyBag(selectedObject), null);
                    _parentValProp = selectedObject.Name;
                }
            }
            else if (_collectionType == typeof (UpdateValueProperty))
            {
                var selectedObject = (UpdateValueProperty) _propGrid.SelectedObject;
                //Get the property grid's type.
                //This is a vsPropertyGrid located in System.Windows.Forms.Design
                var propertyInfo = _propGrid.GetType().GetProperty("SelectedObject", BindingFlags.Public | BindingFlags.Instance);
                if (selectedObject != null)
                    propertyInfo.SetValue(_propGrid, new UpdateValuePropertyBag(selectedObject), null);
            }
            else if (_collectionType == typeof(BusinessRule))
            {
                var selectedObject = (BusinessRule) _propGrid.SelectedObject;
                //Get the property grid's type.
                //This is a vsPropertyGrid located in System.Windows.Forms.Design
                var propertyInfo = _propGrid.GetType().GetProperty("SelectedObject", BindingFlags.Public | BindingFlags.Instance);
                if (selectedObject != null)
                {
                    if (!string.IsNullOrEmpty(ParentValProp))
                    {
                        selectedObject.IsPropertyRule = true;
                        selectedObject.Parent = _parentValProp;
                    }
                    else
                    {
                        selectedObject.IsPropertyRule= false;
                        selectedObject.Parent = string.Empty;
                    }
                    
                    propertyInfo.SetValue(_propGrid, new BusinessRuleBag(selectedObject), null);

                    var ruleCount = 0;
                    var baseCount = 0;
                    var heightIncrease = 0;
                    var rules = ((BusinessRuleBag) _propGrid.SelectedObject).SelectedObject;
                    foreach (var businessRule in rules)
                    {
                        ruleCount = businessRule.RuleProperties.Count;
                        if (ruleCount > 0)
                            heightIncrease = 16 + (ruleCount*16);

                        baseCount = businessRule.BaseRuleProperties.Count;
                        if (baseCount > 0)
                            heightIncrease += 16 + (baseCount*16);

                        if (ruleCount == 0 && baseCount == 0)
                        {
                            if (_form.Size.Height != 330)
                                _form.Size = new Size(_form.Size.Width, 330);
                        }
                        else
                        {
                            if (_form.Size.Height != 306 + heightIncrease)
                                _form.Size = new Size(_form.Size.Width, 306 + heightIncrease);
                        }
                    }
                }
            }
            else if (_collectionType == typeof(BusinessRuleConstructor))
            {
                var selectedObject = (BusinessRuleConstructor)_propGrid.SelectedObject;
                //Get the property grid's type.
                //This is a vsPropertyGrid located in System.Windows.Forms.Design
                var propertyInfo = _propGrid.GetType().GetProperty("SelectedObject", BindingFlags.Public | BindingFlags.Instance);
                if (selectedObject != null)
                {
                    //selectedObject.Parent = _parentValProp;
                    propertyInfo.SetValue(_propGrid, new BusinessRuleConstructorBag(selectedObject), null);

                    var parameterCount = 0;
                    var genericCount = 0;
                    var heightIncrease = 0;
                    var constructors = ((BusinessRuleConstructorBag)_propGrid.SelectedObject).SelectedObject;
                    foreach (var constructor in constructors)
                    {
                        parameterCount = constructor.ConstructorParameters.Count;
                        heightIncrease = parameterCount * 16;

                        foreach (var parameter in constructor.ConstructorParameters)
                        {
                            if (parameter.IsGenericType)
                                genericCount++;
                        }
                        if (genericCount > 0)
                            heightIncrease += 16 + (genericCount * 16);

                        if (parameterCount == 0 && genericCount == 0)
                        {
                            if (_form.Size.Height != 330)
                                _form.Size = new Size(_form.Size.Width, 330);
                        }
                        else
                        {
                            if (_form.Size.Height != 274 + heightIncrease)
                                _form.Size = new Size(_form.Size.Width, 274 + heightIncrease);
                        }
                    }
                }
            }
            /*else if (_collectionType == typeof(BusinessRuleProperty))
            {
                var selectedObject = (BusinessRuleProperty)_propGrid.SelectedObject;
                //Get the property grid's type.
                //This is a vsPropertyGrid located in System.Windows.Forms.Design
                var propertyInfo = _propGrid.GetType().GetProperty("SelectedObject", BindingFlags.Public | BindingFlags.Instance);
                if (selectedObject != null)
                    propertyInfo.SetValue(_propGrid, new BusinessRulePropertyBag(selectedObject), null);
            }
            else if (_collectionType == typeof(BusinessRuleParameter))
            {
                var selectedObject = (BusinessRuleParameter)_propGrid.SelectedObject;
                //Get the property grid's type.
                //This is a vsPropertyGrid located in System.Windows.Forms.Design
                var propertyInfo = _propGrid.GetType().GetProperty("SelectedObject", BindingFlags.Public | BindingFlags.Instance);
                if (selectedObject != null)
                    propertyInfo.SetValue(_propGrid, new BusinessRuleParameterBag(selectedObject), null);
            }*/

            _propGrid.Layout += pgEditor_Layout;

            _propGrid.SelectedObjectsChanged += OnSelect;
        }

        #endregion

        private void HandleFormCollectionType()
        {
            ((ListBox) _form.Controls[0].Controls[4]).SelectionMode = SelectionMode.One;
            var formScreen = Screen.FromControl(_form);
            var height = formScreen.WorkingArea.Height;
            var cslaObject = (CslaObjectInfo) GeneratorController.Current.GetSelectedItem();

            switch (_form.Text)
            {
                case "ValueProperty Collection Editor":
                    _form.Size = new Size(570, _form.Size.Height);
                    _collectionType = typeof(ValueProperty);
                    if (GeneratorController.Current.CurrentUnit.GenerationParams.GenerateAuthorization ==
                        AuthorizationLevel.None ||
                        GeneratorController.Current.CurrentUnit.GenerationParams.GenerateAuthorization ==
                        AuthorizationLevel.ObjectLevel)
                        _form.Size = new Size(_form.Size.Width, 658);
                    else
                    {
                        _form.Size = new Size(_form.Size.Width, 706);
                        if (GeneratorController.Current.CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider)
                            _form.Size = new Size(_form.Size.Width, _form.Size.Height - 16);
                    }
                    if (cslaObject.IsNameValueList())
                        _form.Size = new Size(_form.Size.Width, 626);
                    else if (cslaObject.IsNotDbConsumer())
                        _form.Size = new Size(_form.Size.Width, _form.Size.Height - 96);
                    _form.Size = new Size(_form.Size.Width, _form.Size.Height - 16);
                    if (height < _form.Size.Height)
                        _form.Size = new Size(_form.Size.Width, height);
                    break;
                case "ChildProperty Collection Editor":
                    _form.Size = new Size(586, _form.Size.Height);
                    _collectionType = typeof(ChildProperty);
                    if (GeneratorController.Current.CurrentUnit.GenerationParams.GenerateAuthorization ==
                        AuthorizationLevel.None ||
                        GeneratorController.Current.CurrentUnit.GenerationParams.GenerateAuthorization ==
                        AuthorizationLevel.ObjectLevel)
                        _form.Size = new Size(_form.Size.Width, 578);
                    else
                    {
                        _form.Size = new Size(_form.Size.Width, 626);
                        if (GeneratorController.Current.CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider)
                            _form.Size = new Size(_form.Size.Width, _form.Size.Height - 16);
                    }
                    if (height < _form.Size.Height)
                        _form.Size = new Size(_form.Size.Width, height);
                    break;
                case "UnitOfWorkProperty Collection Editor":
                    _form.Size = new Size(570, _form.Size.Height);
                    _collectionType = typeof(UnitOfWorkProperty);
                    _form.Size = new Size(_form.Size.Width, 354);
                    break;
                case "Criteria Collection Editor":
                    _form.Size = new Size(550, _form.Size.Height);
                    _collectionType = typeof(Criteria);
                    _form.Size = new Size(_form.Size.Width, 738);
                    if (cslaObject.IsReadOnlyObject() ||
                        cslaObject.IsReadOnlyCollection() ||
                        cslaObject.IsNameValueList())
                        _form.Size = new Size(_form.Size.Width, _form.Size.Height - 256);
                    if (cslaObject.IsEditableChild())
                        _form.Size = new Size(_form.Size.Width, _form.Size.Height - 128);
                    if (height < _form.Size.Height)
                        _form.Size = new Size(_form.Size.Width, height);
                    break;
                case "CriteriaProperty Collection Editor":
                    _collectionType = typeof(CriteriaProperty);
                    _form.Size = new Size(_form.Size.Width, 402);
                    if (GeneratorController.Current.CurrentUnit.GenerationParams.TargetIsCsla4DAL &&
                        cslaObject.UsesInlineQuery)
                        _form.Size = new Size(_form.Size.Width, _form.Size.Height + 16);
                    break;
                case "ConvertValueProperty Collection Editor":
                    _form.Size = new Size(570, _form.Size.Height);
                    _collectionType = typeof(ConvertValueProperty);
                    _form.Size = new Size(_form.Size.Width, 546);
                    _form.Size = new Size(_form.Size.Width, _form.Size.Height - 16);
                    break;
                case "UpdateValueProperty Collection Editor":
                    //_form.Size = new Size(550, _form.Size.Height);
                    _form.Size = new Size(550, 330);
                    _collectionType = typeof(UpdateValueProperty);
                    break;
                case "BusinessRule Collection Editor":
                    _form.Size = new Size(650, 330);
                    _collectionType = typeof(BusinessRule);
                    break;
                case "BusinessRuleConstructor Collection Editor":
                    _form.Size = new Size(550, 330);
                    _collectionType = typeof(BusinessRuleConstructor);
                    break;
                /*case "BusinessRuleProperty Collection Editor":
                    _form.Size = new Size(550, 569);
                    _collectionType = typeof(BusinessRuleProperty);
                    break;
                case "BusinessRuleParameter Collection Editor":
                    _form.Size = new Size(550, 569);
                    _collectionType = typeof(BusinessRuleConstructorParameter);
                    break;*/
            }
        }

        public void OnGridItemChangedProperty(object sender, SelectedGridItemChangedEventArgs e)
        {
            _parentProperty = e.NewSelection.Label;
        }

        public void OnGridItemChanged(object sender, EventArgs e)
        {
            _propGrid.ExpandAllGridItems();
        }

        public void OnIndexChanged(object sender, EventArgs e)
        {
            _propGrid.ExpandAllGridItems();
        }

        public void OnItemAddedOrRemoved(object sender, EventArgs e)
        {
            _propGrid.ExpandAllGridItems();
        }

        public void OnSort(object sender, EventArgs e)
        {
            if (_propGrid.PropertySort == PropertySort.CategorizedAlphabetical)
                _propGrid.PropertySort = PropertySort.Categorized;
        }

        public void OnFormShow(object sender, EventArgs e)
        {
            var maxHeight = Screen.PrimaryScreen.WorkingArea.Height;

            if (_collectionType == typeof (Criteria))
                _propGrid.ExpandAllGridItems();

            _form.StartPosition = FormStartPosition.CenterParent;

            if ((_form.Bounds.Y + _form.Bounds.Height) > maxHeight)
            {
                _form.StartPosition = FormStartPosition.Manual;
                var hDiff = maxHeight - _form.Bounds.Height;
                if (hDiff == 0)
                    hDiff = 0;
                else
                    hDiff = hDiff/2;

                _form.Bounds = new Rectangle(_form.Bounds.X, hDiff, _form.Bounds.Width, _form.Bounds.Height);
            }

            pgEditor_Layout(this, new LayoutEventArgs(_propGrid, "gridView"));
        }

        private void pgEditor_Layout(object sender, LayoutEventArgs e)
        {
            var gridItem = _propGrid.SelectedGridItem;
            if (gridItem == null)
                return;

            while (gridItem.Parent != null)
            {
                gridItem = gridItem.Parent;
            }
            var r = 0;
            GetLongest(gridItem.GridItems, ref r);

            //http: //www.dotnetmonster.com/Uwe/Forum.aspx/winform-controls/5624/Using-the-PropertyGrid-Control

            FieldInfo fi = typeof (PropertyGrid).GetField("gridView", BindingFlags.Instance | BindingFlags.NonPublic);
            object propertyGridView = fi.GetValue(_propGrid);

            _propGrid.AutoSize = false;

            MethodInfo mi = propertyGridView.GetType().GetMethod("MoveSplitterTo", BindingFlags.NonPublic | BindingFlags.Instance);
            mi.Invoke(propertyGridView, new object[] {r + 20});
        }

        private void GetLongest(GridItemCollection col, ref int r)
        {
            foreach (GridItem item in col)
            {
                if (item.GridItemType != GridItemType.Category)
                    r = Math.Max(r, TextRenderer.MeasureText(item.Label, _propGrid.Font).Width);
                if (item.Expanded)
                {
                    GetLongest(item.GridItems, ref r);
                }
            }
        }
    }
}
