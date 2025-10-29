using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        private DatabaseHelper dbHelper;
        public Login()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, введите имя пользователя и пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string role = dbHelper.ValidateUser(username, password);

                if (role != null)
                {
                    MessageBox.Show($"Вход выполнен успешно! Роль: {role}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Открываем главное меню с передачей роли и имени пользователя
                    Главное_меню Главное_меню = new Главное_меню(role, username);
                    Главное_меню.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при входе: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            dbHelper.InitializeDatabase();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register af = new Register();
            af.Owner = this;
            af.Show();
        }

        private void Login_Load_1(object sender, EventArgs e)
        {

        }
    }
}
