namespace Scan_Gun
{
    partial class SetIP
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.IP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Setting = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // IP
            // 
            this.IP.Location = new System.Drawing.Point(27, 77);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(99, 21);
            this.IP.TabIndex = 0;
            this.IP.Text = "textBox1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(65, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 19);
            this.label1.Text = "IP";
            // 
            // Setting
            // 
            this.Setting.Location = new System.Drawing.Point(89, 128);
            this.Setting.Name = "Setting";
            this.Setting.Size = new System.Drawing.Size(67, 19);
            this.Setting.TabIndex = 2;
            this.Setting.Text = "Set IP";
            this.Setting.Click += new System.EventHandler(this.Setting_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(154, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 19);
            this.label2.Text = "Port";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(140, 77);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(65, 21);
            this.Port.TabIndex = 0;
            this.Port.Text = "textBox1";
            // 
            // SetIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.Setting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.IP);
            this.Menu = this.mainMenu1;
            this.Name = "SetIP";
            this.Text = "SetIP";
            this.Load += new System.EventHandler(this.SetIP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Setting;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Port;
    }
}