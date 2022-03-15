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
using System.Configuration;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        SqlConnectionStringBuilder scsb;
        string myDBConnectionString = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void editMenu_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void eatNormal_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "Select TOP 1 * From foods Where 低熱量餐=0 ORDER BY NEWID()";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            string strMsg = "";
            while (reader.Read())
            {
                strMsg = $"{reader["食物名稱"]}";
            }
            reader.Close();
            con.Close();
            if (strMsg != ""){
                label1.Text = "決定了！等等就吃"+strMsg+"！";
            }
            else{
                MessageBox.Show("選單中沒有一般餐！");
            }
        }
        
        private void eatDiet_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "Select TOP 1 * From foods Where 低熱量餐=1 ORDER BY NEWID()";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            string strMsg = "";

            while (reader.Read())
            {

                strMsg = $"{reader["食物名稱"]}";
            }
            reader.Close();
            con.Close();
            if (strMsg != "")
            {
                label1.Text = "終於肥到要吃" + strMsg + "的地步了嗎...";
            }
            else
            {
                MessageBox.Show("選單中沒有減肥餐！");
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();
        }

    }
}
