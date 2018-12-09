using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace _1612105_Makebill
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dta = new DataTable();
            SqlConnection conm = new SqlConnection(@"Data Source=DESKTOP-3QHMVMG\SQLEXPRESS;Initial Catalog=NHAXE;Integrated Security=True");
            conm.Open();
            try
            {
                SqlCommand Cmd = new SqlCommand("Make_bill", conm);
                Cmd.Parameters.Add("@maCTVX", SqlDbType.NVarChar).Value = txtMaCTV.Text;
                Cmd.Parameters.Add("@ngayTT", SqlDbType.Date).Value = dateTimePicker1.Text;
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dat = new SqlDataAdapter(Cmd);
                dat.Fill(dta);
                dataGrid3.DataSource = dta;
                conm.InfoMessage += conn_InfoMessage;
                Cmd.ExecuteNonQuery();
                txtMaCTV.Clear();
                conm.Close();
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
            this.Hide();
        }
    }
}
