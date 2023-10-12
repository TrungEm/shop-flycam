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

namespace shop_flycam.control
{
    public partial class buyer : UserControl
    {
        public void loadBackColor()
        {
            Color color = new Color();
            color = function.getBackColor(0);

            panel1.BackColor = color;
            panel2.BackColor = color;
            panel4.BackColor = color;
            panel5.BackColor = color;
            dgvBuyer.BackgroundColor = color;
            pnlMain.BackColor = color;
            tableLayoutPanel.BackColor = color;
        }

        public buyer()
        {
            InitializeComponent();

            for (int i = 0; i < 5; i++)
            {
                dgvBuyer.Rows.Add(new object[] { "001", "Nguyễn Văn B", "0912324564", "Kiên Giang"});
            }

            dgvBuyer.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        }

        private void buyer_Load(object sender, EventArgs e)
        {
            loadBackColor();
        }
    }
}
