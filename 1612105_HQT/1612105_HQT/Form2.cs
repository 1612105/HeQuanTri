using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _1612105_HQT
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-3QHMVMG\SQLEXPRESS;Initial Catalog=NHAXE;Integrated Security=True");
            conn.Open();
            try
            {
                SqlCommand myCmd = new SqlCommand("BaoCaoMonth", conn);
                myCmd.Parameters.Add("@year", SqlDbType.Int).Value = numericUpDown1.Text;
                myCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(myCmd);
                da.Fill(dt);
                dataGrid2.DataSource = dt;
                conn.InfoMessage += conn_InfoMessage;
                myCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }
        void conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            MessageBox.Show(e.Message); // e.Message để lấy message từ dưới sql gửi lên
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BaoCao exit = new BaoCao();
            exit.Show();
            this.Hide();
        }
    }
}
