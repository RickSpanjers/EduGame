using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.DBContext
{
    public abstract class ConnectionHelper
    {
        private string host = "studmysql01.fhict.local";
        private string database = "dbi385070";
        private string user = "dbi385070";
        private string password = "GENK";
        private string connectionString;

        public MySqlConnection ReturnSQLConnection()
        {
            connectionString = "Server=" + host + ";Database=" + database + ";User=" + user + ";Password=" + password + ";Pooling=";
            MySqlConnection cnn = new MySqlConnection(connectionString);

            if (cnn.State != ConnectionState.Open)
            {
                cnn.Open();
            }

            return cnn;
        }

    }
}
