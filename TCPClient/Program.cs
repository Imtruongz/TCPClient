using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TCPClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // B1: Tạo IpEndPoint của Server
                IPEndPoint s_iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
                // B2: Tạo Socket theo TCP để kết nối đến Server
                Socket client = new Socket(SocketType.Stream, ProtocolType.Tcp);
                // B3: Kết nối đến server thông qua IPEndPoint
                client.Connect(s_iep);
                Console.WriteLine("Ket noi thanh cong den Server!");
                // B4: Xử lý gửi/nhận gói tin với Server
                // B4.1: Client gửi gói tin lên Server
                string send = "Hello world!\n";
                byte[] sendData = ASCIIEncoding.ASCII.GetBytes(send);
                client.Send(sendData, sendData.Length, SocketFlags.None);
                // B4.2: Client nhận phản hồi từ Server
                byte[] receiveData = new byte[1024];
                int len = client.Receive(receiveData);
                string message = ASCIIEncoding.ASCII.GetString(receiveData, 0, len);
                Console.WriteLine("<Server>: " + message);
                // B?: Đóng kết nối
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi: " + e.Message);
            }
            Console.ReadKey();
        }
    }
}
