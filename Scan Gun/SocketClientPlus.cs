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
        bool heartBeatFlag = false;  //�Ƿ��������͵ı�־
        const string heartMessage = ",";  //�������ַ���

        DateTime time;
        Socket m_clientSocket;  //����socket
        IPEndPoint m_serverEndPoint;  //����IPEndPointoint
        Thread m_work;  //���幤���߳�

        /// <summary>
        /// ʹ��IPEndPoint����Socket
        /// </summary>
        /// <param name="serverEndPoint"></param>
        public SocketClientPlus(IPEndPoint serverEndPoint)
        {
            time = DateTime.Now;
            heartBeatFlag = true;
            m_serverEndPoint = serverEndPoint;
            m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            m_clientSocket.Connect(m_serverEndPoint);

            //�������߳�
            //m_work = new Thread(HeartBeat);
            //m_work.IsBackground = true;
            //m_work.Start();
        }

        /// <summary>
        /// ����
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
        /// ����������15�뷢��һ��
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
        /// �������ݣ�ASCII��ʽ��
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Send(string message)
        {
            try
            {
                Byte[] sendBytes = Encoding.UTF8.GetBytes(message);
                m_clientSocket.Send(sendBytes);
                time = DateTime.Now;//��¼����ʱ��
                return true;
            }
            catch(Exception ex)
            {
                ReConnect();  //����ʧ�ܣ�����
                return false;
            }
        }

        /// <summary>
        /// �ر�Socket
        /// </summary>
        public Boolean Close()
        {
            try
            {
                //heartBeatFlag = false;  //�ر���������
                //try
                //{
                //    m_work.Join(1000);//�ȴ�1s ���߳����㹻��ʱ������ѭ��
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
