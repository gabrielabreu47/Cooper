using AutoMapper;
using Cooper.Application.Products.Dtos;
using Cooper.Application.Products.Interfaces;
using Cooper.Core.Extensions;
using System.ComponentModel;

namespace Cooper.Design.Components.Product
{
    public partial class UpdateStock : UserControl
    {
        private readonly IProductHandler _productHandler;
        private List<ProductAndStock> productsStock;

        public UpdateStock(IProductHandler productHandler)
        {
            InitializeComponent();
            _productHandler = productHandler;
            productsStock = new();
        }

        private async void UpdateStock_Load(object sender, EventArgs e)
        {
            var products = await _productHandler.Get(x => !x.Disabled);
            productComboBox.DataSource = products;
            productComboBox.DisplayMember = "Name";
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            var isNumber = int.TryParse(stockTextBox.Text, out _);

            if (!isNumber)
            {
                MessageBox.Show("Debe ingresar un numero");
                return;
            }

            var currentProduct = productComboBox.SelectedItem as ListProductDto;

            var existing = productsStock.FirstOrDefault(x => x.Id == currentProduct!.Id);
            
            if (existing != null)
            {
                existing.Stock += stockTextBox.Text.ToInt();

                stockTextBox.Clear();

                LoadProductTable();

                return;
            }

            var newUpdateProductStock = new ProductAndStock
            {
                Id = currentProduct!.Id,
                Name = currentProduct!.Name,
                Stock = stockTextBox.Text.ToInt()

            };

            productsStock.Add(newUpdateProductStock);

            stockTextBox.Clear();

            LoadProductTable();
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            var updateProductsStock = productsStock.Select(x => 
                new UpdateProductStockDto
                {
                    ProductId = x.Id,
                    Stock = x.Stock
                })
                .ToList();

            await _productHandler.UpdateProductsStock(updateProductsStock);
        }

        private void productTable_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var result = MessageBox.Show("Seguro que desea remover este registro?", "Atencion", MessageBoxButtons.YesNoCancel);
            
            if(result == DialogResult.Yes)
            {
                var currentItemId = productTable.SelectedRows[0].Cells[0].Value.ToInt();

                var product = productsStock.FirstOrDefault(x => x.Id == currentItemId);

                if (product != null) productsStock.Remove(product);
            }

            LoadProductTable();
        }

        private void LoadProductTable()
        {
            var bindingSource = new BindingSource
            {
                DataSource = productsStock
            };

            productTable.DataSource = bindingSource;
        }
    }

    class ProductAndStock 
    {
        public int Id { get; set; }
        [DisplayName("Nombre")]
        public string Name { get; set; }
        [DisplayName("Cantidad")]
        public int Stock { get; set; }
    }
}
