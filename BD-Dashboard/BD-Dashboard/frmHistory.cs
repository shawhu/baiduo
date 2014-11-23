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

        private void frmHistory_Load(object sender, EventArgs e)
        {
            //this.sensordataTableAdapter.Fill(this.dSsensor.sensordata);

            cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            cn.Open();
            cm.CommandText = "select * from sensordata order by Id desc";
            cm.Connection = cn;
            da = new SqlDataAdapter(cm);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            timer1.Start();
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (chkAutoRefresh.Checked)
            {
                dt.Clear();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
                
        }

        private void frmHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

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
    }
}
