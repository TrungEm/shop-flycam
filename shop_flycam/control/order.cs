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
    public partial class order : UserControl
    {
        DataTable table = new DataTable();

        // Load background
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

        // Load data ra dgv
        public void loadDataGridView()
        {
            dgvOrder.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            table = function.getData("SELECT a.codeProduct, a.nameProduct, b.quantity, b.unitPrice, b.intoMoney FROM tblProduct AS a, tblOrderDetails AS b WHERE a.codeProduct = b.codeProduct AND b.codeOrder = '" + txtCodeOrder.Text + "'");
            dgvOrder.DataSource = table;
            dgvOrder.Columns[0].HeaderText = "Mã flycam";
            dgvOrder.Columns[1].HeaderText = "Tên flycam";
            dgvOrder.Columns[2].HeaderText = "Số lượng";
            dgvOrder.Columns[3].HeaderText = "Đơn giá";
            dgvOrder.Columns[4].HeaderText = "Thành tiền";
        }

        // đẩy thông tin vào compobox
        public void loadInfoCompoBox()
        {
            function.loadComboBox("SELECT codeSalesman FROM tblSalesman WHERE workStatus = 'Đang làm'", comboBoxCodeSalesman, "codeSalesman");
            comboBoxCodeSalesman.SelectedIndex = -1;
            function.loadComboBox("SELECT codeBuyer FROM tblBuyer", comboBoxCodeBuyer, "codeBuyer");
            comboBoxCodeBuyer.SelectedIndex = -1;
            function.loadComboBox("SELECT codeProduct FROM tblProduct", comboBoxCodeProduct, "codeProduct");
            comboBoxCodeProduct.SelectedIndex = -1;
            function.loadComboBox("SELECT codeOrder FROM tblOrder", comboBoxSearch, "codeOrder");
            comboBoxSearch.SelectedIndex = -1;
        }

        // Load data Hoá đơn
        private void loadInfoOrder()
        {
            dateTimePicker.Value = DateTime.Parse(function.getValue("SELECT dateSell FROM tblOrder WHERE codeOrder = '" + txtCodeOrder.Text + "'"));
            
            comboBoxCodeSalesman.Text = function.getValue("SELECT codeSalesman FROM tblOrder WHERE codeOrder = '" + txtCodeOrder.Text + "'");
            
            comboBoxCodeBuyer.Text = function.getValue("SELECT codeBuyer FROM tblOrder WHERE codeOrder = '" + txtCodeOrder.Text + "'");
            
            txtSumMoney.Text = function.getValue("SELECT sumMoney FROM tblOrder WHERE codeOrder = '" + txtCodeOrder.Text + "'");
        }

        // Set các textbox rỗng
        public void empty()
        {
            txtCodeOrder.Text = string.Empty;
            comboBoxCodeBuyer.Text = string.Empty;
            comboBoxCodeProduct.Text = string.Empty;
            txtAddress.Text = string.Empty;
            comboBoxCodeSalesman.Text = string.Empty;
            txtNameBuyer.Text = string.Empty;
            txtNameProduct.Text = string.Empty;
            txtNameSalesman.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtMoney.Text = "0";
            txtSumMoney.Text = "0";
            dateTimePicker.Value = DateTime.Now;
        }

        public order()
        {
            InitializeComponent();
        }

        // order load
        private void order_Load(object sender, EventArgs e)
        {
            loadBackColor();
            loadDataGridView();
            loadInfoCompoBox();
            if (txtCodeOrder.Text != string.Empty)
            {
                btnDelete.Enabled = true;
                btnPrintOrder.Enabled = true;
                btnCancel.Enabled = true;
                loadInfoOrder();
            }
        }
        
        // Thêm đơn hàng
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            btnSave.Enabled = true;
            btnAddOrder.Enabled = false;
            btnCancel.Enabled = true;
            empty();
            txtCodeOrder.Text = function.randomCodeOrder("HD");
            loadDataGridView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "";
            sql = "SELECT codeOrder FROM tblOrder WHERE codeOrder= '" + txtCodeOrder.Text + "'";

            if (!function.isExistKey(sql))
            {
                if (comboBoxCodeSalesman.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBoxCodeSalesman.Focus();
                    return;
                }
                if (comboBoxCodeBuyer.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBoxCodeBuyer.Focus();
                    return;
                }
                
                // Thêm vào bảng đơn hàng
                SqlCommand cm = new SqlCommand("INSERT INTO tblOrder VALUES('" + txtCodeOrder.Text.Trim() + "', '" + comboBoxCodeSalesman.SelectedValue + "', '" + dateTimePicker.Value.ToString("dd/MM/yyyy").Trim() + "', '" + comboBoxCodeBuyer.SelectedValue + "', " + txtSumMoney.Text + ")", function.conn);
                cm.ExecuteNonQuery();
            }

            if (comboBoxCodeProduct.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập mã flycam.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBoxCodeProduct.Focus();
                return;
            }
            if ((txtQuantity.Text.Trim() == string.Empty) || (txtQuantity.Text.Trim() == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantity.Focus();
                return;
            }

            sql = "SELECT codeProduct FROM tblOrderDetails WHERE codeProduct = '" + comboBoxCodeProduct.SelectedValue + "' AND codeOrder = '" + txtCodeOrder.Text.Trim() + "'";
            
            if (function.isExistKey(sql))
            {
                MessageBox.Show("Mã flycam này đã có, bạn phải nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBoxCodeProduct.Text = string.Empty;
                txtQuantity.Text = string.Empty;
                txtUnitPrice.Text = "0";
                comboBoxCodeProduct.Focus();
                return;
            }

            int quantity = Convert.ToInt32(function.getValue("SELECT quantity FROM tblProduct WHERE codeProduct = '" + comboBoxCodeProduct.Text + "'"));
            if (Convert.ToInt32(txtQuantity.Text) > quantity)
            {
                MessageBox.Show("Số lượng flycam này chỉ còn " + quantity + ".", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantity.Text = "";
                txtQuantity.Focus();
                return;
            }
            // Thêm vào bảng chi tiết đơn hàng
            sql = "INSERT INTO tblOrderDetails VALUES('" + txtCodeOrder.Text.Trim() + "','" + comboBoxCodeProduct.Text + "', '" + txtQuantity.Text + "', '" + txtUnitPrice.Text + "', " + txtMoney.Text + ")";
            SqlCommand cm2 = new SqlCommand(sql, function.conn);
            cm2.ExecuteNonQuery();
            loadDataGridView();
            
            // Cập nhật số lượng flycam
            int updateQuantity = quantity - Convert.ToInt32(txtQuantity.Text);
            sql = "UPDATE tblProduct SET quantity = " + updateQuantity + " WHERE codeProduct = '" + comboBoxCodeProduct.Text + "'";
            SqlCommand cm3 = new SqlCommand(sql, function.conn);
            cm3.ExecuteNonQuery();

            // load lại compobox search
            function.loadComboBox("SELECT codeOrder FROM tblOrder", comboBoxSearch, "codeOrder");
            comboBoxSearch.SelectedIndex = -1;

            // Cập nhật tổng giá tiền
            double sumPrice = Convert.ToDouble(function.getValue("SELECT sumMoney FROM tblOrder WHERE codeOrder = '" + txtCodeOrder.Text + "'"));
            double sumPriceNew = sumPrice + Convert.ToDouble(txtMoney.Text);
            sql = "UPDATE tblOrder SET sumMoney = " + sumPriceNew + " WHERE codeOrder = '" + txtCodeOrder.Text + "'";
            SqlCommand cm4 = new SqlCommand(sql, function.conn);
            cm4.ExecuteNonQuery();
            txtSumMoney.Text = sumPriceNew.ToString();
            comboBoxCodeProduct.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtMoney.Text = "0";
            btnDelete.Enabled = true;
            btnAddOrder.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            empty();
            btnAddOrder.Enabled = true;
            btnCancel.Enabled = false;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            loadDataGridView();
        }

        private void comboBoxCodeSalesman_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBoxCodeSalesman.Text);
            if (comboBoxCodeSalesman.Text == string.Empty)
            {
                txtNameSalesman.Text = string.Empty;
            } else
            {
                txtNameSalesman.Text = function.getValue("SELECT nameSalesman FROM tblSalesman WHERE codeSalesman = '" + comboBoxCodeSalesman.SelectedValue + "'");
            }
        }

        private void comboBoxCodeBuyer_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxCodeBuyer.Text == string.Empty)
            {
                txtNameBuyer.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtPhone.Text = string.Empty;
            } else
            {
                //MessageBox.Show(comboBoxCodeBuyer.Text);
                txtNameBuyer.Text = function.getValue("SELECT nameBuyer FROM tblBuyer WHERE codeBuyer = '" + comboBoxCodeBuyer.SelectedValue + "'");
                txtAddress.Text = function.getValue("SELECT address FROM tblBuyer WHERE codeBuyer = '" + comboBoxCodeBuyer.SelectedValue + "'");
                txtPhone.Text = function.getValue("SELECT phone FROM tblBuyer WHERE codeBuyer = '" + comboBoxCodeBuyer.SelectedValue + "'");

            }

        }

        private void comboBoxCodeProduct_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxCodeProduct.Text == string.Empty)
            {
                txtNameProduct.Text = string.Empty;
                txtUnitPrice.Text = string.Empty;
            } else
            {
                txtNameProduct.Text = function.getValue("SELECT nameProduct FROM tblProduct WHERE codeProduct = '" + comboBoxCodeProduct.SelectedValue + "'");
                txtUnitPrice.Text = function.getValue("SELECT outPrice FROM tblProduct WHERE codeProduct = '" + comboBoxCodeProduct.SelectedValue + "'");
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            int quantity, price;
            if (txtQuantity.Text == string.Empty)
            {
                quantity = 0;
            } else
            {
                quantity = Convert.ToInt32(txtQuantity.Text);
            }
            if (txtUnitPrice.Text == string.Empty)
            {
                price = 0;
            } else
            {
                price = Convert.ToInt32(txtUnitPrice.Text);
            }
            txtMoney.Text = (quantity * price).ToString();
        }

        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {
            if (comboBoxSearch.Text == string.Empty)
            {
                MessageBox.Show("Bạn phải chọn mã đơn hàng để tìm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtCodeOrder.Text = comboBoxSearch.Text;
            loadInfoOrder();
            loadDataGridView();
            btnCancel.Enabled = true;
            btnDelete.Enabled = true;
        }

        // Xoá sản phẩm trong bảng hoá đơn
        private void dgvOrder_DoubleClick(object sender, EventArgs e)
        {
            if (table.Rows.Count == 0) return;
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn xoá flycam này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                string codeProductDe = dgvOrder.CurrentRow.Cells["codeProduct"].Value.ToString();
                int quantityDe = Convert.ToInt32(dgvOrder.CurrentRow.Cells["quantity"].Value.ToString());
                double intoMoneyDe = Convert.ToDouble(dgvOrder.CurrentRow.Cells["intoMoney"].Value.ToString());
                
                SqlCommand cm = new SqlCommand("DELETE tblOrderDetails WHERE codeOrder = '" + txtCodeOrder.Text + "' AND codeProduct = '" + codeProductDe + "'", function.conn);
                cm.ExecuteNonQuery();
                
                int quantity = Convert.ToInt32(function.getValue("SELECT quantity FROM tblProduct WHERE codeProduct = '" + codeProductDe + "'"));
                int quantityNew = quantity + quantityDe;
                SqlCommand cm2 = new SqlCommand("UPDATE tblProduct SET quantity = " + quantityNew + " WHERE codeProduct= '" + codeProductDe + "'", function.conn);
                cm2.ExecuteNonQuery();
                
                double sumMoney = Convert.ToDouble(function.getValue("SELECT sumMoney FROM tblOrder WHERE codeOrder = '" + txtCodeOrder.Text + "'"));
                double sumMoneyNew = sumMoney - intoMoneyDe;
                SqlCommand cm3 = new SqlCommand("UPDATE tblOrder SET sumMoney = " + sumMoneyNew + " WHERE codeOrder = '" + txtCodeOrder.Text + "'", function.conn);
                cm3.ExecuteNonQuery();
                txtSumMoney.Text = sumMoneyNew.ToString();
                
                loadDataGridView();
            }
        }

        // Xoá hoá đơn
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn xoá hoá đơn này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                int quantity, quantityNew, quantityDe;
                DataTable tableUpdate = function.getData("SELECT codeProduct ,quantity FROM tblOrderDetails WHERE codeOrder = '" + txtCodeOrder.Text + "'");
                for (int row = 0; row <= tableUpdate.Rows.Count - 1; row++)
                {
                    quantity = Convert.ToInt32(function.getValue("SELECT quantity FROM tblProduct WHERE codeProduct = '" + tableUpdate.Rows[row][0].ToString() + "'"));
                    quantityDe = Convert.ToInt32(tableUpdate.Rows[row][1].ToString());
                    quantityNew = quantity + quantityDe;

                    SqlCommand cm = new SqlCommand("UPDATE tblProduct SET quantity = " + quantityNew + " WHERE codeProduct = '" + tableUpdate.Rows[row][0].ToString() + "'", function.conn);
                    cm.ExecuteNonQuery();
                }

                SqlCommand cm2 = new SqlCommand("DELETE tblOrderDetails WHERE codeOrder = '" + txtCodeOrder.Text + "'", function.conn);
                cm2.ExecuteNonQuery();


                SqlCommand cm3 = new SqlCommand("DELETE tblOrder WHERE codeOrder = '" + txtCodeOrder.Text + "'", function.conn);
                cm3.ExecuteNonQuery();
                loadDataGridView();
                empty();
                btnDelete.Enabled = false;
                btnPrintOrder.Enabled = false;
            }
        }
    }
}
