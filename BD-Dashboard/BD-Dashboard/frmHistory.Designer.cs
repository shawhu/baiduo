namespace BD_Dashboard
{
    partial class frmHistory
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chkShowDiagram = new System.Windows.Forms.CheckBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 80);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1142, 746);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimHei", 15.75F);
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "历史记录";
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAutoRefresh.AutoSize = true;
            this.chkAutoRefresh.Location = new System.Drawing.Point(1056, 23);
            this.chkAutoRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(99, 24);
            this.chkAutoRefresh.TabIndex = 2;
            this.chkAutoRefresh.Text = "自动更新";
            this.chkAutoRefresh.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(905, 17);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "  清除历史数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkShowDiagram
            // 
            this.chkShowDiagram.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShowDiagram.AutoSize = true;
            this.chkShowDiagram.Checked = true;
            this.chkShowDiagram.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowDiagram.Location = new System.Drawing.Point(799, 17);
            this.chkShowDiagram.Name = "chkShowDiagram";
            this.chkShowDiagram.Size = new System.Drawing.Size(83, 30);
            this.chkShowDiagram.TabIndex = 4;
            this.chkShowDiagram.Text = "显示表格";
            this.chkShowDiagram.UseVisualStyleBackColor = true;
            this.chkShowDiagram.CheckedChanged += new System.EventHandler(this.chkShowDiagram_CheckedChanged);
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(215, 22);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(145, 26);
            this.dtpStart.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(470, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 48);
            this.button2.TabIndex = 7;
            this.button2.Text = "检索";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "日期";
            // 
            // frmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 844);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.chkShowDiagram);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkAutoRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "上海白朵食用菌有限公司-历史记录";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHistory_FormClosing);
            this.Load += new System.EventHandler(this.frmHistory_Load);
            this.ResizeBegin += new System.EventHandler(this.frmHistory_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.frmHistory_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmHistory_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chkAutoRefresh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkShowDiagram;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
    }
}