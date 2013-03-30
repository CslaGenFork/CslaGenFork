using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using CslaGenerator.Metadata;
using WeifenLuo.WinFormsUI.Docking;

namespace CslaGenerator.Design
{
    /// <summary>
    /// A custom collection editor that emulates the
    /// </summary>
    public class PropertyCollectionForm : CollectionEditor, IDockedPropertyGrid
    {
        private CollectionForm _form;
        private PropertyGrid _propGrid;

        private DockContent _dockContent;
        private DockPanel dockPanel1;

        #region DockContent

        public void Activate()
        {
            _dockContent.Activate();
        }

        public void DockTo(DockPanel panel, DockStyle dockStyle)
        {
            _dockContent.DockTo(panel, dockStyle);
        }

        public void DockTo(DockPane paneTo, DockStyle dockStyle, int contentIndex)
        {
            _dockContent.DockTo(paneTo, dockStyle, contentIndex);
        }

        public void FloatAt(Rectangle floatWindowBounds)
        {
            _dockContent.FloatAt(floatWindowBounds);
        }

        protected virtual string GetPersistString()
        {
            return "";
//            return _dockContent.GetPersistString();
        }

        public void Hide()
        {
            _dockContent.Hide();
        }

        public bool IsDockStateValid(DockState dockState)
        {
            return _dockContent.IsDockStateValid(dockState);
        }

        public virtual void OnDockStateChanged(EventArgs e)
        {
            EventHandler handler = DockStateChanged;
            if (handler != null)
                handler(this, e);
        }

        public void Show(DockPane previousPane, DockAlignment alignment, double proportion)
        {
            _dockContent.Show(previousPane, alignment, proportion);
        }

        public void Show(DockPane pane, IDockContent beforeContent)
        {
            _dockContent.Show(pane, beforeContent);
        }

        public void Show(DockPanel dockPanel, Rectangle floatWindowBounds)
        {
            _dockContent.Show(dockPanel, floatWindowBounds);
        }

        public void Show(DockPanel dockPanel, DockState dockState)
        {
            _dockContent.Show(dockPanel, dockState);
        }

        public void Show(DockPanel dockPanel)
        {
            _dockContent.Show(dockPanel);
        }

        public void Show()
        {
            _dockContent.Show();
        }

        public bool AllowEndUserDocking
        {
            set { _dockContent.AllowEndUserDocking = value; }
            get { return _dockContent.AllowEndUserDocking; }
        }

        public double AutoHidePortion
        {
            set { _dockContent.AutoHidePortion = value; }
            get { return _dockContent.AutoHidePortion; }
        }

        public bool CloseButton
        {
            set { _dockContent.CloseButton = value; }
            get { return _dockContent.CloseButton; }
        }

        public DockAreas DockAreas
        {
            set { _dockContent.DockAreas = value; }
            get { return _dockContent.DockAreas; }
        }

        public DockContentHandler DockHandler
        {
            get { return _dockContent.DockHandler; }
        }

        public DockPanel DockPanel
        {
            set { _dockContent.DockPanel = value; }
            get { return _dockContent.DockPanel; }
        }

        public DockState DockState
        {
            set { _dockContent.DockState = value; }
            get { return _dockContent.DockState; }
        }

        public DockPane FloatPane
        {
            set { _dockContent.FloatPane = value; }
            get { return _dockContent.FloatPane; }
        }

        public bool HideOnClose
        {
            set { _dockContent.HideOnClose = value; }
            get { return _dockContent.HideOnClose; }
        }

        public bool IsActivated
        {
            get { return _dockContent.IsActivated; }
        }

        public bool IsFloat
        {
            set { _dockContent.IsFloat = value; }
            get { return _dockContent.IsFloat; }
        }

        public bool IsHidden
        {
            set { _dockContent.IsHidden = value; }
            get { return _dockContent.IsHidden; }
        }

        public DockPane Pane
        {
            set { _dockContent.Pane = value; }
            get { return _dockContent.Pane; }
        }

        public DockPane PanelPane
        {
            set { _dockContent.PanelPane = value; }
            get { return _dockContent.PanelPane; }
        }

