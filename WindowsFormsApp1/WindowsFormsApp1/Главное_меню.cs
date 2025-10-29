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

    public partial class Главное_меню : Form
    {
        private string currentUserRole;
        private string currentUsername;
        public Главное_меню(string role = "User", string username = "")
        {
            InitializeComponent();
            currentUserRole = role;
            currentUsername = username;
            InitializeInterface();
            InitializeAdminFeatures();
        }

        private void InitializeInterface()
        {

          
            if (currentUserRole == "Admin")
            {
                this.Text = $"Главное меню - {currentUsername} Администратор";
                // Администратор видит все кнопки
                button2.Visible = true;
            }
            else
            {
                this.Text = $"Главное меню - {currentUsername} Пользователь";

                button2.Visible = false;
            }
        }
        private void InitializeAdminFeatures()
        {
            
            if (currentUserRole == "Admin")
            {
                button2.Click += (s, e) =>
                {

                    UserManagementForm userManagementForm = new UserManagementForm(currentUserRole, currentUsername);
                    userManagementForm.Show();
                };

                this.Controls.Add(button2);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form1 af = new Form1(currentUserRole, currentUsername);
            af.Show();
        }

        private void Главное_меню_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Login Login = new Login();
            Login.Show();
        }
    }
}
