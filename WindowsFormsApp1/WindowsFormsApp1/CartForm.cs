using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.UserForm;

namespace WindowsFormsApp1
{
    public partial class CartForm : Form
    {
        private List<CartItem> _cart;

        public CartForm(List<CartItem> cart)
        {
            InitializeComponent();
            _cart = cart;
            RefreshCart();
        }

        private void RefreshCart()
        {
            dataGridViewCart.DataSource = null;
            dataGridViewCart.DataSource = _cart;
            SetupDataGridView();

            decimal total = _cart.Sum(item => item.TotalPrice);
            lblTotal.Text = $"Общая сумма: {total:C}";
        }

        private void SetupDataGridView()
        {
            dataGridViewCart.AutoGenerateColumns = false;
            dataGridViewCart.Columns.Clear();

            dataGridViewCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Product.Name", HeaderText = "Товар" });
            dataGridViewCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Product.Price", HeaderText = "Цена" });
            dataGridViewCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "Количество" });
            dataGridViewCart.Columns.Add(new DataGridViewButtonColumn { Text = "Удалить", UseColumnTextForButtonValue = true });
        }

        private void dataGridViewCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0 && e.RowIndex < _cart.Count)
            {
                var item = _cart[e.RowIndex];
                item.Product.Stock += item.Quantity;
                _cart.RemoveAt(e.RowIndex);
                RefreshCart();
            }
        }
    }
}
