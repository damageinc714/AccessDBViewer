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
        //метод аутентификации пользователя
        public bool AuthenticateUser(string username, string password)
        {
            try
            {
                string storedHashedPassword = GetStoredHashedPassword(username);

                string hashedPassword = HashPassword(password);
                //сравниваенм только что введённый пароль и пароль в базе
                return hashedPassword == storedHashedPassword;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка аутентификации: " + ex.Message);
                return false;
            }
        }
        //метод получения хэшированного пароля
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
                    //возвращаем первую строку и столбец результата
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)//обьекта либо нет в таблице либо значение в бд = NULL
                    {
                        hashedPassword = result.ToString();
                    }
                }
            }

            return hashedPassword;
        }       

        //метод хэшированния пароля
        private static string HashPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
        
        //проверка существует ли пользователь в таблице
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
        //метод регистрации
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

                        command.Parameters.AddWithValue("@PasswordHash", hashedPassword);

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