        public DockState ShowHint
        {
            set { _dockContent.ShowHint = value; }
            get { return _dockContent.ShowHint; }
        }

        public ContextMenu TabPageContextMenu
        {
            set { _dockContent.TabPageContextMenu = value; }
            get { return _dockContent.TabPageContextMenu; }
        }

        public ContextMenuStrip TabPageContextMenuStrip
        {
            set { _dockContent.TabPageContextMenuStrip = value; }
            get { return _dockContent.TabPageContextMenuStrip; }
        }

        public string TabText
        {
            set { _dockContent.TabText = value; }
            get { return _dockContent.TabText; }
        }

        public string ToolTipText
        {
            set { _dockContent.ToolTipText = value; }
            get { return _dockContent.ToolTipText; }
        }

        public DockState VisibleState
        {
            set { _dockContent.DockState = value; }
            get { return _dockContent.DockState; }
        }

        public event EventHandler DockStateChanged;

        #endregion

        private void InitializeComponent()
        {
            dockPanel1 = new DockPanel();
            //
            // dockPanel1
            //
            dockPanel1.ActiveAutoHideContent = null;
            dockPanel1.Font = new Font("Tahoma", 11F, FontStyle.Regular, GraphicsUnit.World);
            dockPanel1.Location = new Point(0, 63);
            dockPanel1.Name = "dockPanel1";
            dockPanel1.Size = new Size(798, 477);
            dockPanel1.TabIndex = 2;

            _form.Controls.Add(dockPanel1);
            DockAreas = DockAreas.DockLeft;
        }

        #region Constructors

        /// <summary>
        /// Creates a new instance of the <see cref="PropertyCollectionForm"/> class
        /// </summary>
        /// <param name="type"></param>
        public PropertyCollectionForm(Type type)
            : base(type)
        {
            _dockContent = new DockContent();
        }

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

            //Get the forms type
            var formType = _form.GetType();

            //Get a reference to the private fieldtype propertyBrowser
            //This is the propertgrid inside the collectionform
            var fieldInfo = formType.GetField("propertyBrowser", BindingFlags.NonPublic | BindingFlags.Instance);

            if (fieldInfo != null)
            {

                //get a reference to the propertygrid instance located on the form
                _propGrid = (PropertyGrid) fieldInfo.GetValue(_form);

                if (_propGrid != null)
                {
                    _propGrid.ToolbarVisible = true;
                    _propGrid.HelpVisible = true;
                    _propGrid.PropertySort = PropertySort.Categorized;

                    /*//Get the property grid's type.
                    //Note that this is a vsPropertyGrid located in System.Windows.Forms.Design
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

//            InitializeComponent();

            return _form;
        }

        #endregion

        public void OnFormShow(object sender, EventArgs e)
        {
            var maxHeight = Screen.PrimaryScreen.WorkingArea.Height;

            if (_propGrid.SelectedObject == null)
                return;

            var type = _propGrid.SelectedObject.GetType().ToString();

            switch (type)
            {
                case "CslaGenerator.Metadata.ValueProperty":
                    _form.Size = new Size(_form.Size.Width, 633);
                    break;
                case "CslaGenerator.Metadata.ChildProperty":
                    _form.Size = new Size(_form.Size.Width, 473);
                    break;
                case "CslaGenerator.Metadata.ConvertValueProperty":
                    _form.Size = new Size(_form.Size.Width, 553);
                    break;
                case "CslaGenerator.Metadata.Criteria":
                    _propGrid.ExpandAllGridItems();
                    _form.Size = new Size(_form.Size.Width, 617);
                    break;
                case "CslaGenerator.Metadata.CriteriaProperty":
                    _propGrid.ExpandAllGridItems();
                    _form.Size = new Size(_form.Size.Width, 393);
                    break;
            }

            _form.StartPosition = FormStartPosition.CenterParent;
            //var a = _form.Bounds.Top;
            //var b = _form.Bounds.Y;
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

            //var formSize = _form.Size.Height;
            //_form.Size = new Size(_form.Size.Width, 633);

        }
    }
}
