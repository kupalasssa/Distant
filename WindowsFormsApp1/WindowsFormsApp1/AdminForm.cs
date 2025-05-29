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
    public partial class AdminForm : Form
    {
        private BindingList<Product> _products;

        public AdminForm(BindingList<Product> products)
        {
            InitializeComponent();
            _products = products;
            dataGridViewProducts.DataSource = _products;
            SetupDataGridView();
            LoadCategories();
        }

        private void SetupDataGridView()
        {
            dataGridViewProducts.AutoGenerateColumns = false;
            dataGridViewProducts.Columns.Clear();

            // Колонки:
            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Название" });
            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "Цена" });
            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Stock", HeaderText = "Количество" });
            dataGridViewProducts.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "Category",
                HeaderText = "Категория",
                DataSource = new List<string> { "Продукты", "Электроника", "Одежда" } // Пример категорий
            });
        }

        private void LoadCategories()
        {
            comboBoxCategory.DataSource = new List<string> { "Все", "Продукты", "Электроника", "Одежда" };
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = comboBoxCategory.SelectedItem.ToString();
            if (selectedCategory == "Все")
            {
                dataGridViewProducts.DataSource = _products;
            }
            else
            {
                var filtered = new BindingList<Product>(_products.Where(p => p.Category == selectedCategory).ToList());
                dataGridViewProducts.DataSource = filtered;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _products.Add(new Product { Id = _products.Count + 1, Name = "Новый товар", Price = 0, Stock = 0, Category = "Продукты" });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.CurrentRow != null)
            {
                _products.RemoveAt(dataGridViewProducts.CurrentRow.Index);
            }
        }
    }
}
