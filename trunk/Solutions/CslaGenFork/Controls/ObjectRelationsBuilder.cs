using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CslaGenerator.Metadata;
using CslaGenerator.Util.PropertyBags;
using WeifenLuo.WinFormsUI.Docking;

namespace CslaGenerator.Controls
{
    public partial class ObjectRelationsBuilder : DockContent
    {
        #region Constructor

        public ObjectRelationsBuilder()
        {
            InitializeComponent();

            listEntities1.DrawItem += ListEntities_DrawItem;
            listEntities1.DrawMode = DrawMode.OwnerDrawFixed;
            listEntities2.DrawItem += ListEntities_DrawItem;
            listEntities2.DrawMode = DrawMode.OwnerDrawFixed;
            listEntities3.DrawItem += ListEntities_DrawItem;
            listEntities3.DrawMode = DrawMode.OwnerDrawFixed;

            propGrid1.PropertySortChanged += OnSortTab;
            propGrid2.PropertySortChanged += OnSortTab;
            propGrid3.PropertySortChanged += OnSortTab;

            propGrid1.PropertyValueChanged += OnPropertyValueChanged;
            propGrid2.PropertyValueChanged += OnPropertyValueChanged;
            propGrid3.PropertyValueChanged += OnPropertyValueChanged;
        }

        #endregion

        #region Private fields

        private AssociativeEntityCollection _associativeEntities;
        private bool _suspendFill;
        private bool _restoreSelectedItems;
        private bool _suspendListUpdates;
        private List<AssociativeEntity> _selectedItems1;
        private List<AssociativeEntity> _selectedItems2;
        private List<AssociativeEntity> _selectedItems3;

        #endregion

        #region Properties

        internal List<AssociativeEntity> View1 { get; private set; }

        internal List<AssociativeEntity> View2 { get; private set; }

        internal List<AssociativeEntity> View3 { get; private set; }

        public PropertyGrid PropertyGrid1
        {
            set { propGrid1 = value; }
            get { return propGrid1; }
        }

        public PropertyGrid PropertyGrid2
        {
            set { propGrid2 = value; }
            get { return propGrid2; }
        }

        public PropertyGrid PropertyGrid3
        {
            set { propGrid3 = value; }
            get { return propGrid3; }
        }

        private bool UnitLoaded()
        {
            if (_associativeEntities != null)
                return true;

            MessageBox.Show(@"You need to create a new project first.", @"CslaGenerator", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        public AssociativeEntityCollection AssociativeEntities
        {
            get { return _associativeEntities; }
            set
            {
                if (_associativeEntities != null)
                    _associativeEntities.ListChanged -= associativeEntities_ListChanged;
                _associativeEntities = value;
                if (_associativeEntities != null)
                    _associativeEntities.ListChanged += associativeEntities_ListChanged;
            }
        }

        #endregion

        #region Event handlers

        public void OnSortTab(object sender, EventArgs e)
        {
            if (GetCurrentPropertyGrid().PropertySort == PropertySort.CategorizedAlphabetical)
                GetCurrentPropertyGrid().PropertySort = PropertySort.Categorized;
        }

        private void OnPropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.Label == "Primary Loading Scheme" || e.ChangedItem.Label == "Secondary Loading Scheme")
            {
                FillViews(true);
            }
        }

        private void ListEntities_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            if (e.Index > GetCurrentViewItems().Count - 1)
                return;

            e.DrawBackground();
            var b = new SolidBrush(e.ForeColor);
            e.Graphics.DrawString(GetCurrentViewItems()[e.Index].ObjectName, e.Font, b, e.Bounds);
            e.DrawFocusRectangle();
        }

        private void associativeEntities_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (_suspendListUpdates)
                return;

            if (e.ListChangedType == ListChangedType.ItemChanged && 
                e.PropertyDescriptor.Name != "ObjectName" && 
                e.PropertyDescriptor.Name != "RelationType")
            {
                // if "ObjectName" or "RelationType" didn't change, just refresh
                GetCurrentListBox().Refresh();
                return;
            }

