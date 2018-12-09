using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _1612105_ChangeTK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DataTable dta = new DataTable();
            SqlConnection conm = new SqlConnection(@"Data Source=DESKTOP-3QHMVMG\SQLEXPRESS;Initial Catalog=NHAXE;Integrated Security=True");
            conm.Open();
            try
            {
                SqlCommand myCmd = new SqlCommand("Cha_Tickets", conm);
                myCmd.Parameters.Add("@maKH", SqlDbType.NVarChar).Value =txtMKH.Text;
                myCmd.Parameters.Add("@OldmaChuyenXe", SqlDbType.NVarChar).Value = txtCXCu.Text;
                myCmd.Parameters.Add("@newmaChuyenXe", SqlDbType.NVarChar).Value = txtCXmoi.Text;
                myCmd.Parameters.Add("@ngayThanhToan", SqlDbType.Date).Value = dateTimePicker1.Text;
                myCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dat = new SqlDataAdapter(myCmd);
                dat.Fill(dta);
                dataGrid4.DataSource = dta;
                conm.InfoMessage += new SqlInfoMessageEventHandler(conn_InfoMessage);
                myCmd.ExecuteNonQuery();
                txtMKH.Clear();
                txtCXCu.Clear();
                txtCXmoi.Clear();
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
