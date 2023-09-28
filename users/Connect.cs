using MySql.Data.MySqlClient;

namespace users
{
    public class Connect
    {
        public MySqlConnection connection;
        private string Host;
        private string DbName;
        private string Username;
        private string Password;
        private string ConnectionString;

        public Connect() 
        {
            this.Host = "localhost";
            this.DbName = "dbuser";
            this.Username = "root";
            this.Password = "";
            this.ConnectionString = $"Host={Host};Database={DbName};User={Username};Password={Password};Ssl Mode=None";
            this.connection = new MySqlConnection(ConnectionString);
        }
    }
}
