using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string currentUserRole;
        private string currentUsername;
        public Form1(string role = "User", string username = "")
        {
            InitializeComponent();
            currentUserRole = role;
            currentUsername = username;
            InitializeInterface();
        }

        private void InitializeInterface()
        {
            

            dataGridView1.ReadOnly = (currentUserRole != "Admin"); // Только для чтения если не админ
            dataGridView1.AllowUserToDeleteRows = (currentUserRole == "Admin");


            if (currentUserRole == "Admin")
            {
                this.Text = $"Form 1 - {currentUsername} Администратор (полный доступ)";

                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
            }
            else
            {
                this.Text = $"Form 1 - {currentUsername} Пользователь (доступно в режиме просмотра)";

                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dnevnikDataSet.Ученики". При необходимости она может быть перемещена или удалена.
            this.ученикиTableAdapter.Fill(this.dnevnikDataSet.Ученики);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ученикиTableAdapter.Update(dnevnikDataSet);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddForm af = new AddForm();
            af.Owner = this;
            af.Show();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchForm sf = new SearchForm();
            sf.Owner = this;
            sf.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
