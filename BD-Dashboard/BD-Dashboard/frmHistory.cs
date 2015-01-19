using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace BD_Dashboard
{
    public partial class frmHistory : Form
    {

        private SqlConnection cn = new SqlConnection();
        private SqlCommand cm = new SqlCommand();
        private DataTable dt = new DataTable();
        private SqlDataAdapter da;
        public frmHistory()
        {
            InitializeComponent();
        }

        //private DateTime earliest_date = DateTime.Parse("2014-11-1");
        private DateTime earliest_date = DateTime.Parse(DateTime.Now.ToShortDateString());
        private void frmHistory_Load(object sender, EventArgs e)
        {
            //init datetime picker
            dtpStart.Value = earliest_date;
            cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            cn.Open();
            cm.CommandText = "select * from sensordata where datediff(day,'" + dtpStart.Value.ToString() + "',record_datetime)=0 order by record_datetime";
            cm.Connection = cn;
            da = new SqlDataAdapter(cm);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            timer1.Start();
            this.MouseWheel += new MouseEventHandler(frmHistory_MouseWheel);
        }

        

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (chkAutoRefresh.Checked)
            {
                ProcessData();
            }
        }
        
        private void ProcessData()
        {
            if (LocktheDatatable)
                return;
            dt.Clear();
            cm.CommandText = "select * from sensordata where datediff(day,'" + dtpStart.Value.ToString() + "',record_datetime)=0 order by record_datetime";
            da.Fill(dt);
            if (chkShowDiagram.Checked)
            {
                chkShowDiagram.Text = "显示表格";
                dataGridView1.Hide();
            }
            else
            {
                chkShowDiagram.Text = "显示折线图";
                dataGridView1.Show();
                dataGridView1.DataSource = dt;
            }
            this.Refresh();
        }

        private void frmHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        //delete all local records
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmdelete = new SqlCommand();
            cmdelete.Connection = cn;
            cmdelete.CommandText = "delete from sensordata";
            cmdelete.ExecuteNonQuery();
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private int MouseDelta = 8;
        void frmHistory_MouseWheel(object sender, MouseEventArgs e)
        {
            MouseDelta = MouseDelta - e.Delta / 120;
            this.Refresh();
            Console.WriteLine(MouseDelta.ToString());
        }

        private void chkShowDiagram_CheckedChanged(object sender, EventArgs e)
        {
            ProcessData();
        }

        public const int axis_x_0 = 20;
        public const int axis_x_max = 20;
        public const int axis_y_0 = 60;
        public const int axis_y_max = 60;
        public const int xfactor = 4;
        public const int yscale = 20;
        public const int yoffset = 200;

        private bool LocktheDatatable = false;
        DateTime FirstDateT = new DateTime();
        private void frmHistory_Paint(object sender, PaintEventArgs e)
        {
            if (isResizing)
                return;
            Graphics g = e.Graphics;
            //draw axis
            //draw x
            int Y_0 = this.Height - axis_y_0;
            g.DrawLine(new Pen(Color.Black), new Point(axis_x_0, Y_0), new Point(this.Width-axis_x_max, Y_0));
            //draw y
            g.DrawLine(new Pen(Color.Black), new Point(axis_x_0, Y_0), new Point(axis_x_0, axis_y_max));
            //draw 10C x
            g.DrawLine(new Pen(Color.Black), new Point(axis_x_0, Y_0 - 10 * yscale+yoffset), new Point(this.Width - axis_x_max, Y_0 - 10 * yscale+yoffset));
            g.DrawString("10C", new Font(FontFamily.GenericSansSerif, 8), new SolidBrush(Color.Black), new Point(0, Y_0 - 10 * yscale + yoffset));
            //draw 20C x
            g.DrawLine(new Pen(Color.Black), new Point(axis_x_0, Y_0 - 20 * yscale + yoffset), new Point(this.Width - axis_x_max, Y_0 - 20 * yscale + yoffset));
            g.DrawString("20C", new Font(FontFamily.GenericSansSerif, 8), new SolidBrush(Color.Black), new Point(0, Y_0 - 20 * yscale + yoffset));
            //draw 30C x
            g.DrawLine(new Pen(Color.Black), new Point(axis_x_0, Y_0 - 30 * yscale + yoffset), new Point(this.Width - axis_x_max, Y_0 - 30 * yscale + yoffset));
            g.DrawString("30C", new Font(FontFamily.GenericSansSerif, 8), new SolidBrush(Color.Black), new Point(0, Y_0 - 30 * yscale + yoffset));
            
            
            if (dt.Rows.Count == 0)
                return;
            LocktheDatatable = true;
            //try to draw temp2
            DataRow[] drstemp2 = dt.Select("type='temp2'");
            FirstDateT = DateTime.Parse(drstemp2[0]["record_datetime"].ToString());
            //------------draw date labels--------------------
            for(int i=1;i<=23;i++)
            {
                TimeSpan dts1 = DateTime.Parse(dtpStart.Value.Year.ToString()+"-"+dtpStart.Value.Month.ToString()+"-"+dtpStart.Value.Day.ToString()+" "+i.ToString()+":00") - FirstDateT;
                int dx = Convert.ToInt32(dts1.TotalSeconds * xfactor);
                g.DrawLine(new Pen(Color.Black), new Point(Convert.ToInt32((dx) / Math.Pow(2, MouseDelta)) + axis_x_0, Y_0), new Point(Convert.ToInt32((dx) / Math.Pow(2, MouseDelta)) + axis_x_0, axis_y_max));
                g.DrawString(i.ToString()+":00", new Font(FontFamily.GenericSansSerif, 8), new SolidBrush(Color.Black), new Point(Convert.ToInt32((dx) / Math.Pow(2, MouseDelta)), Y_0));
            }

            //draw actual data
            Point lastpoint = new Point(-1, -1);
            Pen mypen = new Pen(Color.Red);
            foreach (DataRow dr in drstemp2)
            {
                double value = (double)dr["value"];
                int drawvalue = Convert.ToInt32(Math.Round(value * yscale - yoffset, 0));
                string type = dr["type"].ToString();
                DateTime record_datet = (DateTime)dr["record_datetime"];
                //only assign the 1st time
                TimeSpan ts1 = record_datet-FirstDateT;
                int deltax = Convert.ToInt32(ts1.TotalSeconds*xfactor);
                if (lastpoint.X == -1 && lastpoint.Y == -1)
                {
                    lastpoint = new Point(Convert.ToInt32((deltax) / Math.Pow(2, MouseDelta)) + axis_x_0, Y_0 - drawvalue);
                    g.DrawArc(mypen, new Rectangle(lastpoint.X-2, lastpoint.Y-2, 4, 4), 0, 360);
                    continue;
                }
                
                g.DrawLine(mypen, lastpoint,new Point(Convert.ToInt32((deltax)/Math.Pow(2,MouseDelta))+axis_x_0 , Y_0 - drawvalue));
                g.DrawArc(mypen, new Rectangle(Convert.ToInt32((deltax) / Math.Pow(2, MouseDelta)) + axis_x_0 - 2, Y_0 - 2 - drawvalue, 4, 4), 0, 360);
                //Console.WriteLine("x:" + (deltax).ToString() + ",Y:" + (drawvalue).ToString());
                //Console.Write("x1:" + (axis_x_0 + deltax).ToString() + ",y1:" + (Y_0 - drawvalue).ToString() + ",x2:" + (axis_x_0 + deltax + 1).ToString() + ",y2:" + (Y_0 - drawvalue).ToString());
                //Console.WriteLine(FirstDateT.ToShortTimeString() + " " + record_datet.ToShortTimeString());
                lastpoint = new Point(Convert.ToInt32((deltax) / Math.Pow(2, MouseDelta)) + axis_x_0, Y_0 - drawvalue);
            }
            //try to draw temp3
            DataRow[] drstemp3 = dt.Select("type='temp3'");
            FirstDateT = DateTime.Parse(drstemp3[0]["record_datetime"].ToString());
            lastpoint = new Point(-1, -1);
            mypen = new Pen(Color.Purple);
            foreach (DataRow dr in drstemp3)
            {
                double value = (double)dr["value"];
                int drawvalue = Convert.ToInt32(Math.Round(value * yscale - yoffset, 0));
                string type = dr["type"].ToString();
                DateTime record_datet = (DateTime)dr["record_datetime"];
                //only assign the 1st time
                TimeSpan ts1 = record_datet - FirstDateT;
                int deltax = Convert.ToInt32(ts1.TotalSeconds * xfactor);
                if (lastpoint.X == -1 && lastpoint.Y == -1)
                {
                    lastpoint = new Point(Convert.ToInt32((deltax) / Math.Pow(2, MouseDelta)) + axis_x_0, Y_0 - drawvalue);
                    g.DrawArc(mypen, new Rectangle(lastpoint.X - 2, lastpoint.Y - 2, 4, 4), 0, 360);
                    continue;
                }

                g.DrawLine(mypen, lastpoint, new Point(Convert.ToInt32((deltax) / Math.Pow(2, MouseDelta)) + axis_x_0, Y_0 - drawvalue));
                g.DrawArc(mypen, new Rectangle(Convert.ToInt32((deltax) / Math.Pow(2, MouseDelta)) + axis_x_0 - 2, Y_0 - 2 - drawvalue, 4, 4), 0, 360);
                //Console.WriteLine("x:" + (deltax).ToString() + ",Y:" + (drawvalue).ToString());
                //Console.Write("x1:" + (axis_x_0 + deltax).ToString() + ",y1:" + (Y_0 - drawvalue).ToString() + ",x2:" + (axis_x_0 + deltax + 1).ToString() + ",y2:" + (Y_0 - drawvalue).ToString());
                //Console.WriteLine(FirstDateT.ToShortTimeString() + " " + record_datet.ToShortTimeString());
                lastpoint = new Point(Convert.ToInt32((deltax) / Math.Pow(2, MouseDelta)) + axis_x_0, Y_0 - drawvalue);
            }
            //try to draw temp4
            DataRow[] drstemp4 = dt.Select("type='temp4'");
            FirstDateT = DateTime.Parse(drstemp4[0]["record_datetime"].ToString());
            lastpoint = new Point(-1, -1);
            mypen = new Pen(Color.Green);
            foreach (DataRow dr in drstemp4)
            {
                double value = (double)dr["value"];
                int drawvalue = Convert.ToInt32(Math.Round(value * yscale-yoffset, 0));
                string type = dr["type"].ToString();
                DateTime record_datet = (DateTime)dr["record_datetime"];
                //only assign the 1st time
                TimeSpan ts1 = record_datet - FirstDateT;
                int deltax = Convert.ToInt32(ts1.TotalSeconds * xfactor);
                if (lastpoint.X == -1 && lastpoint.Y == -1)
                {
                    lastpoint = new Point(Convert.ToInt32((deltax) / Math.Pow(2, MouseDelta)) + axis_x_0, Y_0 - drawvalue);
                    g.DrawArc(mypen, new Rectangle(lastpoint.X - 2, lastpoint.Y - 2, 4, 4), 0, 360);
                    continue;
                }

                g.DrawLine(mypen, lastpoint, new Point(Convert.ToInt32((deltax) / Math.Pow(2, MouseDelta)) + axis_x_0, Y_0 - drawvalue));
                g.DrawArc(mypen, new Rectangle(Convert.ToInt32((deltax) / Math.Pow(2, MouseDelta)) + axis_x_0 - 2, Y_0 - 2 - drawvalue, 4, 4), 0, 360);
                //Console.WriteLine("x:" + (deltax).ToString() + ",Y:" + (drawvalue).ToString());
                //Console.Write("x1:" + (axis_x_0 + deltax).ToString() + ",y1:" + (Y_0 - drawvalue).ToString() + ",x2:" + (axis_x_0 + deltax + 1).ToString() + ",y2:" + (Y_0 - drawvalue).ToString());
                //Console.WriteLine(FirstDateT.ToShortTimeString() + " " + record_datet.ToShortTimeString());
                lastpoint = new Point(Convert.ToInt32((deltax) / Math.Pow(2, MouseDelta)) + axis_x_0, Y_0 - drawvalue);
            }

            Console.WriteLine("end of cycle");
            LocktheDatatable = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProcessData();
        }

        bool isResizing = false;
        private void frmHistory_ResizeBegin(object sender, EventArgs e)
        {
            isResizing = true;
            Console.WriteLine("resize begins");
        }

        private void frmHistory_ResizeEnd(object sender, EventArgs e)
        {
            isResizing = false;
            ProcessData();
            Console.WriteLine("resize ends");
        }
    }
}
