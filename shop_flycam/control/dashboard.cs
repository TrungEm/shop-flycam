using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shop_flycam.control
{
    public partial class dashboard : UserControl
    {
        public dashboard()
        {
            InitializeComponent();

            
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            chartRevenue.Series["Doanh thu"].Points.AddXY(2020, 40500000);
            chartRevenue.Series["Doanh thu"].Points.AddXY(2021, 30900000);
            chartRevenue.Series["Doanh thu"].Points.AddXY(2022, 54200000);
            chartRevenue.Series["Doanh thu"].Points.AddXY(2022, 53500000);
            chartRevenue.Series["Doanh thu"].Points.AddXY(2023, 50500000);
            chartRevenue.Series["Doanh thu"].Points.AddXY(2024, 63500000);

        }

    }
}
