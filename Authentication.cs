using System;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;

namespace AccessDBViewer
{
    public class Authentication
    {
        private readonly string connectionString;

        public Authentication(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool AuthenticateUser(string username, string password)
        {
            try
            {
                string storedHashedPassword = GetStoredHashedPassword(username);

                if (string.IsNullOrEmpty(storedHashedPassword))
                {
                    return false;
                }

                string hashedPassword = HashPassword(password);

                return string.Equals(hashedPassword, storedHashedPassword, StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка аутентификации: " + ex.Message);
                return false;
            }
        }

        private string GetStoredHashedPassword(string username)
        {
            string hashedPassword = null;

            string query = "SELECT PasswordHash FROM Users WHERE Username = ?";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        hashedPassword = result.ToString();
                    }
                }
            }

            return hashedPassword;
        }

        private static string HashPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        private bool UserExists(string username)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Username = ?";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0;
                }
            }
        }

        public bool RegisterUser(string username, string password)
        {
            if (UserExists(username))
            {
                return false;
            }

            try
            {
                string hashedPassword = HashPassword(password);

                string query = "INSERT INTO Users (Username, PasswordHash) VALUES (?, ?)";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        command.Parameters.AddWithValue("@PasswordHash",hashedPassword);

                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка регистрации: " + ex.Message);
                return false;
            }
        }
    }
}