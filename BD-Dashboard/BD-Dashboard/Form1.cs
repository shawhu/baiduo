using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Data.SqlClient;
using System.Configuration;
using System.Deployment.Application;
using System.Reflection;

namespace BD_Dashboard
{
    public partial class Form1 : Form
    {
        public delegate void invokeDelegate();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //try to start tcp server
            tcpServer1.Close();
            tcpServer1.Port = 6789;
            try
            {
                tcpServer1.Open();
                timer1.Enabled = true;
            }
            catch
            {
                lblStatus.Text = "通讯口6789被占用";
                lblStatus.BackColor = Color.Red;
            }
        }

        //tcp server data in handler
        private void tcpServer1_OnDataAvailable(tcpServer.TcpServerConnection connection)
        {
            byte[] data = readStream(connection.Socket);

            if (data != null)
            {
                string dataStr = Encoding.ASCII.GetString(data);

                invokeDelegate del = () =>
                {
                    logData(false, dataStr);
                };
                Invoke(del);

                data = null;
            }
        }
        //received data from sensors
        private void tcpServer1_OnConnect(tcpServer.TcpServerConnection connection)
        {
            //invokeDelegate setText = () => txtLog.Text = tcpServer1.Connections.Count.ToString();
            //Invoke(setText);
        }
        //close button
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            tcpServer1.Close();
            this.Close();
        }

        private int recordcount = 0;
        private void logData(bool sent, string text)
        {
            //try to save to the db
            string[] strtmp = text.Split(',');
            double humid2 = -99;
            double temp2 = -99;
            double humid3 = -99;
            double temp3 = -99;
            double humid4 = -99;
            double temp4 = -99;
            double avgtemp = -99;
            double avghumid = -99;
            try
            {
                humid2 = Convert.ToDouble(strtmp[0]);
                temp2 = Convert.ToDouble(strtmp[1]);
                humid3 = Convert.ToDouble(strtmp[2]);
                temp3 = Convert.ToDouble(strtmp[3]);
                humid4 = Convert.ToDouble(strtmp[4]);
                temp4 = Convert.ToDouble(strtmp[5]);
            }
            catch
            { }
            //try to find avg
            if (humid2 != -99 && humid3 != -99 && humid4 != -99)
                avghumid = (humid2 + humid3 + humid4) / 3;
            if (temp2 != -99 && temp3 != -99 && temp4 != -99)
                avgtemp = (temp2 + temp3 + temp4) / 3;
            lblAvgHumid.Text = Math.Round(avghumid,1).ToString()+"";
            lblAvgTemp.Text = Math.Round(avgtemp, 1).ToString();

            //try to update lables
            lblTemp2.Text = temp2.ToString();
            lblHumid2.Text = humid2.ToString();
            lblTemp3.Text = temp3.ToString();
            lblHumid3.Text = humid3.ToString();
            lblTemp4.Text = temp4.ToString();
            lblHumid4.Text = humid4.ToString();


            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            cn.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandType = CommandType.Text;
            /*
            if (humid2 != -99)
            {
                cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + humid2.ToString() + ",'humid2')";
                cm.ExecuteNonQuery();
            }
            if (temp2 != -99)
            {
                cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + temp2.ToString() + ",'temp2')";
                cm.ExecuteNonQuery();
            }
            if (humid3 != -99)
            {
                cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + humid3.ToString() + ",'humid3')";
                cm.ExecuteNonQuery();
            }
            if (temp3 != -99)
            {
                cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + temp3.ToString() + ",'temp3')";
                cm.ExecuteNonQuery();
            }
            if (humid4 != -99)
            {
                cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + humid4.ToString() + ",'humid4')";
                cm.ExecuteNonQuery();
            }
            if (temp4 != -99)
            {
                cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + temp4.ToString() + ",'temp4')";
                cm.ExecuteNonQuery();
            }
            */
            //avg
            if (avghumid != -99)
            {
                cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + avghumid.ToString() + ",'avghumid')";
                cm.ExecuteNonQuery();
            }
            if (avgtemp != -99)
            {
                cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + avgtemp.ToString() + ",'avgtemp')";
                cm.ExecuteNonQuery();
            }
            cn.Close();

            //display the log data
            recordcount++;
            txtLog.Text += "["+recordcount.ToString()+"] " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss tt") + (sent ? " SENT: " : " RECEIVED: ");
            txtLog.Text += text+"\r\n";
            if (txtLog.Lines.Length > 500)
            {
                string[] temp = new string[500];
                Array.Copy(txtLog.Lines, txtLog.Lines.Length - 500, temp, 0, 500);
                txtLog.Lines = temp;
            }
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

        private void displayTcpServerStatus()
        {
            if (tcpServer1.IsOpen)
            {
                lblStatus.Text = "通讯已连接";
                lblStatus.BackColor = Color.Lime;
            }
            else
            {
                lblStatus.Text = "通讯口禁用";
                lblStatus.BackColor = Color.Red;
            }
        }

        protected byte[] readStream(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            if (stream.DataAvailable)
            {
                byte[] data = new byte[client.Available];

                int bytesRead = 0;
                try
                {
                    bytesRead = stream.Read(data, 0, data.Length);
                }
                catch (IOException)
                {
                }

                if (bytesRead < data.Length)
                {
                    byte[] lastData = data;
                    data = new byte[bytesRead];
                    Array.ConstrainedCopy(lastData, 0, data, 0, bytesRead);
                }
                return data;
            }
            return null;
        }

        int warning_duration = 1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = @"百朵食用菌有限公司 - 管理控制台 v" + GetCurrentVersion;
            displayTcpServerStatus();
            if (chkBeep.Checked)
                warning_duration = 100;
            else
                warning_duration = 1;
            //temp warning
            if (Convert.ToDouble(lblTemp2.Text) > Convert.ToDouble(txtTemp2Hi.Text) || Convert.ToDouble(lblTemp2.Text) < Convert.ToDouble(txtTemp2Lo.Text))
            {
                Console.Beep(4000, warning_duration);
                lblTemp2.ForeColor = Color.Red;
            }
            else
                lblTemp2.ForeColor = Color.Black;
            if (Convert.ToDouble(lblTemp3.Text) > Convert.ToDouble(txtTemp3Hi.Text) || Convert.ToDouble(lblTemp3.Text) < Convert.ToDouble(txtTemp3Lo.Text))
            {
                Console.Beep(4000, warning_duration);
                lblTemp3.ForeColor = Color.Red;
            }
            else
                lblTemp3.ForeColor = Color.Black;
            if (Convert.ToDouble(lblTemp4.Text) > Convert.ToDouble(txtTemp4Hi.Text) || Convert.ToDouble(lblTemp4.Text) < Convert.ToDouble(txtTemp4Lo.Text))
            {
                Console.Beep(4000, warning_duration);
                lblTemp4.ForeColor = Color.Red;
            }
            else
                lblTemp4.ForeColor = Color.Black;
            //humidity warning
            if (Convert.ToDouble(lblHumid2.Text) > Convert.ToDouble(txtHumid2Hi.Text) || Convert.ToDouble(lblHumid2.Text) < Convert.ToDouble(txtHumid2Lo.Text))
            {
                Console.Beep(4000, warning_duration);
                lblHumid2.ForeColor = Color.Red;
            }
            else
                lblHumid2.ForeColor = Color.Black;
            if (Convert.ToDouble(lblHumid3.Text) > Convert.ToDouble(txtHumid3Hi.Text) || Convert.ToDouble(lblHumid3.Text) < Convert.ToDouble(txtHumid3Lo.Text))
            {
                Console.Beep(4000, warning_duration);
                lblHumid3.ForeColor = Color.Red;
            }
            else
                lblHumid3.ForeColor = Color.Black;
            if (Convert.ToDouble(lblHumid4.Text) > Convert.ToDouble(txtHumid4Hi.Text) || Convert.ToDouble(lblHumid4.Text) < Convert.ToDouble(txtHumid4Lo.Text))
            {
                Console.Beep(4000, warning_duration);
                lblHumid4.ForeColor = Color.Red;
            }
            else
                lblHumid4.ForeColor = Color.Black;
            Application.DoEvents();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmHistory frm1 = new frmHistory();
            frm1.ShowDialog();
        }

        public string GetCurrentVersion
        {
            get
            {
                return ApplicationDeployment.IsNetworkDeployed
                       ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
                       : Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
    }
}
