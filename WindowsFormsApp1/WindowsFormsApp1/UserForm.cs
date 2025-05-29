using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace WindowsFormsApp1
{
    public partial class UserForm : Form
    {
        private BindingList<Product> _products;
        private List<CartItem> _cart;
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
            public string Category { get; set; } // Категория (например, "Продукты", "Электроника")
        }
        public class CartItem
        {
            public Product Product { get; set; }
            public int Quantity { get; set; }
            public decimal TotalPrice => Product.Price * Quantity;
        }

        public UserForm(BindingList<Product> products, List<CartItem> cart)
        {
            InitializeComponent();
            _products = products;
            _cart = cart;
            dataGridViewProducts.DataSource = _products;
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dataGridViewProducts.AutoGenerateColumns = false;
            dataGridViewProducts.Columns.Clear();

            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Название" });
            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "Цена" });
            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Stock", HeaderText = "Доступно" });
            dataGridViewProducts.Columns.Add(new DataGridViewButtonColumn { Text = "В корзину", UseColumnTextForButtonValue = true });
        }

        private void dataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0 && e.RowIndex < _products.Count)
            {
                var product = _products[e.RowIndex];
                if (product.Stock > 0)
                {
                    var existingItem = _cart.FirstOrDefault(item => item.Product.Id == product.Id);
                    if (existingItem != null)
                    {
                        existingItem.Quantity++;
                    }
                    else
                    {
                        _cart.Add(new CartItem { Product = product, Quantity = 1 });
                    }
                    product.Stock--;
                    dataGridViewProducts.Refresh();
                    MessageBox.Show("Товар добавлен в корзину!");
                }
            }
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            var cartForm = new CartForm(_cart);
            cartForm.Show();
        }
    }
}
