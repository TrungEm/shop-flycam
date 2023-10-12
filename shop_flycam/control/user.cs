using shop_flycam.lib;
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

namespace shop_flycam.control
{
    public partial class user : UserControl
    {
        // Load background
        public void loadBackColor()
        {
            Color color = new Color();
            color = function.getBackColor(0);

            panel1.BackColor = color;
            panel2.BackColor = color;
            panel4.BackColor = color;
            panel5.BackColor = color;
            pnlMain.BackColor = color;
            dgvUser.BackgroundColor = color;
            tableLayoutPanel.BackColor = color;
        }

        // Load data ra dgv
        public void loadDataGridView()
        {
            DataTable table = new DataTable();
            table = function.getData("SELECT * FROM tblUser");
            dgvUser.DataSource = table;
            dgvUser.Columns[0].HeaderText = "Tên đăng nhập";
            dgvUser.Columns[1].HeaderText = "Họ tên";
            dgvUser.Columns[2].HeaderText = "Mật khẩu";
            dgvUser.Columns[3].HeaderText = "Email";
        }

        public void empty()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtFullname.Text = "";
            txtEmail.Text = "";
        }

        public user()
        {
            InitializeComponent();

            dgvUser.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        }

        // Sự kiện load control user
        private void user_Load(object sender, EventArgs e)
        {
            loadBackColor();
            loadDataGridView();
        }

        // Thêm tài khoản
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string fullname = txtFullname.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } else if (fullname == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập Họ tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } else if (email == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập Email.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } else if (password == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập Mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } else
            {
                SqlCommand cm = new SqlCommand("INSERT INTO tblUser VALUES('" + username + "', N'" + fullname + "', '" + password + "', '" + email +"')", function.conn);
                cm.ExecuteNonQuery();

                loadDataGridView();
                empty();
            }

        }

        // Cập nhật User
        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string fullname = txtFullname.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            DataTable table = new DataTable();
            table = function.getData("SELECT COUNT(username) FROM tblUser WHERE username =  '" + username + "'");
            
            if (table.Rows[0][0].ToString() == "0")
            {
                MessageBox.Show("Tên đăng nhập không tồn tại!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (fullname == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập Họ tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (email == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập Email.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (password == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập Mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                SqlCommand cm = new SqlCommand("UPDATE tblUser SET fullname = N'" + fullname + "', email = '" + email + "', password = '" + password + "' WHERE username = '" + username + "'" , function.conn);
                cm.ExecuteNonQuery();

                loadDataGridView();
                empty();
            }
        }

        // Xoá User
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            if (username == string.Empty)
            {
                MessageBox.Show("Vui lòng điền tên đăng nhập để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } else
            {
                DataTable table = new DataTable();
                table = function.getData("SELECT COUNT(username) FROM tblUser WHERE username =  '" + username + "'");
                if (table.Rows[0][0].ToString() == "0")
                {
                    MessageBox.Show("Tên đăng nhập không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                } else
                {
                    DialogResult dialogResult = MessageBox.Show($"Bạn chắc chắn muốn xoá tài khoản {username} ?", "??", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SqlCommand cm = new SqlCommand("DELETE FROM tblUser WHERE username = '" + username + "'", function.conn);
                        cm.ExecuteNonQuery();

                        loadDataGridView();
                        empty();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            loadDataGridView();
            empty();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
