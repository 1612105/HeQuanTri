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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-3QHMVMG\SQLEXPRESS;Initial Catalog=NHAXE;Integrated Security=True");
            conn.Open();
            try
            {
                SqlCommand myCmd = new SqlCommand("BaoCao", conn);
                myCmd.Parameters.Add("@yearStar", SqlDbType.Int).Value = numericUpDown1.Text;
                myCmd.Parameters.Add("@yearEnd", SqlDbType.Int).Value = numericUpDown2.Text;
                myCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(myCmd);
                da.Fill(dt);
                dataG1.DataSource = dt;
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
