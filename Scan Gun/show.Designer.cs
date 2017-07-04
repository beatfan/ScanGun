namespace Scan_Gun
{
    partial class show
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.barcode21 = new Symbol.Barcode2.Design.Barcode2();
            this.SetIP = new System.Windows.Forms.Button();
            this.ScanDataShow = new System.Windows.Forms.ListBox();
            this.statue = new System.Windows.Forms.TextBox();
            this.ConnectServer = new System.Windows.Forms.Button();
            this.ScanStatue = new System.Windows.Forms.StatusBar();
            this.CLW = new System.Windows.Forms.Button();
            this.Send = new System.Windows.Forms.Button();
            this.AutoSend = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listBox2
            // 
            this.listBox2.Location = new System.Drawing.Point(0, 0);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(100, 100);
            this.listBox2.TabIndex = 0;
            // 
            // barcode21
            // 
            this.barcode21.Config.DecoderParameters.CODABAR = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.barcode21.Config.DecoderParameters.CODABARParams.ClsiEditing = false;
            this.barcode21.Config.DecoderParameters.CODABARParams.NotisEditing = false;
            this.barcode21.Config.DecoderParameters.CODABARParams.Redundancy = true;
            this.barcode21.Config.DecoderParameters.CODE128 = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.barcode21.Config.DecoderParameters.CODE128Params.EAN128 = true;
            this.barcode21.Config.DecoderParameters.CODE128Params.ISBT128 = true;
            this.barcode21.Config.DecoderParameters.CODE128Params.Other128 = true;
            this.barcode21.Config.DecoderParameters.CODE128Params.Redundancy = false;
            this.barcode21.Config.DecoderParameters.CODE39 = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.barcode21.Config.DecoderParameters.CODE39Params.Code32Prefix = false;
            this.barcode21.Config.DecoderParameters.CODE39Params.Concatenation = false;
            this.barcode21.Config.DecoderParameters.CODE39Params.ConvertToCode32 = false;
            this.barcode21.Config.DecoderParameters.CODE39Params.FullAscii = false;
            this.barcode21.Config.DecoderParameters.CODE39Params.Redundancy = false;
            this.barcode21.Config.DecoderParameters.CODE39Params.ReportCheckDigit = false;
            this.barcode21.Config.DecoderParameters.CODE39Params.VerifyCheckDigit = false;
            this.barcode21.Config.DecoderParameters.CODE93 = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.barcode21.Config.DecoderParameters.CODE93Params.Redundancy = false;
            this.barcode21.Config.DecoderParameters.D2OF5 = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.barcode21.Config.DecoderParameters.D2OF5Params.Redundancy = true;
            this.barcode21.Config.DecoderParameters.EAN13 = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.barcode21.Config.DecoderParameters.EAN8 = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.barcode21.Config.DecoderParameters.EAN8Params.ConvertToEAN13 = false;
            this.barcode21.Config.DecoderParameters.I2OF5 = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.barcode21.Config.DecoderParameters.I2OF5Params.ConvertToEAN13 = false;
            this.barcode21.Config.DecoderParameters.I2OF5Params.Redundancy = true;
            this.barcode21.Config.DecoderParameters.I2OF5Params.ReportCheckDigit = false;
            this.barcode21.Config.DecoderParameters.I2OF5Params.VerifyCheckDigit = Symbol.Barcode2.Design.I2OF5.CheckDigitSchemes.Default;
            this.barcode21.Config.DecoderParameters.KOREAN_3OF5 = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.barcode21.Config.DecoderParameters.KOREAN_3OF5Params.Redundancy = true;
            this.barcode21.Config.DecoderParameters.MSI = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.barcode21.Config.DecoderParameters.MSIParams.CheckDigitCount = Symbol.Barcode2.Design.CheckDigitCounts.Default;
            this.barcode21.Config.DecoderParameters.MSIParams.CheckDigitScheme = Symbol.Barcode2.Design.CheckDigitSchemes.Default;
            this.barcode21.Config.DecoderParameters.MSIParams.Redundancy = true;
            this.barcode21.Config.DecoderParameters.MSIParams.ReportCheckDigit = false;
            this.barcode21.Config.DecoderParameters.UPCA = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.barcode21.Config.DecoderParameters.UPCAParams.Preamble = Symbol.Barcode2.Design.Preambles.Default;
            this.barcode21.Config.DecoderParameters.UPCAParams.ReportCheckDigit = true;
            this.barcode21.Config.DecoderParameters.UPCE0 = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.barcode21.Config.DecoderParameters.UPCE0Params.ConvertToUPCA = false;
            this.barcode21.Config.DecoderParameters.UPCE0Params.Preamble = Symbol.Barcode2.Design.Preambles.Default;
            this.barcode21.Config.DecoderParameters.UPCE0Params.ReportCheckDigit = false;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.AimDuration = -1;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.AimMode = Symbol.Barcode2.Design.AIM_MODE.AIM_MODE_DEFAULT;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.AimType = Symbol.Barcode2.Design.AIM_TYPE.AIM_TYPE_DEFAULT;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.BeamTimer = -1;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.DPMMode = Symbol.Barcode2.Design.DPM_MODE.DPM_MODE_DEFAULT;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.FocusMode = Symbol.Barcode2.Design.FOCUS_MODE.FOCUS_MODE_DEFAULT;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.FocusPosition = Symbol.Barcode2.Design.FOCUS_POSITION.FOCUS_POSITION_DEFAULT;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.IlluminationMode = Symbol.Barcode2.Design.ILLUMINATION_MODE.ILLUMINATION_DEFAULT;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.ImageCaptureTimeout = -1;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.ImageCompressionTimeout = -1;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.Inverse1DMode = Symbol.Barcode2.Design.INVERSE1D_MODE.INVERSE_DEFAULT;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.LinearSecurityLevel = Symbol.Barcode2.Design.LINEAR_SECURITY_LEVEL.SECURITY_DEFAULT;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.PicklistMode = Symbol.Barcode2.Design.PICKLIST_MODE.PICKLIST_DEFAULT;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.PointerTimer = -1;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.PoorQuality1DMode = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFFeedback = Symbol.Barcode2.Design.VIEWFINDER_FEEDBACK.VIEWFINDER_FEEDBACK_DEFAULT;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFFeedbackTime = -1;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFMode = Symbol.Barcode2.Design.VIEWFINDER_MODE.VIEWFINDER_MODE_DEFAULT;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Bottom = 0;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Left = 0;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Right = 0;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Top = 0;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.AimDuration = -1;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.AimMode = Symbol.Barcode2.Design.AIM_MODE.AIM_MODE_DEFAULT;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.AimType = Symbol.Barcode2.Design.AIM_TYPE.AIM_TYPE_DEFAULT;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.BeamTimer = -1;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.BeamWidth = Symbol.Barcode2.Design.BEAM_WIDTH.DEFAULT;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.BidirRedundancy = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.ControlScanLed = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.DBPMode = Symbol.Barcode2.Design.DBP_MODE.DBP_DEFAULT;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.KlasseEinsEnable = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.LinearSecurityLevel = Symbol.Barcode2.Design.LINEAR_SECURITY_LEVEL.SECURITY_DEFAULT;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.PointerTimer = -1;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.RasterHeight = -1;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.RasterMode = Symbol.Barcode2.Design.RASTER_MODE.RASTER_MODE_DEFAULT;
            this.barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.ScanLedLogicLevel = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.barcode21.Config.ScanDataSize = ((uint)(55u));
            this.barcode21.Config.ScanParameters.BeepFrequency = 2670;
            this.barcode21.Config.ScanParameters.BeepTime = 200;
            this.barcode21.Config.ScanParameters.CodeIdType = Symbol.Barcode2.Design.CodeIdTypes.Default;
            this.barcode21.Config.ScanParameters.LedTime = 3000;
            this.barcode21.Config.ScanParameters.ScanType = Symbol.Barcode2.Design.SCANTYPES.Default;
            this.barcode21.Config.ScanParameters.WaveFile = "";
            this.barcode21.DeviceType = Symbol.Barcode2.DEVICETYPES.FIRSTAVAILABLE;
            this.barcode21.EnableScanner = true;
            this.barcode21.OnScan += new Symbol.Barcode2.Design.Barcode2.OnScanEventHandler(this.barcode21_OnScan);
            this.barcode21.OnStatus += new Symbol.Barcode2.Design.Barcode2.OnStatusEventHandler(this.barcode21_OnStatus);
            // 
            // SetIP
            // 
            this.SetIP.Location = new System.Drawing.Point(141, 18);
            this.SetIP.Name = "SetIP";
            this.SetIP.Size = new System.Drawing.Size(45, 18);
            this.SetIP.TabIndex = 7;
            this.SetIP.Text = "Set IP";
            this.SetIP.Click += new System.EventHandler(this.SetIP_Click);
            // 
            // ScanDataShow
            // 
            this.ScanDataShow.Location = new System.Drawing.Point(8, 44);
            this.ScanDataShow.Name = "ScanDataShow";
            this.ScanDataShow.Size = new System.Drawing.Size(309, 58);
            this.ScanDataShow.TabIndex = 9;
            // 
            // statue
            // 
            this.statue.Location = new System.Drawing.Point(8, 108);
            this.statue.Multiline = true;
            this.statue.Name = "statue";
            this.statue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statue.Size = new System.Drawing.Size(309, 96);
            this.statue.TabIndex = 10;
            // 
            // ConnectServer
            // 
            this.ConnectServer.Location = new System.Drawing.Point(219, 17);
            this.ConnectServer.Name = "ConnectServer";
            this.ConnectServer.Size = new System.Drawing.Size(58, 19);
            this.ConnectServer.TabIndex = 11;
            this.ConnectServer.Text = "Connect";
            this.ConnectServer.Click += new System.EventHandler(this.Connect_Click);
            // 
            // ScanStatue
            // 
            this.ScanStatue.Location = new System.Drawing.Point(0, 298);
            this.ScanStatue.Name = "ScanStatue";
            this.ScanStatue.Size = new System.Drawing.Size(320, 22);
            this.ScanStatue.Text = "LocalIP";
            // 
            // CLW
            // 
            this.CLW.Location = new System.Drawing.Point(213, 221);
            this.CLW.Name = "CLW";
            this.CLW.Size = new System.Drawing.Size(42, 19);
            this.CLW.TabIndex = 11;
            this.CLW.Text = "CLW";
            this.CLW.Click += new System.EventHandler(this.CLW_Click);
            // 
            // Send
            // 
            this.Send.Enabled = false;
            this.Send.Location = new System.Drawing.Point(63, 222);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(45, 18);
            this.Send.TabIndex = 7;
            this.Send.Text = "Send";
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // AutoSend
            // 
            this.AutoSend.Checked = true;
            this.AutoSend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoSend.Location = new System.Drawing.Point(8, 18);
            this.AutoSend.Name = "AutoSend";
            this.AutoSend.Size = new System.Drawing.Size(100, 20);
            this.AutoSend.TabIndex = 15;
            this.AutoSend.Text = "Auto Send";
            this.AutoSend.CheckStateChanged += new System.EventHandler(this.AutoSend_CheckStateChanged);
            // 
            // show
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(320, 320);
            this.Controls.Add(this.AutoSend);
            this.Controls.Add(this.ScanStatue);
            this.Controls.Add(this.CLW);
            this.Controls.Add(this.ConnectServer);
            this.Controls.Add(this.statue);
            this.Controls.Add(this.ScanDataShow);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.SetIP);
            this.Name = "show";
            this.Text = "Scan Gun";
            this.Load += new System.EventHandler(this.Show_Load);
            this.Closed += new System.EventHandler(this.Show_Closed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Show_KeyUp);
            this.Resize += new System.EventHandler(this.Show_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox2;
        private Symbol.Barcode2.Design.Barcode2 barcode21;
        private System.Windows.Forms.Button SetIP;
        private System.Windows.Forms.ListBox ScanDataShow;
        private System.Windows.Forms.TextBox statue;
        private System.Windows.Forms.Button ConnectServer;
        private System.Windows.Forms.StatusBar ScanStatue;
        private System.Windows.Forms.Button CLW;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.CheckBox AutoSend;

    }
}

