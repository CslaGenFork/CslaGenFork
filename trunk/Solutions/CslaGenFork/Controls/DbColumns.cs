using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CslaGenerator.Metadata;
using DBSchemaInfo.Base;
using DBSchemaInfo.MsSql;

namespace CslaGenerator.Controls
{
    /// <summary>
    /// Summary description for DbColumns.
    /// </summary>
    public class DbColumns : UserControl
    {
        private Panel _panelTop;
        private Panel _panel2;
        private Panel _panel3;
        private PaneCaption _paneCaption1;
        private Panel _panelBottom;
        private Panel _panelTrim;
        private Panel _panel4;
        private Panel _panelBody;
        private PropertyGrid _pgdColumn;
        private Splitter _splitter1;
        private ListBox _lstColumns;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public DbColumns()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._panelTop = new System.Windows.Forms.Panel();
            this._panel2 = new System.Windows.Forms.Panel();
            this._panel3 = new System.Windows.Forms.Panel();
            this._paneCaption1 = new CslaGenerator.Controls.PaneCaption();
            this._panelBottom = new System.Windows.Forms.Panel();
            this._panelTrim = new System.Windows.Forms.Panel();
            this._panel4 = new System.Windows.Forms.Panel();
            this._panelBody = new System.Windows.Forms.Panel();
            this._pgdColumn = new System.Windows.Forms.PropertyGrid();
            this._splitter1 = new System.Windows.Forms.Splitter();
            this._lstColumns = new System.Windows.Forms.ListBox();
            this._panelTop.SuspendLayout();
            this._panel2.SuspendLayout();
            this._panel3.SuspendLayout();
            this._panelBottom.SuspendLayout();
            this._panelTrim.SuspendLayout();
            this._panel4.SuspendLayout();
            this._panelBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this._panelTop.Controls.Add(this._panel2);
            this._panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelTop.DockPadding.All = 3;
            this._panelTop.Location = new System.Drawing.Point(0, 0);
            this._panelTop.Name = "_panelTop";
            this._panelTop.Size = new System.Drawing.Size(288, 32);
            this._panelTop.TabIndex = 11;
            // 
            // panel2
            // 
            this._panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this._panel2.Controls.Add(this._panel3);
            this._panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panel2.DockPadding.All = 1;
            this._panel2.Location = new System.Drawing.Point(3, 3);
            this._panel2.Name = "_panel2";
            this._panel2.Size = new System.Drawing.Size(282, 26);
            this._panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this._panel3.BackColor = System.Drawing.SystemColors.Control;
            this._panel3.Controls.Add(this._paneCaption1);
            this._panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panel3.DockPadding.All = 3;
            this._panel3.Location = new System.Drawing.Point(1, 1);
            this._panel3.Name = "_panel3";
            this._panel3.Size = new System.Drawing.Size(280, 24);
            this._panel3.TabIndex = 13;
            // 
            // paneCaption1
            // 
            this._paneCaption1.AllowActive = false;
            this._paneCaption1.AntiAlias = false;
            this._paneCaption1.Caption = "Columns";
            this._paneCaption1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._paneCaption1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this._paneCaption1.InactiveGradientHighColor = System.Drawing.Color.FromArgb(((System.Byte)(149)), ((System.Byte)(184)), ((System.Byte)(245)));
            this._paneCaption1.InactiveGradientLowColor = System.Drawing.Color.White;
            this._paneCaption1.Location = new System.Drawing.Point(3, 3);
            this._paneCaption1.Name = "_paneCaption1";
            this._paneCaption1.Size = new System.Drawing.Size(274, 18);
            this._paneCaption1.TabIndex = 11;
            // 
            // panelBottom
            // 
            this._panelBottom.Controls.Add(this._panelTrim);
            this._panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelBottom.DockPadding.Bottom = 3;
            this._panelBottom.DockPadding.Left = 3;
            this._panelBottom.DockPadding.Right = 3;
            this._panelBottom.DockPadding.Top = 1;
            this._panelBottom.Location = new System.Drawing.Point(0, 32);
            this._panelBottom.Name = "_panelBottom";
            this._panelBottom.Size = new System.Drawing.Size(288, 448);
            this._panelBottom.TabIndex = 12;
            // 
            // panelTrim
            // 
            this._panelTrim.BackColor = System.Drawing.SystemColors.ControlDark;
            this._panelTrim.Controls.Add(this._panel4);
            this._panelTrim.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelTrim.DockPadding.All = 1;
            this._panelTrim.Location = new System.Drawing.Point(3, 1);
            this._panelTrim.Name = "_panelTrim";
            this._panelTrim.Size = new System.Drawing.Size(282, 444);
            this._panelTrim.TabIndex = 10;
            // 
            // panel4
            // 
            this._panel4.BackColor = System.Drawing.SystemColors.Control;
            this._panel4.Controls.Add(this._panelBody);
            this._panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panel4.DockPadding.All = 3;
            this._panel4.Location = new System.Drawing.Point(1, 1);
            this._panel4.Name = "_panel4";
            this._panel4.Size = new System.Drawing.Size(280, 442);
            this._panel4.TabIndex = 11;
            // 
            // panelBody
            // 
            this._panelBody.BackColor = System.Drawing.SystemColors.Control;
            this._panelBody.Controls.Add(this._pgdColumn);
            this._panelBody.Controls.Add(this._splitter1);
            this._panelBody.Controls.Add(this._lstColumns);
            this._panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelBody.DockPadding.All = 2;
            this._panelBody.Location = new System.Drawing.Point(3, 3);
            this._panelBody.Name = "_panelBody";
            this._panelBody.Size = new System.Drawing.Size(274, 436);
            this._panelBody.TabIndex = 11;
            // 
            // pgdColumn
            // 
            this._pgdColumn.CommandsVisibleIfAvailable = true;
            this._pgdColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pgdColumn.HelpVisible = false;
            this._pgdColumn.LargeButtons = false;
            this._pgdColumn.LineColor = System.Drawing.SystemColors.ScrollBar;
            this._pgdColumn.Location = new System.Drawing.Point(2, 227);
            this._pgdColumn.Name = "_pgdColumn";
            this._pgdColumn.Size = new System.Drawing.Size(270, 207);
            this._pgdColumn.PropertySort = PropertySort.NoSort;
            this._pgdColumn.TabIndex = 5;
            this._pgdColumn.Text = "propertyGrid1";
            this._pgdColumn.ViewBackColor = System.Drawing.SystemColors.Window;
            this._pgdColumn.ViewForeColor = System.Drawing.SystemColors.WindowText;
            // 
            // splitter1
            // 
            this._splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this._splitter1.Location = new System.Drawing.Point(2, 222);
            this._splitter1.Name = "_splitter1";
            this._splitter1.Size = new System.Drawing.Size(270, 5);
            this._splitter1.TabIndex = 6;
            this._splitter1.TabStop = false;
            // 
            // lstColumns
            // 
            this._lstColumns.DisplayMember = "ColumnName";
            this._lstColumns.Dock = System.Windows.Forms.DockStyle.Top;
            this._lstColumns.IntegralHeight = false;
            this._lstColumns.Location = new System.Drawing.Point(2, 2);
            this._lstColumns.Name = "_lstColumns";
            this._lstColumns.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this._lstColumns.Size = new System.Drawing.Size(270, 220);
            this._lstColumns.TabIndex = 7;
            this._lstColumns.ValueMember = "key";
            this._lstColumns.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstColumns_MouseUp);
            // 
            // DbColumns
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this._panelBottom);
            this.Controls.Add(this._panelTop);
            this.Name = "DbColumns";
            this.Size = new System.Drawing.Size(288, 480);
            this.Load += new System.EventHandler(this.DbColumns_Load);
            this._panelTop.ResumeLayout(false);
            this._panel2.ResumeLayout(false);
            this._panel3.ResumeLayout(false);
            this._panelBottom.ResumeLayout(false);
            this._panelTrim.ResumeLayout(false);
            this._panel4.ResumeLayout(false);
            this._panelBody.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private void DbColumns_Load(object sender, EventArgs e)
        {
            //this.lstColumns.Height = (int)((double)0.75 * (double)this.panelBody.Height);
        }

        internal void Clear()
        {
            // clear list and hash table that stores last selected columns
            _lstColumns.Items.Clear();
            if (_lastSelectedHt != null)
                _lastSelectedHt.Clear();
        }

        internal void SelectAll(DbSchemaPanel dbSchemaPanel, CslaGeneratorUnit currentUnit)
        {
            /*
            currentUnit.Params.CreateReadOnlyObjectsCopySoftDelete
            */

            // select all columns in list, except for the exceptions
            for (var i = 0; i < _lstColumns.Items.Count; i++)
            {
                var columnName = ((SqlColumnInfo)_lstColumns.Items[i]).ColumnName;
                var columnNativeType = ((SqlColumnInfo)_lstColumns.Items[i]).NativeType;

                // exception for soft delete column
                if (dbSchemaPanel.UseBoolSoftDelete &&
                    currentUnit.Params.SpBoolSoftDeleteColumn == columnName)
                {
                    continue;
                }

                // exception for auditing columns
                if (!currentUnit.Params.ReadOnlyObjectsCopyAuditing &&
                    IsAuditingColumn(currentUnit, columnName))
                {
                    continue;
                }

                // exception for NativeType timestamp
                if (!currentUnit.Params.ReadOnlyObjectsCopyTimestamp &&
                    columnNativeType == "timestamp")
                {
                    continue;
                }

                // none of the exceptions, so go ahead
                _lstColumns.SetSelected(i, true);
            }
            RefreshColumns();
        }

        private static bool IsAuditingColumn(CslaGeneratorUnit currentUnit, string columnName)
        {
            if (currentUnit.Params.CreationDateColumn == columnName)
                return true;

            if (currentUnit.Params.CreationUserColumn == columnName)
                return true;

            if (currentUnit.Params.ChangedDateColumn == columnName)
                return true;

            if (currentUnit.Params.ChangedUserColumn == columnName)
                return true;

            return false;
        }

        internal void SelectAll(string exclude)
        {
            // select all columns in list
            for (int i = 0; i < _lstColumns.Items.Count; i++)
            {
                if (((SqlColumnInfo)_lstColumns.Items[i]).ColumnName != exclude)
                    _lstColumns.SetSelected(i, true);
            }
            RefreshColumns();
        }

        internal void SelectAll()
        {
            SelectAll("");
        }

        internal void UnSelectAll()
        {
            // unselect all columns in list
            for (int i = 0; i < _lstColumns.Items.Count; i++)
            {
                _lstColumns.SetSelected(i, false);
            }
            if (_lastSelectedHt != null)
                _lastSelectedHt.Clear();
            RefreshColumns();
        }

        // hash table to store the last selected (i.e. most recent) columns
        private Dictionary<string, IColumnInfo> _lastSelectedHt = new Dictionary<string, IColumnInfo>();

        private void lstColumns_MouseUp(object sender, MouseEventArgs e)
        {
            RefreshColumns();
        }

        private void RefreshColumns()
        {
            var lbx = _lstColumns;
            IColumnInfo col;

            var currSelectedHt = new Dictionary<string, IColumnInfo>();
            var lastFound = false;
            if (lbx.SelectedItems.Count == 0)
            {
                if (_pgdColumn.SelectedObjects.Length > 0)
                    _pgdColumn.SelectedObject = null;
                _lastSelectedHt.Clear();
                SetDbColumnsPctHeight(73);
            }
            else if (lbx.SelectedItems.Count > 0)
            {
                for (var i = 0; i < lbx.SelectedItems.Count; i++)
                {
                    col = (IColumnInfo)lbx.SelectedItems[i];
                    try
                    {
                        currSelectedHt.Add(col.ColumnName, col);

                        if (!_lastSelectedHt.ContainsKey(col.ColumnName))
                        {
                            //found new selected row
                            _pgdColumn.SelectedObject = col;
                            _lstColumns.Height = (int)(0.55 * _panelBody.Height);
                            lastFound = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        var sb = new System.Text.StringBuilder();
                        sb.AppendFormat("Error adding column \"{0}\" to seleccion list. Make sure it's not duplicated.", col.ColumnName);
                        sb.AppendLine();
                        sb.AppendLine("Details:");
                        sb.AppendLine(ex.Message);
                        sb.AppendLine(ex.StackTrace);
                        MessageBox.Show(sb.ToString(), @"Error selecting columns", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (lastFound)
                {
                    _lastSelectedHt = currSelectedHt;
                    return;
                }

                foreach (var last in _lastSelectedHt.Values)
                {
                    if (!lbx.SelectedItems.Contains(last))
                    {
                        //found new unselected row
                        _pgdColumn.SelectedObject = last;
                        lastFound = true;
                    }
                }
                _lastSelectedHt = currSelectedHt;
                return;
            }
        }

        #region Properties

        internal ListBox ListColumns
        {
            get { return _lstColumns; }
        }

        // used to set list height to a % of panel height
        internal void SetDbColumnsPctHeight(double pct)
        {
            if (pct > 0 && pct < 100)
            {
                _lstColumns.Height = (int)(pct / 100 * _panelBody.Height);
                Invalidate();
            }
        }

        internal PropertyGrid PropertyGridColumn
        {
            get { return _pgdColumn; }
        }

        internal Dictionary<string, IColumnInfo> SelectedIndices
        {
            get { return _lastSelectedHt; }
        }

        internal int SelectedIndicesCount
        {
            get { return _lastSelectedHt.Count; }
        }

        #endregion
    }
}
