using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shop_flycam.form
{
    public partial class frmForgotPassword : Form
    {
        public frmForgotPassword()
        {
            InitializeComponent();
        }

        // Đóng chương trình
        private void picClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Sử lý reset password
        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtEmail.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập Email.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                // Khai báo connect CSDL
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Workspace\\university\\2023\\LT-WINDOW\\shop_flycam\\shop_flycam\\QLShopFlycam.mdf;Integrated Security=True");
                DataTable data = new DataTable();
                SqlDataAdapter addData = new SqlDataAdapter();

                SqlCommand cm = new SqlCommand("SELECT COUNT(*) FROM tblUser WHERE username = '" + txtUsername.Text.Trim() + "' AND email = '" + txtEmail.Text.Trim() + "'", conn);
                addData.SelectCommand = cm;
                addData.Fill(data);

                if (data.Rows[0][0].ToString() == "1")
                {
                    SqlCommand cmPass = new SqlCommand("SELECT password FROM tblUser WHERE username = '" + txtUsername.Text.Trim() + "' AND email = '" + txtEmail.Text.Trim() + "'", conn);
                    addData.SelectCommand = cmPass;
                    addData.Fill(data);
                    
                    MessageBox.Show($"Mật khẩu của bạn là: {data.Rows[1][1]}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc email không đúng. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
    }
}
