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
    public partial class flycam : UserControl
    {
        public flycam()
        {
            InitializeComponent();

            for (int i = 0; i < 5; i++)
            {
                dgvProduct.Rows.Add(new object[] { "ProDJK2019", "Flycam DJI Air 2S Smart Controller", "20", "5600000", "7200000", "Hàng mới nhập về" });
            }

            dgvProduct.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        }

    }
}
