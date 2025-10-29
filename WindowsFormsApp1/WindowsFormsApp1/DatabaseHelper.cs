using System;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class DatabaseHelper
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Практика\WindowsFormsApp1\WindowsFormsApp1\bin\x64\Debug\dnevnik.accdb";

        public void InitializeDatabase()
        {
            try
            {
                // Просто пытаемся подключиться к базе
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    MessageBox.Show("Подключение к базе данных успешно!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к БД: {ex.Message}\n\nСоздайте таблицу Users вручную в Access.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string ValidateUser(string username, string password)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT [Password], Role FROM Users WHERE Username = ? AND IsActive = True";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedPassword = reader["Password"].ToString();
                                string role = reader["Role"].ToString();

                                if (password == storedPassword)
                                {
                                    return role;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при входе: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return null;
        }

        public bool RegisterUser(string username, string password, string email)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Проверяем, существует ли пользователь
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = ?";
                    using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.Add("?", OleDbType.VarChar).Value = username;
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Пользователь с таким именем уже существует", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    

                    // Упрощенный INSERT запрос для Access
                    string insertQuery = @"INSERT INTO Users 
                                (Username, [Password], Email, Role, IsActive) 
                                VALUES 
                                (?, ?, ?, ?, ?)";

                    using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn))
                    {
                        // Password - зарезервированное слово в Access, используем [Password]
                        insertCmd.Parameters.Add("?", OleDbType.VarChar).Value = username;
                        insertCmd.Parameters.Add("?", OleDbType.VarChar).Value = password;
                        insertCmd.Parameters.Add("?", OleDbType.VarChar).Value = email;
                        insertCmd.Parameters.Add("?", OleDbType.VarChar).Value = "User";
                        insertCmd.Parameters.Add("?", OleDbType.Boolean).Value = true;

                        int result = insertCmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Регистрация прошла успешно!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // Остальные методы остаются без изменений...
        public DataTable GetUsers()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ID, Username, Role, IsActive FROM Users";
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки пользователей: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new DataTable(); // Возвращаем пустую таблицу вместо null
                }
            }
        }

        public bool UpdateUserRole(int userId, string newRole)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Users SET Role = ? WHERE ID = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@role", newRole);
                        cmd.Parameters.AddWithValue("@id", userId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка изменения роли: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

    }
}