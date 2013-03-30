using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CslaGenerator.Data
{
    /// <summary>
    /// Summary description for ConnectionForm.
    /// </summary>
    public class ConnectionForm : Form
    {
        private SqlConnection _conn;
        private TextBox txtServer;
        private Label lblServer;
        private Label lblDatabase;
        private TextBox txtDatabase;
        private Label lblUser;
        private TextBox txtUser;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnOK;
        private Button btnCancel;
        private CheckBox chkSecurityWindows;

        /*/// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components;*/

        public ConnectionForm()
        {
            InitializeComponent();
            txtServer.Text = ConnectionFactory.Server;
            txtDatabase.Text = ConnectionFactory.Database;
            txtUser.Text = ConnectionFactory.User;
            txtPassword.Text = ConnectionFactory.Password;
            chkSecurityWindows.Checked = ConnectionFactory.IntegratedSecurity;
        }

        /*/// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }*/

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkSecurityWindows = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(80, 16);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(192, 23);
            this.txtServer.TabIndex = 0;
            this.txtServer.Text = "";
            // 
            // lblServer
            // 
            this.lblServer.Location = new System.Drawing.Point(32, 16);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(48, 23);
            this.lblServer.TabIndex = 1;
            this.lblServer.Text = "Server";
            // 
            // lblDatabase
            // 
            this.lblDatabase.Location = new System.Drawing.Point(16, 48);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(64, 23);
            this.lblDatabase.TabIndex = 3;
            this.lblDatabase.Text = "Database";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(80, 48);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(192, 23);
            this.txtDatabase.TabIndex = 1;
            this.txtDatabase.Text = "";
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(40, 112);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(32, 23);
            this.lblUser.TabIndex = 5;
            this.lblUser.Text = "User";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(80, 112);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(192, 23);
            this.txtUser.TabIndex = 3;
            this.txtUser.Text = "";
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(16, 144);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(64, 23);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(80, 144);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(192, 23);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Text = "";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(56, 184);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 32);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(152, 184);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkSecurityWindows
            // 
            this.chkSecurityWindows.Location = new System.Drawing.Point(80, 80);
            this.chkSecurityWindows.Name = "chkSecurityWindows";
            this.chkSecurityWindows.Size = new System.Drawing.Size(184, 24);
            this.chkSecurityWindows.TabIndex = 2;
            this.chkSecurityWindows.Text = "Use Integrated Security";
            this.chkSecurityWindows.CheckedChanged += new System.EventHandler(this.chkSecurityWindows_CheckedChanged);
            // 
            // ConnectionForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(292, 228);
            this.Controls.Add(this.chkSecurityWindows);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.txtServer);
            this.Font = new System.Drawing.Font("Trebuchet MS", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connect to database";
            this.ResumeLayout(false);

        }

        #endregion

        public SqlConnection Connection
        {
            get { return _conn; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (TryConnection())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool TryConnection()
        {
            try
            {
                if (txtServer.Text == String.Empty && txtDatabase.Text == String.Empty)
                {
                    MessageBox.Show(this, @"You must specify a Server and a Database.");
                    return false;
                }
                if (!chkSecurityWindows.Checked && txtUser.Text == String.Empty)
                {
                    MessageBox.Show(this, @"You must specify a Username.");
                    return false;
                }
                ConnectionFactory.Server = txtServer.Text;
                ConnectionFactory.Database = txtDatabase.Text;
                ConnectionFactory.User = txtUser.Text;
                ConnectionFactory.Password = txtPassword.Text;
                ConnectionFactory.IntegratedSecurity = chkSecurityWindows.Checked;
                _conn = ConnectionFactory.NewConnection;
                _conn.Open();
                _conn.Close();
                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show(this, @"Error while attempting to connect. " + Environment.NewLine + e.Message);
                return false;
            }
        }

        private void chkSecurityWindows_CheckedChanged(object sender, EventArgs e)
        {
            txtUser.Enabled = !chkSecurityWindows.Checked;
            txtPassword.Enabled = !chkSecurityWindows.Checked;
        }
    }
}
