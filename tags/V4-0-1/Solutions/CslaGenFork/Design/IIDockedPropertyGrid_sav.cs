using System;

namespace CslaGenerator.Design
{
    interface IDockedPropertyGrid
    {
        void Activate();
        bool AllowEndUserDocking { get; set; }
        double AutoHidePortion { get; set; }
        bool CloseButton { get; set; }
        WeifenLuo.WinFormsUI.Docking.DockAreas DockAreas { get; set; }
        WeifenLuo.WinFormsUI.Docking.DockContentHandler DockHandler { get; }
        WeifenLuo.WinFormsUI.Docking.DockPanel DockPanel { get; set; }
        WeifenLuo.WinFormsUI.Docking.DockState DockState { get; set; }
        event EventHandler DockStateChanged;
        void DockTo(WeifenLuo.WinFormsUI.Docking.DockPane paneTo, System.Windows.Forms.DockStyle dockStyle, int contentIndex);
        void DockTo(WeifenLuo.WinFormsUI.Docking.DockPanel panel, System.Windows.Forms.DockStyle dockStyle);
        void FloatAt(System.Drawing.Rectangle floatWindowBounds);
        WeifenLuo.WinFormsUI.Docking.DockPane FloatPane { get; set; }
        void Hide();
        bool HideOnClose { get; set; }
        bool IsActivated { get; }
        bool IsDockStateValid(WeifenLuo.WinFormsUI.Docking.DockState dockState);
        bool IsFloat { get; set; }
        bool IsHidden { get; set; }
        void OnDockStateChanged(EventArgs e);
        void OnFormShow(object sender, EventArgs e);
        WeifenLuo.WinFormsUI.Docking.DockPane Pane { get; set; }
        WeifenLuo.WinFormsUI.Docking.DockPane PanelPane { get; set; }
        void Show();
        void Show(WeifenLuo.WinFormsUI.Docking.DockPane previousPane, WeifenLuo.WinFormsUI.Docking.DockAlignment alignment, double proportion);
        void Show(WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel, WeifenLuo.WinFormsUI.Docking.DockState dockState);
        void Show(WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel);
        void Show(WeifenLuo.WinFormsUI.Docking.DockPane pane, WeifenLuo.WinFormsUI.Docking.IDockContent beforeContent);
        void Show(WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel, System.Drawing.Rectangle floatWindowBounds);
        WeifenLuo.WinFormsUI.Docking.DockState ShowHint { get; set; }
        System.Windows.Forms.ContextMenu TabPageContextMenu { get; set; }
        System.Windows.Forms.ContextMenuStrip TabPageContextMenuStrip { get; set; }
        string TabText { get; set; }
        string ToolTipText { get; set; }
        WeifenLuo.WinFormsUI.Docking.DockState VisibleState { get; set; }
    }
}
