using MySql.Data.MySqlClient;

namespace gyakorlas
{
    public class Connect
    {
        public MySqlConnection connection;
        private string Host;
        private string DbName;
        private string UserName;
        private string Password;
        private string ConnectionString;

        public Connect()
        {
            Host = "127.0.0.1";
            DbName = "db_user_test";
            UserName = "root";
            Password = "";

            //ConnectionString = "Host="+Host+";Database="+DbName+";User="+UserName+";Password="+Password+";SslMode=none";

            ConnectionString = $"Host={Host};Database={DbName};User={UserName};Password={Password}";

            connection = new MySqlConnection(ConnectionString);

        }

    }
}
