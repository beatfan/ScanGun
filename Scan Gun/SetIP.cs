using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Scan_Gun
{
    public partial class SetIP : Form
    {
        public SetIP()
        {
            InitializeComponent();
        }

        string path = "Server.txt";
        private void SetIP_Load(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    string str = sr.ReadLine();
                    IP.Text = str.Split(',')[0];
                    Port.Text = str.Split(',')[1];
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("FormLoad Error,"+ex.ToString());
            }
        }

        private void Setting_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(path);
                string str = IP.Text+","+Port.Text;
                using(StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(str);
                    sw.Close();
                }
                this.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Set Error,"+ex.ToString());
            }
        }
    }
}