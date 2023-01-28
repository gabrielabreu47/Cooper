using Cooper.Application.Products.Dtos;
using Cooper.Application.Products.Interfaces;
using Cooper.Core.Extensions;

namespace Cooper.Design.Components.Product
{
    public partial class UpdatePrice : UserControl
    {
        private readonly IProductHandler _productHandler;
        public ProductDto Product { get; set; }
        public Action GoBack { get; set; }

        public UpdatePrice(IProductHandler productHandler)
        {
            InitializeComponent();
            _productHandler = productHandler;
        }

        private bool FormIsValid()
        {
            if (string.IsNullOrEmpty(priceTextBox.Text)
                || string.IsNullOrEmpty(wholesalePriceTextBox.Text))
            {
                MessageBox.Show("Todos los campos deben de estar completados");
                return false;
            }

            return true;
        }

        private async void billButton_Click(object sender, EventArgs e)
        {
            if (!FormIsValid()) return;

            var updateProductPriceModel = new UpdateProductPriceDto
            {
                ProductId = Product.Id!.Value,
                UnitPrice= priceTextBox.Text.ToDecimal(),
                WholesalePrice= wholesalePriceTextBox.Text.ToDecimal(),
            };

            var productPriceUpdated = await _productHandler.UpdateProductPrice(updateProductPriceModel);

            if (productPriceUpdated)
            {
                GoBack.Invoke();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            GoBack.Invoke();
        }
    }
}
