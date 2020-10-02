using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class WebserverCrud
    {
        public string hostname = "192.168.1.177";
        public int port = 80;

        public void Connect(TcpClient client)
        {
            DataFactory df = new DataFactory();
            client.Connect(hostname, port);
        }
        public void Write(NetworkStream netStream)
        {
            BinaryWriter writer = new BinaryWriter(netStream);
            writer.Write('\n');
        }
        public List<float> Read(NetworkStream netStream)
        {
            List<float> readings = new List<float>();
            using (StreamReader sr = new StreamReader(netStream))
            {
                float x = float.Parse(sr.ReadLine());
                float y = float.Parse(sr.ReadLine());
                readings.Add(x);
                readings.Add(y);
                return readings;
            }
        }
    }
}
