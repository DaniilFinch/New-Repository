namespace WindowsFormsApp2
{
    partial class UserManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.groupBoxAdmin = new System.Windows.Forms.GroupBox();
            this.labelSelectedUser = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnUpdateRole = new System.Windows.Forms.Button();
            this.labelAdminInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.groupBoxAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.AllowUserToAddRows = false;
            this.dataGridViewUsers.AllowUserToDeleteRows = false;
            this.dataGridViewUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.ReadOnly = true;
            this.dataGridViewUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsers.Size = new System.Drawing.Size(776, 300);
            this.dataGridViewUsers.TabIndex = 0;
            this.dataGridViewUsers.SelectionChanged += new System.EventHandler(this.dataGridViewUsers_SelectionChanged);
            // 
            // groupBoxAdmin
            // 
            this.groupBoxAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAdmin.Controls.Add(this.labelSelectedUser);
            this.groupBoxAdmin.Controls.Add(this.btnClose);
            this.groupBoxAdmin.Controls.Add(this.btnRefresh);
            this.groupBoxAdmin.Controls.Add(this.btnUpdateRole);
            this.groupBoxAdmin.Location = new System.Drawing.Point(12, 350);
            this.groupBoxAdmin.Name = "groupBoxAdmin";
            this.groupBoxAdmin.Size = new System.Drawing.Size(776, 88);
            this.groupBoxAdmin.TabIndex = 1;
            this.groupBoxAdmin.TabStop = false;
            this.groupBoxAdmin.Text = "Панель администратора";
            // 
            // labelSelectedUser
            // 
            this.labelSelectedUser.AutoSize = true;
            this.labelSelectedUser.Location = new System.Drawing.Point(6, 25);
            this.labelSelectedUser.Name = "labelSelectedUser";
            this.labelSelectedUser.Size = new System.Drawing.Size(81, 13);
            this.labelSelectedUser.TabIndex = 5;
            this.labelSelectedUser.Text = "Выбран: никто";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.LightCoral;
            this.btnClose.Location = new System.Drawing.Point(695, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.LightGreen;
            this.btnRefresh.Location = new System.Drawing.Point(614, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnUpdateRole
            // 
            this.btnUpdateRole.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnUpdateRole.Location = new System.Drawing.Point(6, 45);
            this.btnUpdateRole.Name = "btnUpdateRole";
            this.btnUpdateRole.Size = new System.Drawing.Size(113, 23);
            this.btnUpdateRole.TabIndex = 1;
            this.btnUpdateRole.Text = "Изменить роль";
            this.btnUpdateRole.UseVisualStyleBackColor = false;
            this.btnUpdateRole.Click += new System.EventHandler(this.btnUpdateRole_Click);
            // 
            // labelAdminInfo
            // 
            this.labelAdminInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAdminInfo.Location = new System.Drawing.Point(12, 315);
            this.labelAdminInfo.Name = "labelAdminInfo";
            this.labelAdminInfo.Size = new System.Drawing.Size(776, 32);
            this.labelAdminInfo.TabIndex = 2;
            this.labelAdminInfo.Text = "Информация для администратора";
            this.labelAdminInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelAdminInfo);
            this.Controls.Add(this.groupBoxAdmin);
            this.Controls.Add(this.dataGridViewUsers);
            this.Name = "UserManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление пользователями";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.groupBoxAdmin.ResumeLayout(false);
            this.groupBoxAdmin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.GroupBox groupBoxAdmin;
        private System.Windows.Forms.Button btnUpdateRole;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labelAdminInfo;
        private System.Windows.Forms.Label labelSelectedUser;
    }
}