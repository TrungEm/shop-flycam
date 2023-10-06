using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_flycam.utils
{
    class connDatabase
    {
        // Khai báo connect CSDL
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Workspace\\university\\2023\\LT-WINDOW\\shop_flycam\\shop_flycam\\QLShopFlycam.mdf;Integrated Security=True");
        DataTable data = new DataTable();
        SqlDataAdapter addData = new SqlDataAdapter();
    }
}
