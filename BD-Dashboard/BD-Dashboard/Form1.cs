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
using ServiceStack;

namespace BD_Dashboard
{
    public partial class Form1 : Form
    {
        public delegate void invokeDelegate();
        public Form1()
        {
            InitializeComponent();
        }
        private int server_upload_interval = 6;
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
            //only upload to the cloud server when record count is dividable by 6, 5s turn to 30s
            server_upload_interval = Convert.ToInt32(ConfigurationManager.AppSettings["server_upload_interval"]);
            //try to load the interval time from the internet
            try
            {
                server_upload_interval = getinterval();
            }
            catch { }

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
        

        private int recordcount = 0;
        private void logData(bool sent, string text)
        {
            //increment recordcount
            recordcount++;
            
            //try to save to the db
            string[] strtmp = text.Split(',');
            double humid2 = -99;
            double temp2 = -99;
            double humid3 = -99;
            double temp3 = -99;
            double humid4 = -99;
            double temp4 = -99;
            double humid5 = -99;
            double temp5 = -99;
            double humid6 = -99;
            double temp6 = -99;
            double humid7 = -99;
            double temp7 = -99;
            
            double avgtemp = -99;
            double avghumid = -99;
            double co2 = -99;
            try
            {
                humid2 = Convert.ToDouble(strtmp[0]);
                temp2 = Convert.ToDouble(strtmp[1]);
            }
            catch
            { }
            try
            {
                humid3 = Convert.ToDouble(strtmp[2]);
                temp3 = Convert.ToDouble(strtmp[3]);
            }
            catch
            { }
            try
            {
                humid4 = Convert.ToDouble(strtmp[4]);
                temp4 = Convert.ToDouble(strtmp[5]);
            }
            catch
            { }
            try
            {
                humid5 = Convert.ToDouble(strtmp[6]);
                temp5 = Convert.ToDouble(strtmp[7]);
            }
            catch
            { }
            try
            {
                humid6 = Convert.ToDouble(strtmp[8]);
                temp6 = Convert.ToDouble(strtmp[9]);
            }
            catch
            { }
            try
            {
                humid7 = Convert.ToDouble(strtmp[10]);
                temp7 = Convert.ToDouble(strtmp[11]);
            }
            catch
            { }
            try
            {
                co2 = Convert.ToDouble(strtmp[12]);
            }
            catch
            { }
            //try to find avg
            if (humid2 != -99 && humid3 != -99 && humid4 != -99 && humid5 != -99 && humid6 != -99 && humid7 != -99)
                avghumid = (humid2 + humid3 + humid4 + humid5 + humid6 + humid7) / 6;
            if (temp2 != -99 && temp3 != -99 && temp4 != -99 && temp5 != -99 && temp6 != -99 && temp7 != -99)
                avgtemp = (temp2 + temp3 + temp4 + temp5 + temp6 + temp7) / 6;
            lblAvgHumid.Text = Math.Round(avghumid,1).ToString()+"";
            lblAvgTemp.Text = Math.Round(avgtemp, 1).ToString();

            //try to update lables
            lblTemp2.Text = temp2.ToString();
            lblHumid2.Text = humid2.ToString();
            lblTemp3.Text = temp3.ToString();
            lblHumid3.Text = humid3.ToString();
            lblTemp4.Text = temp4.ToString();
            lblHumid4.Text = humid4.ToString();

            lblTemp5.Text = temp5.ToString();
            lblHumid5.Text = humid5.ToString();
            lblTemp6.Text = temp6.ToString();
            lblHumid6.Text = humid6.ToString();
            lblTemp7.Text = temp7.ToString();
            lblHumid7.Text = humid7.ToString();



            lblCO2.Text = co2.ToString();


            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            cn.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandType = CommandType.Text;
            
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

            //
            if (humid5 != -99)
            {
                cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + humid5.ToString() + ",'humid5')";
                cm.ExecuteNonQuery();
            }
            if (temp5 != -99)
            {
                cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + temp5.ToString() + ",'temp5')";
                cm.ExecuteNonQuery();
            }
            if (humid6 != -99)
            {
                cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + humid6.ToString() + ",'humid6')";
                cm.ExecuteNonQuery();
            }
            if (temp6 != -99)
            {
                cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + temp6.ToString() + ",'temp6')";
                cm.ExecuteNonQuery();
            }
            if (humid7 != -99)
            {
                cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + humid7.ToString() + ",'humid7')";
                cm.ExecuteNonQuery();
            }
            if (temp7 != -99)
            {
                cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + temp7.ToString() + ",'temp7')";
                cm.ExecuteNonQuery();
            }

            if (co2 != -99)
            {
                cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + co2.ToString() + ",'co2')";
                cm.ExecuteNonQuery();
            }
            /*
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
            if (co2 != -99)
            {
                cm.CommandText = @"insert into dbo.sensordata (value,[type]) values (" + co2.ToString() + ",'co2')";
                cm.ExecuteNonQuery();
            }
            cn.Close();
            */
            //try to update the server
            
            if (recordcount % server_upload_interval == 0)
            {
                try
                {
                    save2server(avgtemp.ToString() + "," + avghumid.ToString() + "," + co2.ToString());
                }
                catch { }
            }
            

            //display the log data
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

        int warning_duration = 100;

        private void timer1_Tick(object sender, EventArgs e)
        {
            //check if txtbox are valid
            
            this.Text = @"百朵食用菌有限公司 - 管理控制台 v" + GetCurrentVersion;
            displayTcpServerStatus();
            //temp warning
            if (!txtTemp2Hi.Text.IsNullOrEmpty()&&Convert.ToDouble(lblTemp2.Text) > Convert.ToDouble(txtTemp2Hi.Text))
            {
                if (chkBeep.Checked)
                    Console.Beep(4000, warning_duration);
                lblTemp2.ForeColor = Color.Red;
                tcpServer1.Send("d2_off");
            }
            else if (!txtTemp2Lo.Text.IsNullOrEmpty() && Convert.ToDouble(lblTemp2.Text) < Convert.ToDouble(txtTemp2Lo.Text))
            {
                if (chkBeep.Checked)
                    Console.Beep(4000, warning_duration);
                lblTemp2.ForeColor = Color.Red;
                tcpServer1.Send("d2_on");
            }
            else
                lblTemp2.ForeColor = Color.Black;
            if (!txtTemp3Hi.Text.IsNullOrEmpty() && Convert.ToDouble(lblTemp3.Text) > Convert.ToDouble(txtTemp3Hi.Text))
            {
                if (chkBeep.Checked)
                    Console.Beep(4000, warning_duration);
                lblTemp3.ForeColor = Color.Red;
                tcpServer1.Send("d3_off");
            }
            else if (!txtTemp3Lo.Text.IsNullOrEmpty() && Convert.ToDouble(lblTemp3.Text) < Convert.ToDouble(txtTemp3Lo.Text))
            {
                if (chkBeep.Checked)
                    Console.Beep(4000, warning_duration);
                lblTemp3.ForeColor = Color.Red;
                tcpServer1.Send("d3_on");
            }
            else
                lblTemp3.ForeColor = Color.Black;
            if (!txtTemp4Hi.Text.IsNullOrEmpty() && Convert.ToDouble(lblTemp4.Text) > Convert.ToDouble(txtTemp4Hi.Text))
            {
                if (chkBeep.Checked)
                    Console.Beep(4000, warning_duration);
                lblTemp4.ForeColor = Color.Red;
                tcpServer1.Send("d4_off");
            }
            else if (!txtTemp4Lo.Text.IsNullOrEmpty() && Convert.ToDouble(lblTemp4.Text) < Convert.ToDouble(txtTemp4Lo.Text))
            {
                Console.Beep(4000, warning_duration);
                lblTemp4.ForeColor = Color.Red;
                tcpServer1.Send("d4_on");
            }
            else
                lblTemp4.ForeColor = Color.Black;
            //humidity warning
            if (!txtHumid2Hi.Text.IsNullOrEmpty()&&!txtHumid2Lo.Text.IsNullOrEmpty()&&(Convert.ToDouble(lblHumid2.Text) > Convert.ToDouble(txtHumid2Hi.Text) || Convert.ToDouble(lblHumid2.Text) < Convert.ToDouble(txtHumid2Lo.Text)))
            {
                Console.Beep(4000, warning_duration);
                lblHumid2.ForeColor = Color.Red;
            }
            else
                lblHumid2.ForeColor = Color.Black;
            if (!txtHumid3Hi.Text.IsNullOrEmpty() && !txtHumid3Lo.Text.IsNullOrEmpty() && (Convert.ToDouble(lblHumid3.Text) > Convert.ToDouble(txtHumid3Hi.Text) || Convert.ToDouble(lblHumid3.Text) < Convert.ToDouble(txtHumid3Lo.Text)))
            {
                Console.Beep(4000, warning_duration);
                lblHumid3.ForeColor = Color.Red;
            }
            else
                lblHumid3.ForeColor = Color.Black;
            if (!txtHumid4Hi.Text.IsNullOrEmpty()&&!txtHumid4Lo.Text.IsNullOrEmpty()&&(Convert.ToDouble(lblHumid4.Text) > Convert.ToDouble(txtHumid4Hi.Text) || Convert.ToDouble(lblHumid4.Text) < Convert.ToDouble(txtHumid4Lo.Text)))
            {
                Console.Beep(4000, warning_duration);
                lblHumid4.ForeColor = Color.Red;
            }
            else
                lblHumid4.ForeColor = Color.Black;
            Application.DoEvents();
        }
        //show history form
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

        private void save2server(string data)
        {
            /*
            var client = new JsonServiceClient(System.Configuration.ConfigurationManager.AppSettings["bd-server-url"]);
            BD_Server.reqDTO_SensorData request = new BD_Server.reqDTO_SensorData();
            request.data = data;
            BD_Server.ResponseDTO response = client.Post<BD_Server.ResponseDTO>(request);
             */
        }

        private int getinterval()
        {
            var client = new JsonServiceClient(System.Configuration.ConfigurationManager.AppSettings["bd-server-url"]);
            BD_Server.reqDTO_SensorInterval request = new BD_Server.reqDTO_SensorInterval();
            string response = client.Get<string>(request);
            return Convert.ToInt32(response);
        }
        //close button
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            tcpServer1.Close();
            this.Close();
        }
        //form close clicked
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            tcpServer1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tcpServer1.Send("d3_on");
        }

        
    }
}
