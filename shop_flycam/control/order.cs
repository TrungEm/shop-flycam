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
    public partial class order : UserControl
    {
        public void loadBackColor()
        {
            Color color = new Color();
            color = function.getBackColor(0);

            panel1.BackColor = color;
            panel2.BackColor = color;
            panel3.BackColor = color;
            panel4.BackColor = color;
            panel5.BackColor = color;
            panel6.BackColor = color;
            panel7.BackColor = color;
            panel8.BackColor = color;
            panel11.BackColor = color;
            panel12.BackColor = color;
            panel13.BackColor = color;
            panel14.BackColor = color;
            panel15.BackColor = color;
            dgvOrder.BackgroundColor = color;
            pnlMain.BackColor = color;
            pnlTop.BackColor = color;
        }

        public order()
        {
            InitializeComponent();

            dgvOrder.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        }

        private void order_Load(object sender, EventArgs e)
        {
            loadBackColor();
        }
    }
}
