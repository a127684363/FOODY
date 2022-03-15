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
    public partial class Form2 : Form
    {
        SqlConnectionStringBuilder scsb;
        string myDBConnectionString = "";
        
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();
            產生會員資料在DataGridView();
        }
        void 產生會員資料在DataGridView()
        {
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "select Id,食物名稱, 低熱量餐 from foods";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }
            reader.Close();
            con.Close();
        }
        private void btn資料筆數_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "select * from foods";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            string strMsg = "";
            int i = 0;

            while (reader.Read())
            {
                strMsg += $"{reader["Id"]} {reader["食物名稱"]}\n";
                i += 1;
            }

            strMsg += "資料筆數:" + i.ToString();

            reader.Close();
            con.Close();

            MessageBox.Show(strMsg);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt序號_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn資料搜尋_Click(object sender, EventArgs e)
        {
            if (txt名稱.Text != "")
            {
                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();
                string strSQL = "select * from foods where 食物名稱 like @SearchName ";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchName", "%" + txt名稱.Text + "%");
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txt序號.Text = $"{reader["id"]}";
                    txt名稱.Text = $"{reader["食物名稱"]}";
                    chk減肥.Checked = Convert.ToBoolean(reader["低熱量餐"]);
                }
                else
                {
                    MessageBox.Show("查無食物");
                }
                reader.Close();
                con.Close();
            }
            else
            {
                MessageBox.Show("請輸入食物名稱搜尋");
            }
        }

        private void btn新增資料_Click(object sender, EventArgs e)
        {
            if (txt名稱.Text != "")
            {
                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();
                string strSQL = "insert into foods values(@NewName,@NewDiet);";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@NewName", txt名稱.Text);
                cmd.Parameters.AddWithValue("@NewDiet", chk減肥.Checked);

                int rows = cmd.ExecuteNonQuery();
                con.Close();
                產生會員資料在DataGridView();
                MessageBox.Show($"{rows}筆資料新增成功");
            }
            else
            {
                MessageBox.Show("食物名稱必填 !");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn修改資料_Click(object sender, EventArgs e)
        {
            int intID = 0;
            Int32.TryParse(txt序號.Text, out intID);
            if (intID > 0){
                if (txt名稱.Text != "") {
                    SqlConnection con = new SqlConnection(myDBConnectionString);
                    con.Open();
                    string strSQL = "update foods set 食物名稱=@NewName, 低熱量餐=@NewDiet where Id=@SearchId;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@SearchId", intID);
                    cmd.Parameters.AddWithValue("@NewName", txt名稱.Text);
                    cmd.Parameters.AddWithValue("@NewDiet", chk減肥.Checked);
                    int rows = cmd.ExecuteNonQuery();
                    con.Close();
                    產生會員資料在DataGridView();
                    MessageBox.Show($"{rows}筆資料修改成功");
                } else{
                    MessageBox.Show("食物名稱必填 !");
                }
            }else{
                MessageBox.Show("食物不存在");
            }
        }

        private void btn刪除資料_Click(object sender, EventArgs e)
        {
            int intId = 0;
            Int32.TryParse(txt序號.Text, out intId);
            if (intId > 0)
            {
                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();
                string strSQL = "delete from foods where id = @SearchId;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchId", intId);
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                txt序號.Text = "";
                txt名稱.Text = "";
                chk減肥.Checked = false;
                產生會員資料在DataGridView();
                MessageBox.Show($"{rows} 筆資料刪除成功");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0){
                return;
            }
            string strSelectId = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            int intSelectID = Convert.ToInt32(strSelectId);

            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "select * from foods where id = @SearchID ";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchID", intSelectID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txt序號.Text = $"{reader["Id"]}";
                txt名稱.Text = $"{reader["食物名稱"]}";
                chk減肥.Checked = Convert.ToBoolean(reader["低熱量餐"]);
            }
            else
            {
                產生會員資料在DataGridView();
                MessageBox.Show("查無食物");
            }

            reader.Close();
            con.Close();
        }
    }
}
