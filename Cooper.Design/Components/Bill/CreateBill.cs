using AutoMapper;
using Cooper.Application.Bills.Dtos;
using Cooper.Application.Products.Dtos;
using Cooper.Core.Extensions;
using Cooper.Design.Controllers.Bill;

namespace Cooper.Design.Components.Bill
{
    public partial class CreateBill : UserControl
    {
        private readonly ICreateBillController _createBillController;
        private readonly IMapper _mapper;

        public CreateBill(ICreateBillController createBillController, IMapper mapper)
        {
            _createBillController = createBillController;
            _mapper = mapper;
            InitializeComponent();
        }

        private bool _isAddingProduct = true;
        private ProductDto? _currentProduct;
        private List<CreateBillProductDto> products = new List<CreateBillProductDto>();

        private void button6_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void cleanProductAreaButton_Click(object sender, EventArgs e)
        {
            ClearProductArea();
        }

        private void billButton_Click(object sender, EventArgs e)
        {

        }

        private void ClearProductArea()
        {
            productCodeTextBox.Clear();

            productNameLabel.Text = string.Empty;

            productPriceLabel.Text = string.Empty;
            
            retailRadioButton.Checked = false;
            
            wholesaleRadioButton.Checked = false;
            
            stockTextBox.Clear();
        }

        private void ClearAll()
        {
            ClearProductArea();
            
            outstandingCheckBox.Checked = false;
            
            totalLabel.Text = "00.00";
            
            clientNameTextBox.Clear();
            
            telephoneTextBox.Clear();
            
            while(productTable.Rows.Count > 0) 
            {
                productTable.Rows.RemoveAt(productTable.Rows.Count - 1);
            }
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            if(_currentProduct == null|| !_currentProduct.Id.HasValue)
            {
                ThrowError();
                return;
            }

            var createBillProductDto = _mapper.Map<CreateBillProductDto>(this);


            //TODO: MOVE TO A MAP
            //var createBillProductDto = new CreateBillProductDto
            //{
            //    Name = _currentProduct.Name,
            //    ProductId = _currentProduct.Id.Value,
            //    SelledAsWholesale = wholesaleRadioButton.Checked,
            //    Stock = stockTextBox.Text.ToInt()
            //};

            try
            {
                _createBillController.AddProduct(createBillProductDto, products);

                if (!_isAddingProduct)
                {
                    var existingProduct = products.First(x => x.ProductId == _currentProduct.Id);
                    RemoveProduct(existingProduct);
                }

                AddProductToTable(createBillProductDto);

                _isAddingProduct = true;
            }
            catch (Exception ex)
            {
               ThrowError(ex.Message);
            }

        }

        private void AddProductToTable(CreateBillProductDto product)
        {
            //TODO: CREATE MAPPING
            var productTableModel = _mapper.Map<ProductTableModel>(product);
            productTable.Rows.Add(productTableModel);
        }

        private void RemoveProduct(CreateBillProductDto product)
        {
            products.Remove(product);

            foreach(DataGridViewRow row in productTable.Rows)
            {
                if (row.Cells[0].Value.ToString() == product.ProductId.ToString())
                {
                    productTable.Rows.Remove(row);
                }
            }
        }

        private void ThrowError(string message = "")
        {

        }
    }

    class ProductTableModel 
    {
        public string Id { get; set; }
        public string Product { get; set; }
        public string SaleType { get; set; }
        public string Stock { get; set; }
        public string Total { get; set; }
        public string Delete { get; set; }
    }
}
