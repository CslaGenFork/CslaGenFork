using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CslaGenerator.Design
{
    /// <summary>
    /// Summary description for ObjectEditorForm.
    /// </summary>
    public class XmlCommentEditorForm : Form
    {
        private Button btnOK;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Button btnC;
        private Button btnCode;
        private Button btnPara;
        private Button btnSee;
        private TextBox txtXmlComment;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        public XmlCommentEditorForm()
        {
            //
            // Required for Windows Form Designer support
            //
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

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtXmlComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnC = new System.Windows.Forms.Button();
            this.btnCode = new System.Windows.Forms.Button();
            this.btnPara = new System.Windows.Forms.Button();
            this.btnSee = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // btnOK
            //
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(240, 328);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 24);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            //
            // btnCancel
            //
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(328, 328);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // txtXmlComment
            //
            this.txtXmlComment.AcceptsReturn = true;
            this.txtXmlComment.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.txtXmlComment.Location = new System.Drawing.Point(8, 8);
            this.txtXmlComment.Multiline = true;
            this.txtXmlComment.Name = "txtXmlComment";
            this.txtXmlComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtXmlComment.Size = new System.Drawing.Size(400, 272);
            this.txtXmlComment.TabIndex = 0;
            this.txtXmlComment.Text = "";
            this.txtXmlComment.WordWrap = false;
            //
            // label1
            //
            this.label1.Location = new System.Drawing.Point(8, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Insert block:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // btnC
            //
            this.btnC.Location = new System.Drawing.Point(88, 288);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(80, 23);
            this.btnC.TabIndex = 2;
            this.btnC.Text = "<&c>";
            this.btnC.Click += new System.EventHandler(this.btnC_Click);
            //
            // btnCode
            //
            this.btnCode.Location = new System.Drawing.Point(168, 288);
            this.btnCode.Name = "btnCode";
            this.btnCode.Size = new System.Drawing.Size(80, 23);
            this.btnCode.TabIndex = 3;
            this.btnCode.Text = "<co&de>";
            this.btnCode.Click += new System.EventHandler(this.btnCode_Click);
            //
            // btnPara
            //
            this.btnPara.Location = new System.Drawing.Point(248, 288);
            this.btnPara.Name = "btnPara";
            this.btnPara.Size = new System.Drawing.Size(80, 23);
            this.btnPara.TabIndex = 4;
            this.btnPara.Text = "<&para>";
            this.btnPara.Click += new System.EventHandler(this.btnPara_Click);
            //
            // btnSee
            //
            this.btnSee.Location = new System.Drawing.Point(328, 288);
            this.btnSee.Name = "btnSee";
            this.btnSee.Size = new System.Drawing.Size(80, 23);
            this.btnSee.TabIndex = 5;
            this.btnSee.Text = "<&see>";
            this.btnSee.Click += new System.EventHandler(this.btnSee_Click);
            //
            // label2
            //
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(8, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(400, 2);
            this.label2.TabIndex = 6;
            //
            // XmlCommentEditorForm
            //
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(416, 358);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtXmlComment);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCode);
            this.Controls.Add(this.btnPara);
            this.Controls.Add(this.btnSee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XmlCommentEditorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit XML Comment";
            this.ResumeLayout(false);

        }
        #endregion

        public string XmlComment
        {
            get { return txtXmlComment.Text; }
            set { txtXmlComment.Text = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            int caretPosition = txtXmlComment.SelectionStart;

            string result = txtXmlComment.Text.Substring(0, caretPosition) + " <c></c> ";
            if (txtXmlComment.SelectionStart < txtXmlComment.Text.Length)
            {
                result += txtXmlComment.Text.Substring(caretPosition);
            }

            txtXmlComment.Text = result;
            // Move caret to <c>|</c>
            txtXmlComment.SelectionStart = caretPosition + 4;
            txtXmlComment.Focus();
        }

        private void btnCode_Click(object sender, EventArgs e)
        {
            int caretPosition = txtXmlComment.SelectionStart;

            string result = txtXmlComment.Text.Substring(0, caretPosition) + "\r\n<code></code>\r\n";
            if (txtXmlComment.SelectionStart < txtXmlComment.Text.Length)
            {
                result += txtXmlComment.Text.Substring(caretPosition);
            }

            txtXmlComment.Text = result;
            // Move caret to <code>|</code>
            txtXmlComment.SelectionStart = caretPosition + 8;
            txtXmlComment.Focus();
        }

        private void btnPara_Click(object sender, EventArgs e)
        {
            int caretPosition = txtXmlComment.SelectionStart;

            string result = txtXmlComment.Text.Substring(0, caretPosition) + "\r\n<para></para>\r\n";
            if (txtXmlComment.SelectionStart < txtXmlComment.Text.Length)
            {
                result += txtXmlComment.Text.Substring(caretPosition);
            }

            txtXmlComment.Text = result;
            // Move caret to <para>|</para>
            txtXmlComment.SelectionStart = caretPosition + 8;
            txtXmlComment.Focus();
        }

        private void btnSee_Click(object sender, EventArgs e)
        {
            int caretPosition = txtXmlComment.SelectionStart;

            string result = txtXmlComment.Text.Substring(0, caretPosition) + " <see cref=\"\" /> ";
            if (txtXmlComment.SelectionStart < txtXmlComment.Text.Length)
            {
                result += txtXmlComment.Text.Substring(caretPosition);
            }

            txtXmlComment.Text = result;
            // Move caret to <see cref="|" />
            txtXmlComment.SelectionStart = caretPosition + 12;
            txtXmlComment.Focus();
        }
    }
}