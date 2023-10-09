using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shop_flycam.form
{
    public partial class frmMain : Form
    {
        public string name = "{?}";

        public frmMain()
        {
            InitializeComponent();
        }

        // Hàm di chuyển active
        private void moveActive(Control btn)
        {
            pnlActive.Top = btn.Top;
            pnlActive.Height = btn.Height;
        }

        // Load form Main
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Lấy tên user
            lblName.Text = name;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn thoát chứ ?", "??", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                moveActive(btnLogout);
                Close();
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            moveActive(btnDashboard);
            dashboard.Visible = true;
            flycam.Visible = false;
            buyer.Visible = false;
            salesman.Visible = false;
        }

        private void btnFlycam_Click(object sender, EventArgs e)
        {
            moveActive(btnFlycam);
            dashboard.Visible = false;
            flycam.Visible = true;
            buyer.Visible = false;
            salesman.Visible = false;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            moveActive(btnOrder);
            dashboard.Visible = false;
            flycam.Visible = false;
            buyer.Visible = false;
            salesman.Visible = false;
        }

        private void btnBuyer_Click(object sender, EventArgs e)
        {
            moveActive(btnBuyer);
            dashboard.Visible = false;
            flycam.Visible = false;
            buyer.Visible = true;
            salesman.Visible = false;
        }

        private void btnSalesman_Click(object sender, EventArgs e)
        {
            moveActive(btnSalesman);
            dashboard.Visible = false;
            flycam.Visible = false;
            buyer.Visible = false;
            salesman.Visible = true;
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            moveActive(btnAccount);
            dashboard.Visible = false;
            flycam.Visible = false;
            buyer.Visible = false;
            salesman.Visible = false;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
