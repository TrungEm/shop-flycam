using shop_flycam.form;
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
using shop_flycam.lib;

namespace shop_flycam.control
{
    public partial class dashboard : UserControl
    {
        DataTable table = new DataTable();

        public void loadData() {
            table = function.getData("SELECT COUNT(username) from tblUser");
            lblQuantityAccount.Text = table.Rows[0][0].ToString();

            table = function.getData("SELECT COUNT(codeSalesman) from tblSalesman");
            lblQuantitySalesman.Text = table.Rows[0][0].ToString();

            table = function.getData("SELECT COUNT(codeBuyer) from tblBuyer");
            lblQuantityBuyer.Text = table.Rows[0][0].ToString();

            table = function.getData("SELECT COUNT(codeOrder) from tblOrder");
            lblQuantityOrder.Text = table.Rows[0][0].ToString();
            
        }

        public dashboard()
        {
            InitializeComponent();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            // Dữ liệu đồ thị
            chartRevenue.Series["Doanh thu"].Points.AddXY(2020, 40500000);
            chartRevenue.Series["Doanh thu"].Points.AddXY(2021, 30900000);
            chartRevenue.Series["Doanh thu"].Points.AddXY(2022, 54200000);
            chartRevenue.Series["Doanh thu"].Points.AddXY(2022, 53500000);
            chartRevenue.Series["Doanh thu"].Points.AddXY(2023, 50500000);
            chartRevenue.Series["Doanh thu"].Points.AddXY(2024, 63500000);

            // Lấy dữ liệu số lượng
            loadData();

            // Thay đổi backgr
            //Color color = new Color();
            //color = function.getBackColor();

            //chartRevenue.BackColor = color;
            //pnlTopDashboard.BackColor = color;
            //pnlCanlendar.BackColor = color;
            //pnlChangeBG.BackColor = color;
            //tableLayoutPanel.BackColor = color;
        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {

            /*if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog.Color;

                // Dashboard
                chartRevenue.BackColor = color;
                pnlTopDashboard.BackColor = color;
                pnlCanlendar.BackColor = color;
                pnlChangeBG.BackColor = color;
                tableLayoutPanel.BackColor = color;

                int red = Convert.ToInt32(color.R);
                int green = Convert.ToInt32(color.G);
                int blue = Convert.ToInt32(color.B);

                function.getData("UPDATE tblBackColor SET red = " + red + ", green = " + green + ", blue = " + blue + " WHERE id = 0");
            }*/

            MessageBox.Show("Chức năng chưa hoàn thiện!!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        
    }
}
