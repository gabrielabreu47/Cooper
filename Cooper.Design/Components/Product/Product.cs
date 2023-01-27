using AutoMapper;
using Cooper.Application.Products.Dtos;
using Cooper.Application.Products.Interfaces;
using Cooper.Core.Extensions;
using Cooper.Design.Extensions;

namespace Cooper.Design.Components.Product
{
    public partial class Product : UserControl
    {
        public Action Refresh { get; set; }
        public Product(IMapper mapper, IProductHandler productHandler)
        {
            InitializeComponent();
            _mapper = mapper;
            _productHandler = productHandler;
            LoadProductTable();
            searchFilterComboBox.SelectedIndex = 0;
            searchFilterComboBox.Text = 
                searchFilterComboBox.Items[searchFilterComboBox.SelectedIndex].ToString();
        }

        private readonly IMapper _mapper;
        private readonly IProductHandler _productHandler;
        private int? _selectedProductId;

        private void CreateProduct(object sender, EventArgs e)
        {
            FormExtensions.OpenFormDialog<ProductForm>(LoadProductTable);
        }

        private void LoadProductTable(List<ListProductDto> products)
        {
            var bindingSource = new BindingSource
            {
                DataSource = products
            };

            productTable.DataSource = bindingSource;

            ShowProductTable();
        }

        private async void LoadProductTable()
        {
            var products = await _productHandler.Get(x => !x.Disabled);

            LoadProductTable(products);
        }

        public void ShowProductTable()
        {
            searchTextBox.Visible = true;
            searchFilterComboBox.Visible = true;
            _selectedProductId = null;
            createProductButton.Visible = true;
            button3.Visible = true;

            productTableLayoutPanel.OpenForm(productTable, 0, 0);
        }

        private async void UpdateProductPrice(object sender, EventArgs e)
        {
            try
            {
                var product = await GetSelectedProduct();

                HideProductOptions();
                createProductButton.Visible = false;

                var updateProdcutPriceForm = FormExtensions.GetForm<UpdatePrice>();

                updateProdcutPriceForm.GoBack = _selectedProductId.HasValue 
                    ? ShowProductDetail : LoadProductTable;

                updateProdcutPriceForm.Product = product;

                _mapper.Map(product, updateProdcutPriceForm);

                productTableLayoutPanel.OpenForm(updateProdcutPriceForm, 0, 0);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void UpdateProduct(object sender, EventArgs e)
        {
            var productForm = FormExtensions.GetForm<ProductForm>();

            productForm.IsEditing = true;

            try
            {
                productForm.ProductId = GetSelectedProductId();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }

            Action action = _selectedProductId.HasValue
                    ? ShowProductDetail : LoadProductTable;

            FormExtensions.OpenFormDialog(productForm, action);
        }

        private async Task<ProductDto> GetSelectedProduct()
        {
            var selectedProduct = GetSelectedProductId();

            return await _productHandler.GetByIdAsNoTracking(selectedProduct);
        }

        private int GetSelectedProductId()
        {
            if(_selectedProductId.HasValue) return _selectedProductId.Value;

            if (productTable.SelectedRows.Count != 1) throw new Exception("Debe seleccionar una fila");

            return productTable.SelectedRows[0].Cells[0].Value.ToInt();
        }

        private void DeleteProduct(object sender, EventArgs e)
        {
            //TODO VALIDATE USER AND ACTION

            try
            {
                var productId = GetSelectedProductId();

                var dialogResult = MessageBox.Show("Seguro que desea eliminar este producto?", "Alerta",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    var productDeleted = _productHandler.Delete(productId).Result;

                    if (productDeleted) LoadProductTable();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return;
            }
        }

        private void ShowProductDetail(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowProductDetail();
        }

        private async void ShowProductDetail()
        {
            ProductDto product;

            try
            {
                 product = await GetSelectedProduct();
            }
            catch (Exception e)
            {
                 MessageBox.Show(e.Message);
                 return;
            }

            _selectedProductId = product.Id;

            HideProductOptions();
            createProductButton.Visible = false;

            var productDetailForm = FormExtensions.GetForm<ProductDetail>();

            _mapper.Map(product, productDetailForm);

            productDetailForm.ProductId = product.Id!.Value;

            productDetailForm.GoBack = ShowProductTable;

            productTableLayoutPanel.OpenForm(productDetailForm, 0, 0);
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

                products = await _productHandler.Get(x => x.Id == searchTextBox.Text.ToInt() && !x.Disabled);

                LoadProductTable(products.ToList());

                return;
            }

            products = await _productHandler.Get(x => 
            (x.Name.ToUpper().StartsWith(searchTextBox.Text.ToString().ToUpper())
            || x.Name.Contains(searchTextBox.Text.ToString().ToUpper())) 
            && !x.Disabled);

            LoadProductTable(products.ToList());
        }

        private void HideProductOptions()
        {
            searchTextBox.Visible= false;
            searchFilterComboBox.Visible= false;
            button3.Visible= false;
        }

        private void UpdateStock(object sender, EventArgs e)
        {
            FormExtensions.OpenFormDialog<UpdateStock>(Refresh);
        }
    }
}
