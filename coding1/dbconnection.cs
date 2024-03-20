using MySql.Data.MySqlClient;

namespace coding1
{
    internal class dbconnection
    {
        // Define a method to establish and return a MySqlConnection object
        public static MySqlConnection GetConnection()
        {
            // Connection string to connect to the MySQL database
            string connectionString = "server=localhost;user=root;password=;database=project;";

            // Create and return MySqlConnection object with the connection string
            return new MySqlConnection(connectionString);
        }
    }
}
