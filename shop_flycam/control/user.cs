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
    public partial class user : UserControl
    {
        public user()
        {
            InitializeComponent();

            for (int i = 0; i < 5; i++)
            {
                dgvUser.Rows.Add(new object[] { "deobiet", "Nguyễn Văn B", "email@gmail.com", "1234abc" });
            }

            dgvUser.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        }
    }
}
