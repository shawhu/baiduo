namespace BD_Dashboard
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTemp2 = new System.Windows.Forms.Label();
            this.lblHumid2 = new System.Windows.Forms.Label();
            this.txtTemp2Hi = new System.Windows.Forms.TextBox();
            this.txtTemp2Lo = new System.Windows.Forms.TextBox();
            this.txtHumid2Hi = new System.Windows.Forms.TextBox();
            this.txtHumid2Lo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtHumid3Lo = new System.Windows.Forms.TextBox();
            this.txtHumid3Hi = new System.Windows.Forms.TextBox();
            this.txtTemp3Lo = new System.Windows.Forms.TextBox();
            this.txtTemp3Hi = new System.Windows.Forms.TextBox();
            this.lblHumid3 = new System.Windows.Forms.Label();
            this.lblTemp3 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtHumid4Lo = new System.Windows.Forms.TextBox();
            this.txtHumid4Hi = new System.Windows.Forms.TextBox();
            this.txtTemp4Lo = new System.Windows.Forms.TextBox();
            this.txtTemp4Hi = new System.Windows.Forms.TextBox();
            this.lblHumid4 = new System.Windows.Forms.Label();
            this.lblTemp4 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.chkBeep = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tcpServer1 = new tcpServer.TcpServer(this.components);
            this.lblAvgTemp = new System.Windows.Forms.Label();
            this.lblAvgHumid = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimHei", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "传感器组";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 194);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "2号传感器";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 319);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "3号传感器";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 446);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "4号传感器";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 194);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "温度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(485, 194);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "相对湿度";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(371, 193);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 24);
            this.label11.TabIndex = 10;
            this.label11.Text = "°C";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(633, 193);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 24);
            this.label12.TabIndex = 11;
            this.label12.Text = "%";
            // 
            // lblTemp2
            // 
            this.lblTemp2.AutoSize = true;
            this.lblTemp2.Location = new System.Drawing.Point(316, 194);
            this.lblTemp2.Name = "lblTemp2";
            this.lblTemp2.Size = new System.Drawing.Size(54, 21);
            this.lblTemp2.TabIndex = 20;
            this.lblTemp2.Text = "21.0";
            // 
            // lblHumid2
            // 
            this.lblHumid2.AutoSize = true;
            this.lblHumid2.Location = new System.Drawing.Point(580, 194);
            this.lblHumid2.Name = "lblHumid2";
            this.lblHumid2.Size = new System.Drawing.Size(54, 21);
            this.lblHumid2.TabIndex = 21;
            this.lblHumid2.Text = "70.0";
            // 
            // txtTemp2Hi
            // 
            this.txtTemp2Hi.Location = new System.Drawing.Point(316, 160);
            this.txtTemp2Hi.Name = "txtTemp2Hi";
            this.txtTemp2Hi.Size = new System.Drawing.Size(51, 31);
            this.txtTemp2Hi.TabIndex = 34;
            this.txtTemp2Hi.Text = "24.0";
            this.txtTemp2Hi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTemp2Lo
            // 
            this.txtTemp2Lo.Location = new System.Drawing.Point(316, 218);
            this.txtTemp2Lo.Name = "txtTemp2Lo";
            this.txtTemp2Lo.Size = new System.Drawing.Size(51, 31);
            this.txtTemp2Lo.TabIndex = 35;
            this.txtTemp2Lo.Text = "21.0";
            this.txtTemp2Lo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHumid2Hi
            // 
            this.txtHumid2Hi.Location = new System.Drawing.Point(580, 160);
            this.txtHumid2Hi.Name = "txtHumid2Hi";
            this.txtHumid2Hi.Size = new System.Drawing.Size(51, 31);
            this.txtHumid2Hi.TabIndex = 36;
            this.txtHumid2Hi.Text = "98";
            this.txtHumid2Hi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHumid2Lo
            // 
            this.txtHumid2Lo.Location = new System.Drawing.Point(581, 220);
            this.txtHumid2Lo.Name = "txtHumid2Lo";
            this.txtHumid2Lo.Size = new System.Drawing.Size(51, 31);
            this.txtHumid2Lo.TabIndex = 37;
            this.txtHumid2Lo.Text = "50";
            this.txtHumid2Lo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(281, 163);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 21);
            this.label7.TabIndex = 38;
            this.label7.Text = "Hi";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(281, 221);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 21);
            this.label8.TabIndex = 39;
            this.label8.Text = "Lo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(546, 221);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 21);
            this.label9.TabIndex = 41;
            this.label9.Text = "Lo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(545, 163);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 21);
            this.label10.TabIndex = 40;
            this.label10.Text = "Hi";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(667, 549);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 36);
            this.button1.TabIndex = 42;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("SimHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStatus.Location = new System.Drawing.Point(12, 564);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(77, 13);
            this.lblStatus.TabIndex = 43;
            this.lblStatus.Text = "通讯口可用";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Font = new System.Drawing.Font("SimHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLog.Location = new System.Drawing.Point(1, 610);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(780, 50);
            this.txtLog.TabIndex = 44;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(546, 346);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 21);
            this.label13.TabIndex = 58;
            this.label13.Text = "Lo";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(545, 288);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 21);
            this.label14.TabIndex = 57;
            this.label14.Text = "Hi";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(281, 346);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 21);
            this.label15.TabIndex = 56;
            this.label15.Text = "Lo";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(281, 288);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 21);
            this.label16.TabIndex = 55;
            this.label16.Text = "Hi";
            // 
            // txtHumid3Lo
            // 
            this.txtHumid3Lo.Location = new System.Drawing.Point(581, 345);
            this.txtHumid3Lo.Name = "txtHumid3Lo";
            this.txtHumid3Lo.Size = new System.Drawing.Size(51, 31);
            this.txtHumid3Lo.TabIndex = 54;
            this.txtHumid3Lo.Text = "50";
            this.txtHumid3Lo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHumid3Hi
            // 
            this.txtHumid3Hi.Location = new System.Drawing.Point(580, 285);
            this.txtHumid3Hi.Name = "txtHumid3Hi";
            this.txtHumid3Hi.Size = new System.Drawing.Size(51, 31);
            this.txtHumid3Hi.TabIndex = 53;
            this.txtHumid3Hi.Text = "98";
            this.txtHumid3Hi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTemp3Lo
            // 
            this.txtTemp3Lo.Location = new System.Drawing.Point(316, 343);
            this.txtTemp3Lo.Name = "txtTemp3Lo";
            this.txtTemp3Lo.Size = new System.Drawing.Size(51, 31);
            this.txtTemp3Lo.TabIndex = 52;
            this.txtTemp3Lo.Text = "21.0";
            this.txtTemp3Lo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTemp3Hi
            // 
            this.txtTemp3Hi.Location = new System.Drawing.Point(316, 285);
            this.txtTemp3Hi.Name = "txtTemp3Hi";
            this.txtTemp3Hi.Size = new System.Drawing.Size(51, 31);
            this.txtTemp3Hi.TabIndex = 51;
            this.txtTemp3Hi.Text = "24.0";
            this.txtTemp3Hi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblHumid3
            // 
            this.lblHumid3.AutoSize = true;
            this.lblHumid3.Location = new System.Drawing.Point(580, 319);
            this.lblHumid3.Name = "lblHumid3";
            this.lblHumid3.Size = new System.Drawing.Size(54, 21);
            this.lblHumid3.TabIndex = 50;
            this.lblHumid3.Text = "70.0";
            // 
            // lblTemp3
            // 
            this.lblTemp3.AutoSize = true;
            this.lblTemp3.Location = new System.Drawing.Point(316, 319);
            this.lblTemp3.Name = "lblTemp3";
            this.lblTemp3.Size = new System.Drawing.Size(54, 21);
            this.lblTemp3.TabIndex = 49;
            this.lblTemp3.Text = "21.0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(633, 318);
            this.label19.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 24);
            this.label19.TabIndex = 48;
            this.label19.Text = "%";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(371, 318);
            this.label20.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(33, 24);
            this.label20.TabIndex = 47;
            this.label20.Text = "°C";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(485, 319);
            this.label21.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(98, 21);
            this.label21.TabIndex = 46;
            this.label21.Text = "相对湿度";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(257, 319);
            this.label22.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(54, 21);
            this.label22.TabIndex = 45;
            this.label22.Text = "温度";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(545, 473);
            this.label23.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(32, 21);
            this.label23.TabIndex = 72;
            this.label23.Text = "Lo";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(544, 415);
            this.label24.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(32, 21);
            this.label24.TabIndex = 71;
            this.label24.Text = "Hi";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(280, 473);
            this.label25.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(32, 21);
            this.label25.TabIndex = 70;
            this.label25.Text = "Lo";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(280, 415);
            this.label26.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(32, 21);
            this.label26.TabIndex = 69;
            this.label26.Text = "Hi";
            // 
            // txtHumid4Lo
            // 
            this.txtHumid4Lo.Location = new System.Drawing.Point(580, 472);
            this.txtHumid4Lo.Name = "txtHumid4Lo";
            this.txtHumid4Lo.Size = new System.Drawing.Size(51, 31);
            this.txtHumid4Lo.TabIndex = 68;
            this.txtHumid4Lo.Text = "50";
            this.txtHumid4Lo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHumid4Hi
            // 
            this.txtHumid4Hi.Location = new System.Drawing.Point(579, 412);
            this.txtHumid4Hi.Name = "txtHumid4Hi";
            this.txtHumid4Hi.Size = new System.Drawing.Size(51, 31);
            this.txtHumid4Hi.TabIndex = 67;
            this.txtHumid4Hi.Text = "98";
            this.txtHumid4Hi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTemp4Lo
            // 
            this.txtTemp4Lo.Location = new System.Drawing.Point(315, 470);
            this.txtTemp4Lo.Name = "txtTemp4Lo";
            this.txtTemp4Lo.Size = new System.Drawing.Size(51, 31);
            this.txtTemp4Lo.TabIndex = 66;
            this.txtTemp4Lo.Text = "21.0";
            this.txtTemp4Lo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTemp4Hi
            // 
            this.txtTemp4Hi.Location = new System.Drawing.Point(315, 412);
            this.txtTemp4Hi.Name = "txtTemp4Hi";
            this.txtTemp4Hi.Size = new System.Drawing.Size(51, 31);
            this.txtTemp4Hi.TabIndex = 65;
            this.txtTemp4Hi.Text = "24.0";
            this.txtTemp4Hi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblHumid4
            // 
            this.lblHumid4.AutoSize = true;
            this.lblHumid4.Location = new System.Drawing.Point(579, 446);
            this.lblHumid4.Name = "lblHumid4";
            this.lblHumid4.Size = new System.Drawing.Size(54, 21);
            this.lblHumid4.TabIndex = 64;
            this.lblHumid4.Text = "70.0";
            // 
            // lblTemp4
            // 
            this.lblTemp4.AutoSize = true;
            this.lblTemp4.Location = new System.Drawing.Point(315, 446);
            this.lblTemp4.Name = "lblTemp4";
            this.lblTemp4.Size = new System.Drawing.Size(54, 21);
            this.lblTemp4.TabIndex = 63;
            this.lblTemp4.Text = "21.0";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(632, 445);
            this.label29.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(29, 24);
            this.label29.TabIndex = 62;
            this.label29.Text = "%";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(370, 445);
            this.label30.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(33, 24);
            this.label30.TabIndex = 61;
            this.label30.Text = "°C";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(484, 446);
            this.label31.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(98, 21);
            this.label31.TabIndex = 60;
            this.label31.Text = "相对湿度";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(256, 446);
            this.label32.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(54, 21);
            this.label32.TabIndex = 59;
            this.label32.Text = "温度";
            // 
            // chkBeep
            // 
            this.chkBeep.AutoSize = true;
            this.chkBeep.Checked = true;
            this.chkBeep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBeep.Font = new System.Drawing.Font("SimHei", 9.75F);
            this.chkBeep.Location = new System.Drawing.Point(95, 563);
            this.chkBeep.Name = "chkBeep";
            this.chkBeep.Size = new System.Drawing.Size(82, 17);
            this.chkBeep.TabIndex = 73;
            this.chkBeep.Text = "有提示音";
            this.chkBeep.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(544, 549);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 36);
            this.button2.TabIndex = 74;
            this.button2.Text = "历史数据";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tcpServer1
            // 
            this.tcpServer1.Encoding = ((System.Text.Encoding)(resources.GetObject("tcpServer1.Encoding")));
            this.tcpServer1.IdleTime = 50;
            this.tcpServer1.IsOpen = false;
            this.tcpServer1.MaxCallbackThreads = 100;
            this.tcpServer1.MaxSendAttempts = 3;
            this.tcpServer1.Port = -1;
            this.tcpServer1.VerifyConnectionInterval = 0;
            this.tcpServer1.OnConnect += new tcpServer.tcpServerConnectionChanged(this.tcpServer1_OnConnect);
            this.tcpServer1.OnDataAvailable += new tcpServer.tcpServerConnectionChanged(this.tcpServer1_OnDataAvailable);
            // 
            // lblAvgTemp
            // 
            this.lblAvgTemp.AutoSize = true;
            this.lblAvgTemp.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgTemp.Location = new System.Drawing.Point(317, 90);
            this.lblAvgTemp.Name = "lblAvgTemp";
            this.lblAvgTemp.Size = new System.Drawing.Size(52, 24);
            this.lblAvgTemp.TabIndex = 75;
            this.lblAvgTemp.Text = "21.0";
            // 
            // lblAvgHumid
            // 
            this.lblAvgHumid.AutoSize = true;
            this.lblAvgHumid.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgHumid.Location = new System.Drawing.Point(577, 90);
            this.lblAvgHumid.Name = "lblAvgHumid";
            this.lblAvgHumid.Size = new System.Drawing.Size(52, 24);
            this.lblAvgHumid.TabIndex = 76;
            this.lblAvgHumid.Text = "60.0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(103, 91);
            this.label17.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(109, 21);
            this.label17.TabIndex = 77;
            this.label17.Text = "2号传感器";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(369, 90);
            this.label18.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 24);
            this.label18.TabIndex = 78;
            this.label18.Text = "°C";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(630, 90);
            this.label27.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(29, 24);
            this.label27.TabIndex = 79;
            this.label27.Text = "%";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 661);
            this.ControlBox = false;
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblAvgHumid);
            this.Controls.Add(this.lblAvgTemp);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chkBeep);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.txtHumid4Lo);
            this.Controls.Add(this.txtHumid4Hi);
            this.Controls.Add(this.txtTemp4Lo);
            this.Controls.Add(this.txtTemp4Hi);
            this.Controls.Add(this.lblHumid4);
            this.Controls.Add(this.lblTemp4);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtHumid3Lo);
            this.Controls.Add(this.txtHumid3Hi);
            this.Controls.Add(this.txtTemp3Lo);
            this.Controls.Add(this.txtTemp3Hi);
            this.Controls.Add(this.lblHumid3);
            this.Controls.Add(this.lblTemp3);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtHumid2Lo);
            this.Controls.Add(this.txtHumid2Hi);
            this.Controls.Add(this.txtTemp2Lo);
            this.Controls.Add(this.txtTemp2Hi);
            this.Controls.Add(this.lblHumid2);
            this.Controls.Add(this.lblTemp2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("SimHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "百朵食用菌有限公司 - 管理控制台";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTemp2;
        private System.Windows.Forms.Label lblHumid2;
        private System.Windows.Forms.TextBox txtTemp2Hi;
        private System.Windows.Forms.TextBox txtTemp2Lo;
        private System.Windows.Forms.TextBox txtHumid2Hi;
        private System.Windows.Forms.TextBox txtHumid2Lo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private tcpServer.TcpServer tcpServer1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtHumid3Lo;
        private System.Windows.Forms.TextBox txtHumid3Hi;
        private System.Windows.Forms.TextBox txtTemp3Lo;
        private System.Windows.Forms.TextBox txtTemp3Hi;
        private System.Windows.Forms.Label lblHumid3;
        private System.Windows.Forms.Label lblTemp3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtHumid4Lo;
        private System.Windows.Forms.TextBox txtHumid4Hi;
        private System.Windows.Forms.TextBox txtTemp4Lo;
        private System.Windows.Forms.TextBox txtTemp4Hi;
        private System.Windows.Forms.Label lblHumid4;
        private System.Windows.Forms.Label lblTemp4;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.CheckBox chkBeep;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblAvgTemp;
        private System.Windows.Forms.Label lblAvgHumid;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label27;
    }
}