            FillViews(false);
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                // no need to fire ListEntities_SelectedIndexChanged 4 times
                DisableEventSelectedIndexChanged();

                // store currency values for later use
                var selectedItems1 = new List<AssociativeEntity>();
                if (_associativeEntities != null)
                {
                    if (listEntities1.SelectedItems.Count == 0 && listEntities1.Items.Count > 0)
                        listEntities1.SelectedItem = listEntities1.Items[0];

                    foreach (AssociativeEntity obj in listEntities1.SelectedItems)
                        selectedItems1.Add(obj);
                }

                var selectedItems2 = new List<AssociativeEntity>();
                if (_associativeEntities != null)
                {
                    if (listEntities2.SelectedItems.Count == 0 && listEntities2.Items.Count > 0)
                        listEntities2.SelectedItem = listEntities2.Items[0];

                    foreach (AssociativeEntity obj in listEntities2.SelectedItems)
                        selectedItems2.Add(obj);
                }

                var selectedItems3 = new List<AssociativeEntity>();
                if (_associativeEntities != null)
                {
                    if (listEntities3.SelectedItems.Count == 0 && listEntities3.Items.Count > 0)
                        listEntities3.SelectedItem = listEntities3.Items[0];

                    foreach (AssociativeEntity obj in listEntities3.SelectedItems)
                        selectedItems3.Add(obj);
                }

                // update the ListBox items
                FillViewsPresenter();

                listEntities1.SelectedIndices.Clear();
                listEntities2.SelectedIndices.Clear();
                listEntities3.SelectedIndices.Clear();

                if (_associativeEntities != null)
                {
                    if (selectedItems1.Count == 0 && listEntities1.Items.Count > 0)
                    {
                        _selectedItems1.Clear();
                        listEntities1.SelectedIndex = listEntities1.Items.Count - 1;
                    }
                    if (selectedItems2.Count == 0 && listEntities2.Items.Count > 0)
                    {
                        _selectedItems2.Clear();
                        listEntities2.SelectedIndex = listEntities2.Items.Count - 1;
                    }
                    if (selectedItems3.Count == 0 && listEntities3.Items.Count > 0)
                    {
                        _selectedItems3.Clear();
                        listEntities3.SelectedIndex = listEntities3.Items.Count - 1;
                    }
                }

                foreach (var obj in selectedItems1)
                    listEntities1.SelectedItems.Add(obj);

                foreach (var obj in selectedItems2)
                    listEntities2.SelectedItems.Add(obj);

                foreach (var obj in selectedItems3)
                    listEntities3.SelectedItems.Add(obj);

