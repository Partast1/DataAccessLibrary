using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempClassLibrary;

namespace DataAccessLibrary
{
    public class DatabaseCrud
    {
        private string connString = @"Server=(localdb)\MSSQLLocalDB;Database=IndoorEnvironmentDB;Trusted_Connection = True;";
        public SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
        public void ConnectionOpen(SqlConnection conn)
        {
            conn.Open();
        }
        public void ConnectionClose(SqlConnection conn)
        {
            conn.Close();
        }
        public SqlCommand Command(string query, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            return cmd;
        }
        //Device
        public void WriteDevice(float Humid, float Temperature)
        {
            SqlConnection conn = Connect();
            string query = "INSERT into Reading (Humidity, Temperature) VALUES (@Humidity, @Temperature)";
            SqlCommand cmd = Command(query, conn);
            ConnectionOpen(conn);
            cmd.Parameters.AddWithValue("@Humidity", Humid);
            cmd.Parameters.AddWithValue("@Temperature", Temperature);
            cmd.ExecuteNonQuery();
            ConnectionClose(conn);
        }
        public List<Device> ReadDevice()
        {
            List<Device> devices = new List<Device>();
            SqlConnection conn = Connect();
            string query = "SELECT Temperature, Humidity FROM Reading";
            SqlCommand cmd = new SqlCommand(query, conn);
            ConnectionOpen(conn);
            using (SqlDataReader dataReader = cmd.ExecuteReader())

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        //Works
                        var x = (float)(Double)dataReader.GetDouble(0);
                        var y = (float)(Double)dataReader.GetDouble(1);
                        Device dev = new Device(x, y);
                        devices.Add(dev);
                    }
                }
                else
                {
                    Console.WriteLine("No data found.");
                }
            ConnectionClose(conn);
            return devices;
        }
        //Room
        public List<Room> ReadRoom()
        {
            List<Room> rooms = new List<Room>();
            SqlConnection conn = Connect();
            string query = "SELECT RoomNumber, Hall FROM Room";
            SqlCommand cmd = new SqlCommand(query, conn);
            ConnectionOpen(conn);
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    var x = dataReader.GetInt32(0);
                    var y = dataReader.GetString(1);
                    Room room = new Room(x, y);
                    rooms.Add(room);
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }
            ConnectionClose(conn);
            return rooms;

        }
    }
}
