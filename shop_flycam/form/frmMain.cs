using shop_flycam.lib;
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

            // Thay đổi backgr
            Color color = new Color();
            color = function.getBackColor(0);
            btnAccount.BackColor = color;
            btnBuyer.BackColor = color;
            btnDashboard.BackColor = color;
            btnFlycam.BackColor = color;
            btnLogout.BackColor = color;
            btnOrder.BackColor = color;
            btnSalesman.BackColor = color;
            panelSidebar.BackColor = color;

            //color = function.getBackColor(1);
            
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
            dashboard.loadData();

            dashboard.Visible = true;
            flycam.Visible = false;
            order.Visible = false;
            buyer.Visible = false;
            salesman.Visible = false;
            user.Visible = false;

        }

        private void btnFlycam_Click(object sender, EventArgs e)
        {
            moveActive(btnFlycam);
            //flycam.loadBackColor();

            dashboard.Visible = false;
            flycam.Visible = true;
            order.Visible = false;
            buyer.Visible = false;
            salesman.Visible = false;
            user.Visible = false;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            moveActive(btnOrder);
            //order.loadBackColor();

            dashboard.Visible = false;
            flycam.Visible = false;
            order.Visible = true;
            buyer.Visible = false;
            salesman.Visible = false;
            user.Visible = false;
        }

        private void btnBuyer_Click(object sender, EventArgs e)
        {
            moveActive(btnBuyer);
            //buyer.loadBackColor();

            dashboard.Visible = false;
            flycam.Visible = false;
            order.Visible = false;
            buyer.Visible = true;
            salesman.Visible = false;
            user.Visible = false;
        }

        private void btnSalesman_Click(object sender, EventArgs e)
        {
            moveActive(btnSalesman);
            //salesman.loadBackColor();

            dashboard.Visible = false;
            flycam.Visible = false;
            order.Visible = false;
            buyer.Visible = false;
            salesman.Visible = true;
            user.Visible = false;
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            moveActive(btnAccount);
            //user.loadBackColor();

            dashboard.Visible = false;
            flycam.Visible = false;
            order.Visible = false;
            buyer.Visible = false;
            salesman.Visible = false;
            user.Visible = true;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            function.disConnect();
            Application.Exit();
        }
    }
}
