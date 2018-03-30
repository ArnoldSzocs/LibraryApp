using System;
using System.Collections.Generic;
using MySql.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LibraryApp.Connection
{
    class ConnectionManager
    {
        private static ConnectionManager connectionManager;

        private MySqlConnection connection;
        private const string DB = "Server=localhost;database=library;Uid=root;Pwd=;";



        private ConnectionManager() {
            connection = new MySqlConnection(DB);
            connection.Open();
        }

        public static ConnectionManager GetConnection()
        {
            if(connectionManager == null)
            {
                connectionManager = new ConnectionManager();
            }
            return connectionManager;

        }

        public void ExecuteQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query,connection);
            command.ExecuteNonQuery();
        }

        public MySqlDataReader ReadQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            return command.ExecuteReader();
        }
       
    }
}
