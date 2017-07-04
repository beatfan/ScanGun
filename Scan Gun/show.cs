using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol.Barcode2;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Scan_Gun
{
    public partial class show : Form
    {
        private static bool bPortrait = true;   // 默认显示方向（横屏/竖屏）
        // has been set to Portrait.

        private bool bSkipMaxLen = false;    // 最大限度的限制
        // physical length is considered by default.

        private bool bInitialScale = true;   // The flag to track whether the 
        // scaling logic is applied for
        // the first time (from scatch) or not.
        // Based on that, the (outer) width/height values
        // of the form will be set or not.
        // Initially set to true.

        private int resWidthReference = 240;   //表格缓存宽度，防止显示失真
        // INITIALLY HAS TO BE SET TO THE WIDTH OF THE FORM AT DESIGN TIME (IN PIXELS).
        // This setting is also obtained from the platform only on
        // Windows CE devices before running the application on the device, as a verification.
        // For PocketPC (& Windows Mobile) devices, the failure to set this properly may result in the distortion of GUI/viewability.

        private int resHeightReference = 268;  // 表格缓存高度
        // INITIALLY HAS TO BE SET TO THE HEIGHT OF THE FORM AT DESIGN TIME (IN PIXELS).
        // This setting is also obtained from the platform only on
        // Windows CE devices before running the application on the device, as a verification.
        // For PocketPC (& Windows Mobile) devices, the failure to set this properly may result in the distortion of GUI/viewability.

        private const double maxLength = 5.5;  // 样品（英寸）最大的宽度和高度
        // The actual value on the device may slightly deviate from this
        // since the calculations based on the (received) DPI & resolution values 
        // would provide only an approximation, so not 100% accurate.

        SocketClientPlus client = null;
        string localIP;
        string serverIP; //服务器IP
        int serverPort;
        string path = "Server.txt";

        public show()
        {
            InitializeComponent();

            this.ScanDataShow.Focus();  //聚焦到表格1
        }

        #region<启动加载>
        private void Show_Load(object sender, EventArgs e)
        {
            // Add MainMenu if Pocket PC
            //if (Symbol.Win32.PlatformType.IndexOf("PocketPC") != -1)
            //{
            //    this.Menu = this.mainMenu1;
            //}
            this.WindowState = FormWindowState.Maximized;
            //取本机IP列表 
            IPAddress[] ips_Local = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            //显示本机IP
            foreach (IPAddress v in ips_Local)
            {
                localIP = v.ToString();
                ScanStatue.Text += "   " + localIP;
            }

            if (File.Exists(path))
            {
                //获取IP和Port
                using (StreamReader objReader = new StreamReader(path, Encoding.ASCII))
                {
                    string str = objReader.ReadLine();
                    serverIP = str.Split(',')[0];
                    serverPort = int.Parse(str.Split(',')[1]);
                    objReader.Close();
                }
                
            }
            else
            {
                string ipPort = "192.168.10.180,12345";
                 //创建配置文件
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(ipPort);
                    sw.Close();
                }
            }

            if (!connect())
                MessageBox.Show("服务器连接失败，请重试");

        }
        #endregion


        #region<初始化视窗>
        /// <summary>
        /// 初始化视窗
        /// </summary>
        public void DoScale()
        {
            if (Screen.PrimaryScreen.Bounds.Width > Screen.PrimaryScreen.Bounds.Height)  //若是横屏
            {
                bPortrait = false; // 标志位false
            }

            if (this.WindowState == FormWindowState.Maximized)    // 窗体最大化
            {
                this.bSkipMaxLen = true; // 限制最大
            }

            if ((Symbol.Win32.PlatformType.IndexOf("WinCE") != -1) || (Symbol.Win32.PlatformType.IndexOf("WindowsCE") != -1) || (Symbol.Win32.PlatformType.IndexOf("Windows CE") != -1)) // 属于Win CE设备
            {
                this.resWidthReference = this.Width;   // The width of the form at design time (in pixels) is obtained from the platorm.
                this.resHeightReference = this.Height; // The height of the form at design time (in pixels) is obtained from the platform.
            }

            Scale(this); // 初始化扫描窗体
        }
        #endregion

        #region<初始化扫描视窗>
        /// <summary>
        /// This function scales the given Form & its child controls in order to
        /// make them completely viewable, based on the screen width & height.
        /// </summary>
        private static void Scale(show frm)
        {
            int PSWAW = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;    // 工作区宽度.
            int PSWAH = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;   // 工作区高度

            if (!((Screen.PrimaryScreen.Bounds.Width <= (1.5) * (Screen.PrimaryScreen.Bounds.Height))
            && (Screen.PrimaryScreen.Bounds.Height <= (1.5) * (Screen.PrimaryScreen.Bounds.Width))))  //比例小于3:2
            {
                if ((Screen.PrimaryScreen.Bounds.Width) > (Screen.PrimaryScreen.Bounds.Height))
                {
                    PSWAW = (int)((1.33) * PSWAH);  // If the width/height ratio goes beyond 1.5,
                    // the (longer) effective width is made shorter.
                }

            }

            System.Drawing.Graphics graphics = frm.CreateGraphics();

            float dpiX = graphics.DpiX; // Get the horizontal DPI value.

            if (frm.bInitialScale == true) // If an initial scale (from scratch)
            {
                if (Symbol.Win32.PlatformType.IndexOf("PocketPC") != -1) // If the platform is either Pocket PC or Windows Mobile
                {
                    frm.Width = PSWAW;  // Set the form width. However this setting
                    // would be the ultimate one for Pocket PC (& Windows Mobile)devices.
                    // Just for the sake of consistency, it's explicitely specified here.
                }
                else
                {
                    frm.Width = (int)((frm.Width) * (PSWAW)) / (frm.resWidthReference); // Set the form width for others (Windows CE devices).

                }
            }
            if ((frm.Width <= maxLength * dpiX) || frm.bSkipMaxLen == true) // The calculation of the width & left values for each control
            // without taking the maximum length restriction into consideration.
            {
                foreach (System.Windows.Forms.Control cntrl in frm.Controls)
                {
                    cntrl.Width = ((cntrl.Width) * (frm.Width)) / (frm.resWidthReference);
                    cntrl.Left = ((cntrl.Left) * (frm.Width)) / (frm.resWidthReference);

                    if (cntrl is System.Windows.Forms.TabControl)
                    {
                        foreach (System.Windows.Forms.TabPage tabPg in cntrl.Controls)
                        {
                            foreach (System.Windows.Forms.Control cntrl2 in tabPg.Controls)
                            {
                                cntrl2.Width = (((cntrl2.Width) * (frm.Width)) / (frm.resWidthReference));
                                cntrl2.Left = (((cntrl2.Left) * (frm.Width)) / (frm.resWidthReference));
                            }
                        }
                    }
                }

            }
            else
            {   // The calculation of the width & left values for each control
                // with the maximum length restriction taken into consideration.
                foreach (System.Windows.Forms.Control cntrl in frm.Controls)
                {
                    cntrl.Width = (int)(((cntrl.Width) * (PSWAW) * (maxLength * dpiX)) / (frm.resWidthReference * (frm.Width)));
                    cntrl.Left = (int)(((cntrl.Left) * (PSWAW) * (maxLength * dpiX)) / (frm.resWidthReference * (frm.Width)));

                    if (cntrl is System.Windows.Forms.TabControl)
                    {
                        foreach (System.Windows.Forms.TabPage tabPg in cntrl.Controls)
                        {
                            foreach (System.Windows.Forms.Control cntrl2 in tabPg.Controls)
                            {
                                cntrl2.Width = (int)(((cntrl2.Width) * (PSWAW) * (maxLength * dpiX)) / (frm.resWidthReference * (frm.Width)));
                                cntrl2.Left = (int)(((cntrl2.Left) * (PSWAW) * (maxLength * dpiX)) / (frm.resWidthReference * (frm.Width)));
                            }
                        }
                    }
                }

                frm.Width = (int)((frm.Width) * (maxLength * dpiX)) / (frm.Width);

            }

            frm.resWidthReference = frm.Width; // Set the reference width to the new value.


            // A similar calculation is performed below for the height & top values for each control ...

            if (!((Screen.PrimaryScreen.Bounds.Width <= (1.5) * (Screen.PrimaryScreen.Bounds.Height))
            && (Screen.PrimaryScreen.Bounds.Height <= (1.5) * (Screen.PrimaryScreen.Bounds.Width))))
            {
                if ((Screen.PrimaryScreen.Bounds.Height) > (Screen.PrimaryScreen.Bounds.Width))
                {
                    PSWAH = (int)((1.33) * PSWAW);
                }

            }

            float dpiY = graphics.DpiY;

            if (frm.bInitialScale == true)
            {
                if (Symbol.Win32.PlatformType.IndexOf("PocketPC") != -1)
                {
                    frm.Height = PSWAH;
                }
                else
                {
                    frm.Height = (int)((frm.Height) * (PSWAH)) / (frm.resHeightReference);

                }
            }

            if ((frm.Height <= maxLength * dpiY) || frm.bSkipMaxLen == true)
            {
                foreach (System.Windows.Forms.Control cntrl in frm.Controls)
                {

                    cntrl.Height = ((cntrl.Height) * (frm.Height)) / (frm.resHeightReference);
                    cntrl.Top = ((cntrl.Top) * (frm.Height)) / (frm.resHeightReference);


                    if (cntrl is System.Windows.Forms.TabControl)
                    {
                        foreach (System.Windows.Forms.TabPage tabPg in cntrl.Controls)
                        {
                            foreach (System.Windows.Forms.Control cntrl2 in tabPg.Controls)
                            {
                                cntrl2.Height = ((cntrl2.Height) * (frm.Height)) / (frm.resHeightReference);
                                cntrl2.Top = ((cntrl2.Top) * (frm.Height)) / (frm.resHeightReference);
                            }
                        }
                    }

                }

            }
            else
            {
                foreach (System.Windows.Forms.Control cntrl in frm.Controls)
                {

                    cntrl.Height = (int)(((cntrl.Height) * (PSWAH) * (maxLength * dpiY)) / (frm.resHeightReference * (frm.Height)));
                    cntrl.Top = (int)(((cntrl.Top) * (PSWAH) * (maxLength * dpiY)) / (frm.resHeightReference * (frm.Height)));


                    if (cntrl is System.Windows.Forms.TabControl)
                    {
                        foreach (System.Windows.Forms.TabPage tabPg in cntrl.Controls)
                        {
                            foreach (System.Windows.Forms.Control cntrl2 in tabPg.Controls)
                            {
                                cntrl2.Height = (int)(((cntrl2.Height) * (PSWAH) * (maxLength * dpiY)) / (frm.resHeightReference * (frm.Height)));
                                cntrl2.Top = (int)(((cntrl2.Top) * (PSWAH) * (maxLength * dpiY)) / (frm.resHeightReference * (frm.Height)));
                            }
                        }
                    }

                }

                frm.Height = (int)((frm.Height) * (maxLength * dpiY)) / (frm.Height);

            }

            frm.resHeightReference = frm.Height;

            if (frm.bInitialScale == true)
            {
                frm.bInitialScale = false; // If this was the initial scaling (from scratch), it's now complete.
            }
            if (frm.bSkipMaxLen == true)
            {
                frm.bSkipMaxLen = false; // No need to consider the maximum length restriction now.
            }

        }
        #endregion


        //窗体触及后弹起
        private void Show_KeyUp(object sender, KeyEventArgs e)
        {
            this.ScanDataShow.Focus();
        }

 
        #region<窗体大小变化>
        private void Show_Resize(object sender, EventArgs e)
        {
            if (bInitialScale == true)
            {
                return; // Return if the initial scaling (from scratch)is not complete.
            }

            if (Screen.PrimaryScreen.Bounds.Width > Screen.PrimaryScreen.Bounds.Height) // If landscape orientation
            {
                if (bPortrait != false) // If an orientation change has occured to landscape
                {
                    bPortrait = false; // Set the orientation flag accordingly.
                    bInitialScale = true; // An initial scaling is required due to orientation change.
                    Scale(this); // Scale the GUI.
                }
                else
                {   // No orientation change has occured
                    bSkipMaxLen = true; // Initial scaling is now complete, so skipping the max. length restriction is now possible.
                    Scale(this); // Scale the GUI.
                }
            }
            else
            {
                // Similarly for the portrait orientation...
                if (bPortrait != true)
                {
                    bPortrait = true;
                    bInitialScale = true;
                    Scale(this);
                }
                else
                {
                    bSkipMaxLen = true;
                    Scale(this);
                }
            }

        }
        #endregion
        ScanData sData;  //扫描数据
        //Barcode扫描
        private void barcode21_OnScan(ScanDataCollection scanDataCollection)
        {
            try
            {
                //this.Show();
                this.WindowState = FormWindowState.Maximized;
                this.Activate();
                //移除上次的items
                while (ScanDataShow.Items.Count > 0)
                {
                    ScanDataShow.Items.RemoveAt(0);
                }
                ScanData scanData = scanDataCollection.GetFirst; //接受到的数据

                ScanDataShow.Items.Add(scanData.Text+";"+scanData.Type.ToString());

                sData = scanData;
                if (AutoSend.Checked)
                {
                    SendData(scanData);  //自动发送数据
                }
                
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        /// <summary>
        /// 发送数据给服务器
        /// </summary>
        /// <param name="scanData"></param>
        public void SendData(ScanData scanData)
        {
            try
            { 
                if (scanData.Result == Results.SUCCESS)
                {
                    string str = scanData.Text + ";" +localIP;
                    if (client.Send(str))
                        statue.Text = str +" "+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                }
                else
                {
                    statue.Text = "Send Error,Try Again!";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        //barcode状态
        private void barcode21_OnStatus(StatusData statusData)
        {
            ScanStatue.Text = statusData.Text + "   " + localIP; ;
        }



        private void Show_Closed(object sender, EventArgs e)
        {
            try
            {
                barcode21.EnableScanner = false;
                if (client != null)
                {
                    statue.Text = client.Close().ToString();
                }
               
                Thread.Sleep(500);
                // You must disable the scanner before exiting the application in 
                // order to release all the resources.         
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                string p = Directory.GetCurrentDirectory();
                p = p + "\\log";
                if (!Directory.Exists(p))
                    Directory.CreateDirectory(p);
                using(StreamWriter sw = new StreamWriter(p + "\\"+DateTime.Now.ToString("yyyy-MM-dd")+".log"))
                {
                    sw.WriteLine(ex.ToString());
                    sw.Close();
                }
            }
        }



        private void SetIP_Click(object sender, EventArgs e)
        {
            try
            {
                SetIP sip = new SetIP();
                sip.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            connect();
        }

        public Boolean connect()
        {
            try
            {
                client = new SocketClientPlus(new IPEndPoint(IPAddress.Parse(serverIP), serverPort));  //实例化Socket类
                statue.Text += string.Format("Connect {0} Success {1}\r\n", serverIP,DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                return true;
            }
            catch
            {
                statue.Text += string.Format("connect server {0},{1}, false {2}\r\n", serverIP, serverPort.ToString(), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                return false;
            }
        }

        private void CLW_Click(object sender, EventArgs e)
        {
            statue.Text = "";
        }


        private void Send_Click(object sender, EventArgs e)
        {
            SendData(sData);
        }

        private void AutoSend_CheckStateChanged(object sender, EventArgs e)
        {
            if (AutoSend.Checked)
                Send.Enabled = false;
            else
                Send.Enabled = true;
        }

    }
}