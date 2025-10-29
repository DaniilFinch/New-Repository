using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class UserManagementForm : Form
    {
        private DatabaseHelper dbHelper;
        private string currentUserRole;
        private string currentUsername;

        public UserManagementForm(string role = "User", string username = "")
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            currentUserRole = role;
            currentUsername = username;

            InitializeInterface();
            LoadUsers();
        }

        private void InitializeInterface()
        {
            this.Text = $"Управление пользователями - Текущий пользователь: {currentUsername} ({currentUserRole})";

            // Скрываем элементы управления для обычных пользователей
            if (currentUserRole != "Admin")
            {
                btnUpdateRole.Visible = false;
                groupBoxAdmin.Visible = false;
                labelAdminInfo.Text = "У вас нет прав для управления пользователями";
                labelAdminInfo.Visible = true;
            }
            else
            {
                groupBoxAdmin.Text = "Панель администратора";
                labelAdminInfo.Text = "Вы можете управлять ролями пользователей";
                labelAdminInfo.Visible = true;
            }
        }

        private void LoadUsers()
        {
            try
            {
                DataTable users = dbHelper.GetUsers();
                dataGridViewUsers.DataSource = users;

                // Настройка столбцов для лучшего отображения
                dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewUsers.Columns["ID"].Visible = false; // Скрываем ID

                // Настраиваем заголовки
                dataGridViewUsers.Columns["Username"].HeaderText = "Логин";
                dataGridViewUsers.Columns["Role"].HeaderText = "Роль";
                dataGridViewUsers.Columns["IsActive"].HeaderText = "Активен";

                // Форматирование столбца IsActive
                if (dataGridViewUsers.Columns["IsActive"] != null)
                {
    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке пользователей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateRole_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.CurrentRow != null)
            {
                int userId = Convert.ToInt32(dataGridViewUsers.CurrentRow.Cells["ID"].Value);
                string username = dataGridViewUsers.CurrentRow.Cells["Username"].Value.ToString();
                string currentRole = dataGridViewUsers.CurrentRow.Cells["Role"].Value.ToString();

                // Не позволяем изменять свою собственную роль
                if (username == currentUsername)
                {
                    MessageBox.Show("Вы не можете изменить свою собственную роль!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string newRole = currentRole == "Admin" ? "User" : "Admin";

                if (MessageBox.Show($"Вы уверены, что хотите изменить роль пользователя '{username}' на '{newRole}'?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dbHelper.UpdateUserRole(userId, newRole))
                    {
                        MessageBox.Show("Роль пользователя успешно изменена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при изменении роли", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя для изменения роли", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUsers.CurrentRow != null && currentUserRole == "Admin")
            {
                string username = dataGridViewUsers.CurrentRow.Cells["Username"].Value.ToString();
                string role = dataGridViewUsers.CurrentRow.Cells["Role"].Value.ToString();
                bool isActive = Convert.ToBoolean(dataGridViewUsers.CurrentRow.Cells["IsActive"].Value);

                labelSelectedUser.Text = $"Выбран: {username} | Роль: {role} | Статус: {(isActive ? "Активен" : "Неактивен")}";
            }
        }
    }
}