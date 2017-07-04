using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Scan_Gun
{
    static class SocketPlus
    {
        /// <summary>
        /// ʹ��Socket��ָ�� IP & Port �������ݣ�UTF8��ʽ��������ָ��IP�Ƿ������
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Send(string ip, int port, string str)
        {
            //byte[] byteReceive = null;
            Byte[] sendBytes = Encoding.UTF8.GetBytes(str);
            try
            {
                IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(ip), port);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                socket.Connect(ipe);
                socket.Send(sendBytes);

                Thread.Sleep(1000);
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message + "@@@" + ex.StackTrace;
            }

        }
    }
}
