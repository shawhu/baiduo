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
            if (chkBeep.Checked)
                Console.Beep(3000,100);
        }
        private void tcpServer1_OnConnect(tcpServer.TcpServerConnection connection)
        {
            //invokeDelegate setText = () => txtLog.Text = tcpServer1.Connections.Count.ToString();
            //Invoke(setText);
        }
        //close button
        private void button1_Click(object sender, EventArgs e)
        {
            tcpServer1.Close();
            timer1.Enabled = false;
            this.Close();
        }

        private int recordcount = 0;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        private void logData(bool sent, string text)
        {
            //try to save to the db
            string[] strtmp = text.Split(',');
            double humid2 = Convert.ToDouble(strtmp[0]);
            double temp2 = Convert.ToDouble(strtmp[1]);
            double humid3 = Convert.ToDouble(strtmp[2]);
            double temp3 = Convert.ToDouble(strtmp[3]);
            double humid4 = Convert.ToDouble(strtmp[4]);
            double temp4 = Convert.ToDouble(strtmp[5]);


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
            cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + humid2.ToString() + ",'humid2')";
            cm.ExecuteNonQuery();
            cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + temp2.ToString() + ",'temp2')";
            cm.ExecuteNonQuery();
            cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + humid3.ToString() + ",'humid3')";
            cm.ExecuteNonQuery();
            cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + temp3.ToString() + ",'temp3')";
            cm.ExecuteNonQuery();
            cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + humid3.ToString() + ",'humid4')";
            cm.ExecuteNonQuery();
            cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + temp3.ToString() + ",'temp4')";
            cm.ExecuteNonQuery();
            cn.Close();

            System.Media.SystemSounds.Exclamation.Play();

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
        
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            displayTcpServerStatus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmHistory frm1 = new frmHistory();
            frm1.ShowDialog();
        }
    }
}
