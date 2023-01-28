
using Cooper.Application.Products.Dtos;
using Cooper.Application.Products.Interfaces;
using Cooper.Core.Entities;

namespace Cooper.Design.Components.Product
{
    public partial class ProductDetail : UserControl
    {
        private readonly IProductHandler _productHandler;

        public ProductDetail(IProductHandler productHandler)
        {
            _productHandler = productHandler;
            InitializeComponent();
        }

        public int ProductId { get; set; }
        public Action? GoBack { get; set; }

        private void backButton_Click(object sender, EventArgs e)
        {
            GoBack?.Invoke();
        }

        private async void ProductDetail_Load(object sender, EventArgs e)
        {
            var productPrices = await _productHandler.GetProductPrices(ProductId);

            var bindingSource = new BindingSource
            {
                DataSource = productPrices
            };

            priceTable.DataSource = bindingSource;
        }
    }
}
