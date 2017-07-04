using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.Sockets;

namespace Scan_Gun
{
    class SocketClientPlus
    { 
        bool heartBeatFlag = false;  //是否心跳发送的标志
        const string heartMessage = ",";  //心跳包字符串

        DateTime time;
        Socket m_clientSocket;  //定义socket
        IPEndPoint m_serverEndPoint;  //定义IPEndPointoint
        Thread m_work;  //定义工作线程

        /// <summary>
        /// 使用IPEndPoint连接Socket
        /// </summary>
        /// <param name="serverEndPoint"></param>
        public SocketClientPlus(IPEndPoint serverEndPoint)
        {
            time = DateTime.Now;
            heartBeatFlag = true;
            m_serverEndPoint = serverEndPoint;
            m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            m_clientSocket.Connect(m_serverEndPoint);

            //心跳包线程
            //m_work = new Thread(HeartBeat);
            //m_work.IsBackground = true;
            //m_work.Start();
        }

        /// <summary>
        /// 重连
        /// </summary>
        private void ReConnect()
        {
            try
            {
                time = DateTime.Now;
                m_clientSocket.Close();
                m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                m_clientSocket.Connect(m_serverEndPoint);
            }
            catch
            {
 
            }
        }

        /// <summary>
        /// 心跳函数，15秒发送一次
        /// </summary>
        private void HeartBeat()
        {
            while (heartBeatFlag)
            {
                try
                {
                    TimeSpan ts = DateTime.Now - time;
                    if (ts.TotalSeconds > 15)
                    {
                        Send(heartMessage);
                    }
                }
                catch
                { }
                Thread.Sleep(100);
            }
  
        }

        /// <summary>
        /// 发送数据（ASCII格式）
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Send(string message)
        {
            try
            {
                Byte[] sendBytes = Encoding.UTF8.GetBytes(message);
                m_clientSocket.Send(sendBytes);
                time = DateTime.Now;//记录发送时间
                return true;
            }
            catch(Exception ex)
            {
                ReConnect();  //发送失败，重连
                return false;
            }
        }

        /// <summary>
        /// 关闭Socket
        /// </summary>
        public Boolean Close()
        {
            try
            {
                //heartBeatFlag = false;  //关闭心跳发送
                //try
                //{
                //    m_work.Join(1000);//等待1s 让线程有足够的时间跳出循环
                //}
                //catch
                //{
                //    m_work.Abort();
                //}
                m_clientSocket.Shutdown(SocketShutdown.Both);
                m_clientSocket.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
