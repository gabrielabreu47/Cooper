using Cooper.Application.Products.Dtos;
using Cooper.Application.Products.Interfaces;
using Cooper.Core.Extensions;

namespace Cooper.Design.Components.Bill
{
    public partial class ProductSearch : UserControl
    {
        private readonly IProductHandler _productHandler;

        public int? ProductId { get; set; }
        public ProductSearch(IProductHandler productHandler)
        {
            InitializeComponent();
            _productHandler = productHandler;

            LoadProductTable();

            searchFilterComboBox.SelectedIndex = 0;
            searchFilterComboBox.Text =
                searchFilterComboBox.Items[searchFilterComboBox.SelectedIndex].ToString();
        }

        private void productTable_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ProductId = productTable.SelectedRows[0].Cells[0].Value.ToInt();

            var parent = Parent.Parent as Form;

            parent!.DialogResult = DialogResult.OK;

            parent!.Close();
        }

        private void LoadProductTable(List<ListProductDto> products)
        {
            var bindingSource = new BindingSource
            {
                DataSource = products
            };

            productTable.DataSource = bindingSource;
        }

        private async void LoadProductTable()
        {
            var products = await _productHandler.Get();

            LoadProductTable(products);
        }

        private async void Search(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(searchTextBox.Text))
            {
                LoadProductTable();
                return;
            }

            List<ListProductDto> products = new();

            if (searchFilterComboBox.SelectedIndex == 0)
            {
                var isNumber = int.TryParse(searchTextBox.Text, out _);

                if (!isNumber)
                {
                    MessageBox.Show("Debe ingresar un numero");
                    searchTextBox.Clear();
                    return;
                }

                products = await _productHandler.Get(x => x.Id == searchTextBox.Text.ToInt());

                LoadProductTable(products.ToList());

                return;
            }

            products = await _productHandler.Get(x =>
            x.Name.ToUpper().StartsWith(searchTextBox.Text.ToString().ToUpper())
            || x.Name.Contains(searchTextBox.Text.ToString().ToUpper()));

            LoadProductTable(products.ToList());
        }
    }
}