                EnableEventSelectedIndexChanged();
                ListEntities1_SelectedIndexChanged(this, new EventArgs());
                ListEntities2_SelectedIndexChanged(this, new EventArgs());
                ListEntities3_SelectedIndexChanged(this, new EventArgs());
                return;
            }

            FillViewsPresenter();
        }

        private void ListEntities1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisableEventSelectedIndexChanged();

            if (_restoreSelectedItems)
            {
                listEntities1.SelectedItems.Clear();

                // if empty list, preload with first item
                if (_selectedItems1.Count == 0 && listEntities1.Items.Count > 0)
                    listEntities1.SelectedItems.Add(listEntities1.Items[0]);
                else
                    foreach (var obj in _selectedItems1)
                        listEntities1.SelectedItems.Add(obj);
            }
            else
            {
                _selectedItems1 = new List<AssociativeEntity>();
            }

            OnSelectedItemsChanged();

            EnableEventSelectedIndexChanged();
        }

        private void ListEntities2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisableEventSelectedIndexChanged();

            if (_restoreSelectedItems)
            {
                listEntities2.SelectedItems.Clear();

                // if empty list, preload with first item
                if (_selectedItems2.Count == 0 && listEntities2.Items.Count > 0)
                    listEntities2.SelectedItems.Add(listEntities2.Items[0]);
                else
                    foreach (var obj in _selectedItems2)
                        listEntities2.SelectedItems.Add(obj);
            }
            else
            {
                _selectedItems2 = new List<AssociativeEntity>();
            }

            OnSelectedItemsChanged();

            EnableEventSelectedIndexChanged();
        }

        private void ListEntities3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisableEventSelectedIndexChanged();

            if (_restoreSelectedItems)
            {
                listEntities3.SelectedItems.Clear();

                // if empty list, preload with first item
                if (_selectedItems3.Count == 0 && listEntities3.Items.Count > 0)
                    listEntities3.SelectedItems.Add(listEntities3.Items[0]);
                else
                    foreach (var obj in _selectedItems3)
                        listEntities3.SelectedItems.Add(obj);
            }
            else
            {
                _selectedItems3 = new List<AssociativeEntity>();
            }

            OnSelectedItemsChanged();

            EnableEventSelectedIndexChanged();
        }

        private void TabControl_Selected(object sender, TabControlEventArgs e)
        {
            OnSelectedItemsChanged();
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            MoveUpSelected();
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            MoveDownSelected();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddNewObject();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            RemoveSelected();
        }

        private void buildButton_Click(object sender, EventArgs e)
        {
            var associativeEntity = GetCurrentViewItems()[GetCurrentListBox().SelectedIndex];
            ValidateSelected(associativeEntity);
        }

        private void buildAllButton_Click(object sender, EventArgs e)
        {
            ValidateAll();
        }

        #endregion

        #region Events

        public event EventHandler SelectedItemsChanged;
        void OnSelectedItemsChanged()
        {
            if (SelectedItemsChanged != null)
                SelectedItemsChanged(this, EventArgs.Empty);
        }

        #endregion

        #region Methods

        public void ClearSelectedItems()
        {
            _selectedItems1 = new List<AssociativeEntity>();
            _selectedItems2 = new List<AssociativeEntity>();
            _selectedItems3 = new List<AssociativeEntity>();
        }

        /// <summary>
        /// Applies the filters to the CslaObjectInfoCollection.
        /// </summary>
        /// <remarks>
        /// This method should handle only the filtering of business objects.
        /// The view part - handle what is displayed in the ListBox - should be here.
        /// </remarks>
        public void FillViews(bool updatePresenter)
        {
            if (_suspendFill)
                return;

            listEntities1.SuspendLayout();
            listEntities2.SuspendLayout();
            listEntities3.SuspendLayout();
            View1 = new List<AssociativeEntity>();
            View2 = new List<AssociativeEntity>();
            View3 = new List<AssociativeEntity>();
            if (_associativeEntities != null)
            {
                foreach (var obj in _associativeEntities)
                {
                    View1.Add(obj);
                    if (obj.RelationType == ObjectRelationType.OneToMany)
                        View2.Add(obj);
                    else
                        View3.Add(obj);
                }
            }
            if (updatePresenter)
                FillViewsPresenter();
        }

        public void FillViewsPresenter()
        {
            if (_suspendFill)
                return;

            _restoreSelectedItems = true;
            // stupid Windows.Forms doesn't fire the event when the DataSource has elements and is assigned an empty collection
            var firEventManually = false;

            // store currency values for later use by ListEntities1_SelectedIndexChanged
            if (_selectedItems1 == null)
                _selectedItems1 = new List<AssociativeEntity>();
            if (_associativeEntities != null)
            {
                foreach (AssociativeEntity obj in listEntities1.SelectedItems)
                {
                    if (_associativeEntities.Contains(obj))
                        _selectedItems1.Add(obj);
                }
            }
            if (listEntities1.DataSource != null)
                firEventManually = ((ICollection) listEntities1.DataSource).Count > 0 && View1.Count == 0;
            listEntities1.DataSource = View1; // this sets the list SelectedItem to the first item
            if (firEventManually)
                ListEntities1_SelectedIndexChanged(this, new EventArgs());

            // store currency values for later use by ListEntities2_SelectedIndexChanged
            if (_selectedItems2 == null)
                _selectedItems2 = new List<AssociativeEntity>();
            if (_associativeEntities != null)
            {
                foreach (AssociativeEntity obj in listEntities2.SelectedItems)
                {
                    if (_associativeEntities.Contains(obj))
                        _selectedItems2.Add(obj);
                }
            }
            if (listEntities2.DataSource != null)
                firEventManually = ((ICollection) listEntities2.DataSource).Count > 0 && View2.Count == 0;
            listEntities2.DataSource = View2; // this sets the list SelectedItem to the first item
            if (firEventManually)
                ListEntities2_SelectedIndexChanged(this, new EventArgs());

            // store currency values for later use by ListEntities3_SelectedIndexChanged
            if (_selectedItems3 == null)
                _selectedItems3 = new List<AssociativeEntity>();
            if (_associativeEntities != null)
            {
                foreach (AssociativeEntity obj in listEntities3.SelectedItems)
                {
                    if (_associativeEntities.Contains(obj))
                        _selectedItems3.Add(obj);
                }
            }
            if (listEntities3.DataSource != null)
                firEventManually = ((ICollection) listEntities3.DataSource).Count > 0 && View3.Count == 0;
            listEntities3.DataSource = View3; // this sets the list SelectedItem to the first item
            if (firEventManually)
                ListEntities3_SelectedIndexChanged(this, new EventArgs());
            _restoreSelectedItems = false;

            listEntities1.ResumeLayout();
            listEntities2.ResumeLayout();
            listEntities3.ResumeLayout();
            if (_associativeEntities != null)
            {
                if (_associativeEntities.Count == 0)
                {
                    PropertyGrid1.SelectedObject = null;
                    PropertyGrid2.SelectedObject = null;
                    PropertyGrid3.SelectedObject = null;
                }
            }
        }

        #region Tab pages handlers

        internal ListBox GetCurrentListBox()
        {
            return GetListBox(TabControl.SelectedTab);
        }

        private ListBox GetListBox(TabPage page)
        {
            switch (page.TabIndex)
            {
                case 0:
                    return listEntities1;
                case 1:
                    return listEntities2;
                default:
                    return listEntities3;
            }
        }

        internal List<AssociativeEntity> GetCurrentViewItems()
        {
            return GetViewItems(TabControl.SelectedTab);
        }

        private List<AssociativeEntity> GetViewItems(TabPage page)
        {
            switch (page.TabIndex)
            {
                case 0:
                    return View1;
                case 1:
                    return View2;
                default:
                    return View3;
            }
        }

        internal PropertyGrid GetCurrentPropertyGrid()
        {
            return GetPropertyGrid(TabControl.SelectedTab);
        }

        private PropertyGrid GetPropertyGrid(TabPage page)
        {
            switch (page.TabIndex)
            {
                case 0:
                    return PropertyGrid1;
                case 1:
                    return PropertyGrid2;
                default:
                    return PropertyGrid3;
            }
        }

        internal void SetAllPropertyGridSelectedObject(AssociativeEntity current)
        {
            SetPropertyGridSelectedObject(TabControl.TabPages[0], current);
            SetPropertyGridSelectedObject(TabControl.TabPages[1], current);
            SetPropertyGridSelectedObject(TabControl.TabPages[2], current);
        }

        private void SetPropertyGridSelectedObject(TabPage page, AssociativeEntity current)
        {
            switch (page.TabIndex)
            {
                case 0:
                    if (current != null)
                    {
                        listEntities1.SelectedItem = current;
                        PropertyGrid1.SelectedObject = new AssociativeEntityPropertyBag(current);
                    }
                    else
                    {
                        PropertyGrid1.SelectedObject = null;
                    }
                    break;
                case 1:
                    if (current != null)
                    {
                        listEntities2.SelectedItem = current;
                        PropertyGrid2.SelectedObject = new AssociativeEntityPropertyBag(current);
                    }
                    else
                    {
                        PropertyGrid2.SelectedObject = null;
                    }
                    break;
                default:
                    if (current != null)
                    {
                        listEntities3.SelectedItem = current;
                        PropertyGrid3.SelectedObject = new AssociativeEntityPropertyBag(current);
                    }
                    else
                    {
                        PropertyGrid3.SelectedObject = null;
                    }
                    break;
            }
        }

        #endregion

        public void RemoveSelected()
        {
            if (!UnitLoaded())
                return;

            // Suspend filter until it's done
            _suspendFill = true;

            // Don't restore SelectedItems
            _restoreSelectedItems = false;

            // What to delete
            var deleteList = new List<AssociativeEntity>();
            foreach (AssociativeEntity obj in GetCurrentListBox().SelectedItems)
                deleteList.Add(obj);

            // This is item above the top most selected item
            var selectedIndex = GetCurrentListBox().SelectedIndex - 1;

            // Now we don't need SelectedIndices any more (and they don't exist anyway)
            GetCurrentListBox().SelectedIndices.Clear();

            // Do delete
            foreach (AssociativeEntity obj in deleteList)
                _associativeEntities.Remove(obj);

            // Now filter and get ListBox updated
            _suspendFill = false;
            FillViews(true);

            // List is empty
            if (GetCurrentListBox().Items.Count == 0)
                return;

            // Select the first element
            if (selectedIndex == -1)
                selectedIndex = 0;

            switch (TabControl.TabIndex)
            {
                case 0:
                    _selectedItems1 = new List<AssociativeEntity>();
                    break;
                case 1:
                    _selectedItems2 = new List<AssociativeEntity>();
                    break;
                default:
                    _selectedItems3 = new List<AssociativeEntity>();
                    break;
            }
            GetCurrentListBox().SelectedIndices.Clear();

            // Can't select past the end
            if (selectedIndex > GetCurrentListBox().Items.Count - 1)
                selectedIndex = GetCurrentListBox().Items.Count - 1;

            GetCurrentListBox().SelectedIndex = selectedIndex;
            var selectdObject = (AssociativeEntity)GetCurrentListBox().SelectedItem;
            switch (TabControl.TabIndex)
            {
                case 0:
                    _selectedItems1.Add(selectdObject);
                    break;
                case 1:
                    _selectedItems2.Add(selectdObject);
                    break;
                default:
                    _selectedItems3.Add(selectdObject);
                    break;
            }

            // Now restore SelectedItems
            _restoreSelectedItems = true;
            FillViewsPresenter();
        }

        public void DuplicateSelected()
        {
            if (!UnitLoaded())
                return;

            var lst = new List<AssociativeEntity>();
            foreach (AssociativeEntity obj in GetCurrentListBox().SelectedItems)
                lst.Add(obj.Duplicate(GeneratorController.Catalog));

            foreach (var obj in lst)
                _associativeEntities.Add(obj);
        }

        public void AddNewObject()
        {
            if (!UnitLoaded())
                return;

            var newAssociativeEntity = new AssociativeEntity(GeneratorController.Current.CurrentUnit);
            newAssociativeEntity.MainLazyLoad = false;
            newAssociativeEntity.SecondaryLazyLoad = false;
            _associativeEntities.Add(newAssociativeEntity);
        }

        private void MoveUpSelected()
        {
            if (!UnitLoaded())
                return;

            // Suspend filter until it's done
            _suspendListUpdates = true;
            DisableEventDrawItem();

            var item = GetCurrentViewItems()[GetCurrentListBox().SelectedIndex];
            var idx = _associativeEntities.IndexOf(item);
            if (idx > 0)
            {
                _associativeEntities.RemoveAt(idx);
                _associativeEntities.Insert(idx - 1, item);
            }

            // Now filter and get ListBox updated
            _suspendListUpdates = false;
            EnableEventDrawItem();
            FillViews(true);
        }

        private void MoveDownSelected()
        {
            if (!UnitLoaded())
                return;

            // Suspend filter until it's done
            _suspendListUpdates = true;
            DisableEventDrawItem();

            var item = GetCurrentViewItems()[GetCurrentListBox().SelectedIndex];
            var idx = _associativeEntities.IndexOf(item);
            if (idx < _associativeEntities.Count - 1)
            {
                _associativeEntities.RemoveAt(idx);
                _associativeEntities.Insert(idx + 1, item);
            }

            // Now filter and get ListBox updated
            _suspendListUpdates = false;
            EnableEventDrawItem();
            FillViews(true);
        }

        public void ValidateSelected(AssociativeEntity associativeEntity)
        {
            if (!UnitLoaded())
                return;

            var validationErrors = associativeEntity.Validate();
            if (string.IsNullOrEmpty(validationErrors))
            {
                var msgBox = MessageBox.Show("Object relation \"" + associativeEntity.ObjectName + "\" is valid.\r\n\r\n" +
                                             "Do you want to build/correct the CSLA objects?",
                                             "Object relation validation", MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Information);
                if (msgBox == DialogResult.Yes)
                {
                    associativeEntity.Build();
                }
            }
            else
                MessageBox.Show(
                    "Object relation " + associativeEntity.ObjectName + " is invalid.\r\n" + validationErrors,
                    "Object relation validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ValidateAll()
        {
            if (!UnitLoaded())
                return;

            var associativeEntitiesCollection = GetCurrentViewItems();
            foreach (var associativeEntity in associativeEntitiesCollection)
            {
                ValidateSelected(associativeEntity);
            }
        }

        public void Add(CslaObjectInfo mainObject)
        {
            try
            {
                _associativeEntities.Add(mainObject);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Object Relations Builder", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            TabControl.SelectTab(1);
            listEntities2.SelectedItems.Clear();
            listEntities2.SelectedItem = listEntities2.Items[listEntities2.Items.Count - 1];
        }

        public void Add(CslaObjectInfo mainObject, CslaObjectInfo secondaryObject)
        {
            try
            {
                _associativeEntities.Add(mainObject, secondaryObject);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Object Relations Builder", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            TabControl.SelectTab(2);
            listEntities3.SelectedItems.Clear();
            listEntities3.SelectedItem = listEntities3.Items[listEntities3.Items.Count - 1];
        }

        private void DisableEventSelectedIndexChanged()
        {
            listEntities1.SelectedIndexChanged -= ListEntities1_SelectedIndexChanged;
            listEntities2.SelectedIndexChanged -= ListEntities2_SelectedIndexChanged;
            listEntities3.SelectedIndexChanged -= ListEntities3_SelectedIndexChanged;
        }

        private void EnableEventSelectedIndexChanged()
        {
            listEntities1.SelectedIndexChanged += ListEntities1_SelectedIndexChanged;
            listEntities2.SelectedIndexChanged += ListEntities2_SelectedIndexChanged;
            listEntities3.SelectedIndexChanged += ListEntities3_SelectedIndexChanged;
        }

        private void DisableEventDrawItem()
        {
            listEntities1.DrawItem -= ListEntities_DrawItem;
            listEntities2.DrawItem -= ListEntities_DrawItem;
            listEntities3.DrawItem -= ListEntities_DrawItem;
        }

        private void EnableEventDrawItem()
        {
            listEntities1.DrawItem += ListEntities_DrawItem;
            listEntities2.DrawItem += ListEntities_DrawItem;
            listEntities3.DrawItem += ListEntities_DrawItem;
        }

        #endregion
    }
}