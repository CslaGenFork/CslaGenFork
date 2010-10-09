using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    /// <summary>
    /// A custom collection editor that emulates the
    /// </summary>
    public class PropertyCollectionForm : CollectionEditor
    {
        //http://social.msdn.microsoft.com/forums/en-us/winforms/thread/488CEDB4-B8CE-457C-B550-E3738752A1CA

        private CollectionForm _form;
        private PropertyGrid _propGrid;
        private Type _collectionType;

        #region Constructors

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
        /// This methods uses reflection to access non-public fields/properties within the collectionform.
        /// This method can also be used to alter other visual aspects of the form.
        /// </remarks>
        /// <returns>CollectionForm</returns>
        protected override CollectionForm CreateCollectionForm()
        {
            _form = base.CreateCollectionForm();

            HandleFormCollectionType();

            // hook events for expanding Criteria properties hierarchy
            if (_collectionType == typeof(Criteria))
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
                            if (panelControl is TableLayoutPanel)
                            {
                                var layoutPanel = (TableLayoutPanel) panelControl;
                                foreach (var tableControl in layoutPanel.Controls)
                                {
                                    if (tableControl is Button)
                                    {
                                        var button = (Button) tableControl;
                                        if (button.Text.IndexOf("Add") > 0 || button.Text.IndexOf("Remove") > 0)
                                            button.Click += OnItemAddedOrRemoved;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            var formType = _form.GetType();

            //Get a reference to the private fieldtype propertyBrowser
            //This is the propertgrid inside the collectionform
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

        public void OnSelect(object sender, EventArgs e)
        {
            _propGrid.SelectedObjectsChanged -= OnSelect;

            if (_collectionType == typeof(ValueProperty))
            {
                var selectedObject = (ValueProperty)_propGrid.SelectedObject;
                //Get the property grid's type.
                //This is a vsPropertyGrid located in System.Windows.Forms.Design
                var propertyInfo = _propGrid.GetType().GetProperty("SelectedObject", BindingFlags.Public | BindingFlags.Instance);
                if (selectedObject != null)
                    propertyInfo.SetValue(_propGrid, new ValuePropertyBag(selectedObject), null);
            }
            else if (_collectionType == typeof(ChildProperty))
            {
                var selectedObject = (ChildProperty)_propGrid.SelectedObject;
                //Get the property grid's type.
                //This is a vsPropertyGrid located in System.Windows.Forms.Design
                var propertyInfo = _propGrid.GetType().GetProperty("SelectedObject", BindingFlags.Public | BindingFlags.Instance);
                if (selectedObject != null)
                    propertyInfo.SetValue(_propGrid, new ChildPropertyBag(selectedObject), null);
            }
            /*else if (_collectionType == typeof(Criteria))
            {
                var selectedObject = (Criteria)_propGrid.SelectedObject;
                //Get the property grid's type.
                //This is a vsPropertyGrid located in System.Windows.Forms.Design
                var propertyInfo = _propGrid.GetType().GetProperty("SelectedObject", BindingFlags.Public | BindingFlags.Instance);
                if (selectedObject != null)
                    propertyInfo.SetValue(_propGrid, new CriteriaBag(selectedObject), null);
            }*/
            else if (_collectionType == typeof(CriteriaProperty))
            {
                var selectedObject = (CriteriaProperty)_propGrid.SelectedObject;
                //Get the property grid's type.
                //This is a vsPropertyGrid located in System.Windows.Forms.Design
                var propertyInfo = _propGrid.GetType().GetProperty("SelectedObject", BindingFlags.Public | BindingFlags.Instance);
                if (selectedObject != null)
                    propertyInfo.SetValue(_propGrid, new CriteriaPropertyBag(selectedObject), null);
            }
            else if (_collectionType == typeof(ConvertValueProperty))
            {
                var selectedObject = (ConvertValueProperty) _propGrid.SelectedObject;
                //Get the property grid's type.
                //This is a vsPropertyGrid located in System.Windows.Forms.Design
                var propertyInfo = _propGrid.GetType().GetProperty("SelectedObject", BindingFlags.Public | BindingFlags.Instance);
                if (selectedObject != null)
                    propertyInfo.SetValue(_propGrid, new ConvertValuePropertyBag(selectedObject), null);
            }
            else if (_collectionType == typeof(UpdateValueProperty))
            {
                var selectedObject = (UpdateValueProperty)_propGrid.SelectedObject;
                //Get the property grid's type.
                //This is a vsPropertyGrid located in System.Windows.Forms.Design
                var propertyInfo = _propGrid.GetType().GetProperty("SelectedObject", BindingFlags.Public | BindingFlags.Instance);
                if (selectedObject != null)
                    propertyInfo.SetValue(_propGrid, new UpdateValuePropertyBag(selectedObject), null);
            }
            else if (_collectionType == typeof(Rule))
            {
                var selectedObject = (Rule)_propGrid.SelectedObject;
                //Get the property grid's type.
                //This is a vsPropertyGrid located in System.Windows.Forms.Design
                var propertyInfo = _propGrid.GetType().GetProperty("SelectedObject", BindingFlags.Public | BindingFlags.Instance);
                if (selectedObject != null)
                    propertyInfo.SetValue(_propGrid, new RuleBag(selectedObject), null);
            }
            else if (_collectionType == typeof(DecoratorArgument))
            {
                var selectedObject = (DecoratorArgument)_propGrid.SelectedObject;
                //Get the property grid's type.
                //This is a vsPropertyGrid located in System.Windows.Forms.Design
                var propertyInfo = _propGrid.GetType().GetProperty("SelectedObject", BindingFlags.Public | BindingFlags.Instance);
                if (selectedObject != null)
                    propertyInfo.SetValue(_propGrid, new DecoratorArgumentBag(selectedObject), null);
            }

            _propGrid.SelectedObjectsChanged += OnSelect;
        }

        #endregion

        private void HandleFormCollectionType()
        {
            switch (_form.Text)
            {
                case "ValueProperty Collection Editor":
                    _collectionType = typeof (ValueProperty);
                    if (GeneratorController.Current.CurrentUnit.GenerationParams.GenerateAuthorization == Authorization.None ||
                        GeneratorController.Current.CurrentUnit.GenerationParams.GenerateAuthorization == Authorization.ObjectLevel)
                        _form.Size = new Size(_form.Size.Width, 633);
                    else
                        _form.Size = new Size(_form.Size.Width, 713);
                    if (GeneratorController.Current.CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40)
                        _form.Size = new Size(_form.Size.Width, _form.Size.Height-16);
                    break;
                case "ChildProperty Collection Editor":
                    _collectionType = typeof (ChildProperty);
                    _form.Size = new Size(_form.Size.Width, 473);
                    break;
                case "Criteria Collection Editor":
                    _collectionType = typeof (Criteria);
                    _form.Size = new Size(_form.Size.Width, 617);
                    break;
                case "CriteriaProperty Collection Editor":
                    _collectionType = typeof (CriteriaProperty);
                    _form.Size = new Size(_form.Size.Width, 393);
                    break;
                case "ConvertValueProperty Collection Editor":
                    _collectionType = typeof(ConvertValueProperty);
                    _form.Size = new Size(_form.Size.Width, 553);
                    break;
                case "UpdateValueProperty Collection Editor":
                    _collectionType = typeof (UpdateValueProperty);
                    break;
                case "Rule Collection Editor":
                    _collectionType = typeof (Rule);
                    break;
                case "DecoratorArgument Collection Editor":
                    _collectionType = typeof (DecoratorArgument);
                    break;
            }

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

            if (_collectionType == typeof(Criteria))
                _propGrid.ExpandAllGridItems();

            _form.StartPosition = FormStartPosition.CenterParent;

            if ((_form.Bounds.Y + _form.Bounds.Height) > maxHeight)
            {
                _form.StartPosition = FormStartPosition.Manual;
                var hDiff = maxHeight - _form.Bounds.Height;
                if (hDiff == 0)
                    hDiff = 0;
                else
                    hDiff = hDiff / 2;

                _form.Bounds = new Rectangle(_form.Bounds.X, hDiff, _form.Bounds.Width, _form.Bounds.Height);
            }
        }
    }
}
