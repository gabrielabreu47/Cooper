using AutoMapper;
using Cooper.Application.Products.Dtos;
using Cooper.Application.Products.Interfaces;

namespace Cooper.Design.Components
{
    public partial class ProductForm : UserControl
    {
        private readonly IMapper _mapper;
        private readonly IProductHandler _productHandler;
        public bool IsEditing { get; set; }
        public int ProductId { get; set; }

        public ProductForm(IProductHandler productHandler, IMapper mapper)
        {
            _mapper = mapper;
            _productHandler = productHandler;
            InitializeComponent();
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsEditing)
            {
                var updateProductDto = _mapper.Map<UpdateProductDto>(this);
                var productUpdated = await _productHandler.Update(ProductId, updateProductDto);
                return;
            }
            var createProductDto = _mapper.Map<CreateProductDto>(this);
            await _productHandler.Create(createProductDto);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

        }

        private async void ProductForm_Load(object sender, EventArgs e)
        {
            if (IsEditing)
            {
                headLabel.Text = "Editar Producto";
                var product = await _productHandler.GetById(ProductId);
                nameTextBox.Text = product.Name;
                descriptionRichTextBox.Text = product.Description;
                amountPerDetailTextBox.Text = product.StockCountAsRetail.ToString();
                amountPerWholesaleTextBox.Text = product.StockCountAsWholesale.ToString();
                priceTextBox.Text = product.UnitPrice.ToString();
                priceWholesaleTextBox.Text = product.WholesalePrice.ToString();
                stockTextBox.Text = product.Stock.ToString();
                priceTextBox.Enabled = false;
                priceWholesaleTextBox.Enabled = false;
                stockTextBox.Enabled = false;
            }
        }
    }
}
