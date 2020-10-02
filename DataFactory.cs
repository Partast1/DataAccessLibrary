using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class DataFactory
    {
        //Webserver
        public TcpClient CreateTcpClient()
        {
            TcpClient Client = new TcpClient();
            return Client;
        }
        //Database
        //public SqlConnection CreateSqlCon(string connString)
        //{
        //    SqlConnection conn = new SqlConnection(connString);
        //    return conn;
        //}
        public SqlCommand CreateCommand()
        {
            SqlCommand cmd = new SqlCommand();
            return cmd;
        }


    }
}
