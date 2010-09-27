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
	public class DbColumns : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Panel panelTop;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private CslaGenerator.Controls.PaneCaption paneCaption1;
		private System.Windows.Forms.Panel panelBottom;
		private System.Windows.Forms.Panel panelTrim;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panelBody;
		private System.Windows.Forms.PropertyGrid pgdColumn;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ListBox lstColumns;

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
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panelTop = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.paneCaption1 = new CslaGenerator.Controls.PaneCaption();
			this.panelBottom = new System.Windows.Forms.Panel();
			this.panelTrim = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panelBody = new System.Windows.Forms.Panel();
			this.pgdColumn = new System.Windows.Forms.PropertyGrid();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.lstColumns = new System.Windows.Forms.ListBox();
			this.panelTop.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panelBottom.SuspendLayout();
			this.panelTrim.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panelBody.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelTop
			// 
			this.panelTop.Controls.Add(this.panel2);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.DockPadding.All = 3;
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(288, 32);
			this.panelTop.TabIndex = 11;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.DockPadding.All = 1;
			this.panel2.Location = new System.Drawing.Point(3, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(282, 26);
			this.panel2.TabIndex = 13;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.Control;
			this.panel3.Controls.Add(this.paneCaption1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.DockPadding.All = 3;
			this.panel3.Location = new System.Drawing.Point(1, 1);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(280, 24);
			this.panel3.TabIndex = 13;
			// 
			// paneCaption1
			// 
			this.paneCaption1.AllowActive = false;
			this.paneCaption1.AntiAlias = false;
			this.paneCaption1.Caption = "Columns";
			this.paneCaption1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.paneCaption1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.paneCaption1.InactiveGradientHighColor = System.Drawing.Color.FromArgb(((System.Byte)(149)), ((System.Byte)(184)), ((System.Byte)(245)));
			this.paneCaption1.InactiveGradientLowColor = System.Drawing.Color.White;
			this.paneCaption1.Location = new System.Drawing.Point(3, 3);
			this.paneCaption1.Name = "paneCaption1";
			this.paneCaption1.Size = new System.Drawing.Size(274, 18);
			this.paneCaption1.TabIndex = 11;
			// 
			// panelBottom
			// 
			this.panelBottom.Controls.Add(this.panelTrim);
			this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelBottom.DockPadding.Bottom = 3;
			this.panelBottom.DockPadding.Left = 3;
			this.panelBottom.DockPadding.Right = 3;
			this.panelBottom.DockPadding.Top = 1;
			this.panelBottom.Location = new System.Drawing.Point(0, 32);
			this.panelBottom.Name = "panelBottom";
			this.panelBottom.Size = new System.Drawing.Size(288, 448);
			this.panelBottom.TabIndex = 12;
			// 
			// panelTrim
			// 
			this.panelTrim.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panelTrim.Controls.Add(this.panel4);
			this.panelTrim.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelTrim.DockPadding.All = 1;
			this.panelTrim.Location = new System.Drawing.Point(3, 1);
			this.panelTrim.Name = "panelTrim";
			this.panelTrim.Size = new System.Drawing.Size(282, 444);
			this.panelTrim.TabIndex = 10;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.SystemColors.Control;
			this.panel4.Controls.Add(this.panelBody);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.DockPadding.All = 3;
			this.panel4.Location = new System.Drawing.Point(1, 1);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(280, 442);
			this.panel4.TabIndex = 11;
			// 
			// panelBody
			// 
			this.panelBody.BackColor = System.Drawing.SystemColors.Control;
			this.panelBody.Controls.Add(this.pgdColumn);
			this.panelBody.Controls.Add(this.splitter1);
			this.panelBody.Controls.Add(this.lstColumns);
			this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelBody.DockPadding.All = 2;
			this.panelBody.Location = new System.Drawing.Point(3, 3);
			this.panelBody.Name = "panelBody";
			this.panelBody.Size = new System.Drawing.Size(274, 436);
			this.panelBody.TabIndex = 11;
			// 
			// pgdColumn
			// 
			this.pgdColumn.CommandsVisibleIfAvailable = true;
			this.pgdColumn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pgdColumn.HelpVisible = false;
			this.pgdColumn.LargeButtons = false;
			this.pgdColumn.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.pgdColumn.Location = new System.Drawing.Point(2, 227);
			this.pgdColumn.Name = "pgdColumn";
			this.pgdColumn.Size = new System.Drawing.Size(270, 207);
			this.pgdColumn.TabIndex = 5;
			this.pgdColumn.Text = "propertyGrid1";
			this.pgdColumn.ViewBackColor = System.Drawing.SystemColors.Window;
			this.pgdColumn.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(2, 222);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(270, 5);
			this.splitter1.TabIndex = 6;
			this.splitter1.TabStop = false;
			// 
			// lstColumns
			// 
            this.lstColumns.DisplayMember = "ColumnName";
			this.lstColumns.Dock = System.Windows.Forms.DockStyle.Top;
			this.lstColumns.IntegralHeight = false;
			this.lstColumns.Location = new System.Drawing.Point(2, 2);
			this.lstColumns.Name = "lstColumns";
			this.lstColumns.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstColumns.Size = new System.Drawing.Size(270, 220);
			this.lstColumns.TabIndex = 7;
			this.lstColumns.ValueMember = "key";
			this.lstColumns.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstColumns_MouseUp);
			// 
			// DbColumns
			// 
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.panelBottom);
			this.Controls.Add(this.panelTop);
			this.Name = "DbColumns";
			this.Size = new System.Drawing.Size(288, 480);
			this.Load += new System.EventHandler(this.DbColumns_Load);
			this.panelTop.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panelBottom.ResumeLayout(false);
			this.panelTrim.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panelBody.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void DbColumns_Load(object sender, System.EventArgs e)
		{			
			//this.lstColumns.Height = (int)((double)0.75 * (double)this.panelBody.Height);
		}
		internal void Clear()
		{
			// clear list and hash table that stores last selected columns
			this.lstColumns.Items.Clear();
			if (LastSelectedHT != null)
				LastSelectedHT.Clear();

		}

        internal void SelectAll(DbSchemaPanel dbSchemaPanel, CslaGeneratorUnit currentUnit)
		{
            /*
		    currentUnit.Params.CreateReadOnlyObjectsCopySoftDelete
            */

            // select all columns in list, except for the exceptions
            for (int i = 0; i < lstColumns.Items.Count; i++)
            {
                var columnName = ((SqlColumnInfo) lstColumns.Items[i]).ColumnName;
                var columnNativeType = ((SqlColumnInfo) lstColumns.Items[i]).NativeTypeName;

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
                lstColumns.SetSelected(i, true);
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
            for (int i = 0; i < lstColumns.Items.Count; i++)
            {
                if (((SqlColumnInfo) lstColumns.Items[i]).ColumnName != exclude)
                    lstColumns.SetSelected(i, true);
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
			for (int i = 0; i < lstColumns.Items.Count; i++)
			{
				lstColumns.SetSelected(i,false);
			}	
			if (LastSelectedHT != null)
				LastSelectedHT.Clear();
		}

		// hash table to store the last selected (i.e. most recent) columns
        Dictionary<string, IColumnInfo> LastSelectedHT = new Dictionary<string, IColumnInfo>();
        private void lstColumns_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        { RefreshColumns(); }
		private void RefreshColumns()
		{
			ListBox lbx = this.lstColumns;
            IColumnInfo col=null;
            
			Dictionary<string,IColumnInfo> CurrSelectedHT = new Dictionary<string,IColumnInfo>();
			bool lastFound = false;		
			if (lbx.SelectedItems.Count > 0)
			{
				for (int i = 0; i < lbx.SelectedItems.Count; i++)
				{
                    col = (IColumnInfo)lbx.SelectedItems[i];
                    try
                    {
                        CurrSelectedHT.Add(col.ColumnName, col);


                        if (!LastSelectedHT.ContainsKey(col.ColumnName))
                        {
                            //found new selected row
                            this.pgdColumn.SelectedObject = col;
                            this.lstColumns.Height = (int)((double)0.55 * (double)this.panelBody.Height);
                            lastFound = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.AppendFormat("Error adding column \"{0}\" to seleccion list. Make sure it's not duplicated.", col.ColumnName);
                        sb.AppendLine();
                        sb.AppendLine("Details:");
                        sb.AppendLine(ex.Message);
                        sb.AppendLine(ex.StackTrace);
                        MessageBox.Show(sb.ToString(), "Error selecting columns", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
				}
				if (lastFound)
				{
					LastSelectedHT = CurrSelectedHT;
					return;
				}

				foreach (IColumnInfo last in LastSelectedHT.Values)
				{
					if (!lbx.SelectedItems.Contains(last))
					{
						//found new unselected row
						this.pgdColumn.SelectedObject = last;
						lastFound = true;
					}
				}
				LastSelectedHT = CurrSelectedHT;
				return;

			}
	
		}
		#region Properties

		internal ListBox ListColumns
		{
			get { return this.lstColumns; }
		}
		// used to set list height to a % of panel height
		internal void SetDbColumnsPctHeight(double pct)
		{
			if (pct > 0 && pct < 100)
			{
				this.lstColumns.Height = (int) ((double) pct/100 * (double) this.panelBody.Height);
				this.Invalidate();
			}
		}
		internal PropertyGrid PropertyGridColumn
		{
			get { return this.pgdColumn; }
		}
		internal Dictionary<string,IColumnInfo> SelectedIndices
		{
			get { return LastSelectedHT; }
		}
		internal int SelectedIndicesCount
		{
			get { return LastSelectedHT.Count; }
		}
		#endregion	
	}
}
