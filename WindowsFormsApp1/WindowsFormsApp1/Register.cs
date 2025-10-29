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
    public partial class Register : Form
    {
		private DatabaseHelper dbHelper;
        public Register()
        {
            InitializeComponent();
			dbHelper = new DatabaseHelper();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            string confirmPassword = textBox3.Text.Trim();
            string email = textBox4.Text.Trim();

            // Валидация данных
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Пароль должен содержать минимум 6 символов.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (dbHelper.RegisterUser(username, password, email))
                {
                    MessageBox.Show("Регистрация прошла успешно!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Возвращаемся к логину
                    this.Close();
                    Login loginForm = new Login();
                    loginForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
