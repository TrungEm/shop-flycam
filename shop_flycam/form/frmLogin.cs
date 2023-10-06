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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void emptyBox()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        // Đóng chương trình
        private void picClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Hiển mật khẩu
        private void picShow_Click(object sender, EventArgs e)
        {
            if (picShow.Visible)
            {
                txtPassword.UseSystemPasswordChar = false;
                picShow.Visible = false;
                picHide.Visible = true;
            }
        }

        // Ẩn mật khẩu
        private void picHide_Click(object sender, EventArgs e)
        {
            if (picHide.Visible)
            {
                txtPassword.UseSystemPasswordChar = true;
                picShow.Visible = true;
                picHide.Visible = false;
            }
        }

        // Xử lý đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } else if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập Mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } else
            {
                // Khai báo connect CSDL
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Workspace\\university\\2023\\LT-WINDOW\\shop_flycam\\shop_flycam\\QLShopFlycam.mdf;Integrated Security=True");
                DataTable data = new DataTable();
                SqlDataAdapter addData = new SqlDataAdapter();

                SqlCommand cm = new SqlCommand("SELECT COUNT(*) FROM tblUser WHERE username = '" + txtUsername.Text.Trim() + "' AND password = '" + txtPassword.Text.Trim() + "'", conn);
                addData.SelectCommand = cm;
                addData.Fill(data);

                if (data.Rows[0][0].ToString() == "1")
                {
                    frmMain formMain = new frmMain();
                    formMain.ShowDialog();
                    emptyBox();

                } else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        // Show form khôi phục mật khẩu
        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            emptyBox();
            frmForgotPassword frmForPass = new frmForgotPassword();
            frmForPass.ShowDialog();
        }
    }
}
