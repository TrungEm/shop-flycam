using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_flycam.lib
{
    class function
    {
        public static SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Workspace\\university\\2023\\LT-WINDOW\\shop_flycam\\shop_flycam\\QLShopFlycam.mdf;Integrated Security=True");
        
        // Mở kết nối CSDL
        public static void connect()
        {
            conn.Open();
        }

        // Đóng kết nối CSDL
        public static void disConnect()
        {
            conn.Close();
            conn.Dispose();
            conn = null;
        }

        // Lấy dữ liệu từ CSDL
        public static DataTable getData(string sql)
        {
            DataTable table = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter();

            SqlCommand cmGetUser = new SqlCommand(sql, conn);
            dap.SelectCommand = cmGetUser;
            table.Clear();
            dap.Fill(table);
            return table;
        }

        // Lấy số liệu BackColor
        public static Color getBackColor()
        {
            DataTable table = new DataTable();
            table = getData("SELECT red, green, blue FROM tblBackColor WHERE id = " + 0);
            int red = Convert.ToInt32(table.Rows[0][0]);
            int green = Convert.ToInt32(table.Rows[0][1]);
            int blue = Convert.ToInt32(table.Rows[0][2]);

            Color BackGr = new Color();
            BackGr = Color.FromArgb(red, green, blue);
            return BackGr;
        }
    }
}
