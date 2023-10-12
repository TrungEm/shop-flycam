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
    public partial class flycam : UserControl
    {
        DataTable table = new DataTable();
        

        /*public void loadBackColor()
        {
            Color color = new Color();
            color = function.getBackColor();

            panel1.BackColor = color;
            panel2.BackColor = color;
            panel4.BackColor = color;
            panel5.BackColor = color;
            panel6.BackColor = color;
            panel8.BackColor = color;
            pnlMain.BackColor = color;
            dgvProduct.BackgroundColor = color;
            tableLayoutPanel.BackColor = color;
        }*/
        
        public flycam()
        {
            InitializeComponent();
            dgvProduct.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        }

        private void flycam_Load(object sender, EventArgs e)
        {
            //loadBackColor();
        }

        
    }
}
