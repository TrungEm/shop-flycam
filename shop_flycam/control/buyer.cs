﻿using System;
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
        public buyer()
        {
            InitializeComponent();

            for (int i = 0; i < 5; i++)
            {
                dgvBuyer.Rows.Add(new object[] { "001", "Nguyễn Văn B", "0912324564", "Kiên Giang"});
            }

            dgvBuyer.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        }

    }
}
