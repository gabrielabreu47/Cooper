using AutoMapper;
using Cooper.Application.Bills.Dtos;
using Cooper.Application.Bills.Interfaces;
using Cooper.Application.Products.Dtos;
using Cooper.Application.Products.Interfaces;
using Cooper.Core.Extensions;
using Cooper.Design.Extensions;
using Cooper.Design.Templates;
using Cooper.Infrastructure.Services;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Cooper.Design.Components.Bill
{
    public partial class CreateBill : UserControl
    {
        private readonly IDocumentService _documentService;
        private readonly IBillHandler _billHandler;
        private readonly IMapper _mapper;
        private readonly IProductHandler _productHandler;
        public ProductDto? _currentProduct;

        private System.Windows.Forms.Button printButton;
        private Font printFont;
        private StreamReader streamToPrint;

        public Action GoBack { get; set; }
        public List<ProductTableModel> Products { get; set; } = new();

        public CreateBill(IBillHandler billHandler, IProductHandler productHandler, IMapper mapper, IDocumentService documentService)
        {
            _documentService = documentService;
            _billHandler = billHandler;
            _mapper = mapper;
            _productHandler = productHandler;
            InitializeComponent();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            GoBack?.Invoke();
        }

        private void cleanProductAreaButton_Click(object sender, EventArgs e)
        {
            ClearProductArea();
        }

        private async void billButton_Click(object sender, EventArgs e)
        {
            if (Products.Count < 1)
            {
                MessageBox.Show("Debe agregar al menos un producto");
                return;
            }

            if(string.IsNullOrEmpty(clientNameTextBox.Text) && outstandingCheckBox.Checked)
            {
                MessageBox.Show("Debe ingresar el nombre del cliente");
                return;
            }

            var createBillDto = _mapper.Map<CreateBillDto>(this);

            if (createBillDto.Phone == "(   )    -") createBillDto.Phone = string.Empty;

            var bill = await _billHandler.Create(createBillDto);

            var billDto = await _billHandler.GetById(bill.Id!.Value);

            PrintBill(billDto);

            //ClearAll();

            //GoBack?.Invoke();
        }

        private void PrintBill(BillDto bill)
        {
            var invoice = FormExtensions.GetForm<invoice>();

            invoice.totalLabel.Text = $"${bill.Total}";

            invoice.dateIdLabel.Text = $"{bill.Date:dd/MM/yyyy} - {bill.Id}";

            invoice.stockLabel.Text = $"ARTICULOS = {bill.Products.Count}";

            foreach(var product in bill.Products)
            {
                var invoiceDetail = FormExtensions.GetForm<invoiceDetail>();

                invoiceDetail.stockPriceLabel.Text = $"{product.Stock} x {product.Price}";

                invoiceDetail.priceLabel.Text = $"{product.PriceTotal}";

                invoiceDetail.productNameLabel.Text = product.Name;

                invoice.Size = new Size(invoice.Size.Width, invoice.Size.Height + 52);

                invoice.invoiceDetailBody.Controls.Add(invoiceDetail);
            }

            var bitmap = new Bitmap(invoice.Width, invoice.Height);

            invoice.DrawToBitmap(bitmap, new Rectangle(0, 0, invoice.Width, invoice.Height));

            PrintDocument pd = new();

            pd.PrintController = new StandardPrintController();

            pd.PrintPage += (s, e) => e.Graphics!.DrawImage(bitmap, 100, 100);

            pd.Print();

            FormExtensions.OpenFormDialog(invoice);
        }

        private void ClearProductArea()
        {
            productCodeTextBox.Clear();

            _currentProduct = null;
            
            retailRadioButton.Checked = true;
            
            wholesaleRadioButton.Checked = false;

            productNameLabel.Text = "Nombre del Producto";

            productPriceLabel.Text = "Precio del Producto";
            
            stockTextBox.Clear();
        }

        private void ClearAll()
        {
            ClearProductArea();
            
            outstandingCheckBox.Checked = false;
            
            totalLabel.Text = "00.00";
            
            clientNameTextBox.Clear();
            
            telephoneTextBox.Clear();

            Products = new List<ProductTableModel>();

            _currentProduct = null;

            LoadProductTable();
        }

        private async void addProductButton_Click(object sender, EventArgs e)
        {
            if(_currentProduct == null || !_currentProduct.Id.HasValue)
            {
                MessageBox.Show("Debe seleccionar un producto");
                return;
            }

            var isNumber = int.TryParse(stockTextBox.Text, out _);

            if (!isNumber)
            {
                MessageBox.Show("Debe ingresar una cantidad numerica");

                return;
            }

            var product = Products.FirstOrDefault(x => x.Id == _currentProduct.Id.Value);

            if (product == null)
            {
                product = _mapper.Map<ProductTableModel>(this);

                var newProductCanBeBilled = await _productHandler.ValidateAvailabilityInStock(product.Id, product.Stock);

                if (!newProductCanBeBilled)
                {
                    MessageBox.Show("La cantidad de productos proporcionada excede la cantidad existente en el almacen");

                    return;
                }

                Products.Add(product);
            }
            else
            {
                HandleExistingProduct(product);
            }

            ClearProductArea();

            UpdateTotal();

            LoadProductTable();
            
        }

        private async void HandleExistingProduct(ProductTableModel existing)
        {
            const string Wholesale = "Por mayor";
            const string Retail = "Al detalle";

            if (existing.SaleType == Wholesale && !wholesaleRadioButton.Checked
                || existing.SaleType == Retail && !retailRadioButton.Checked)
            {
                MessageBox.Show("Ya existe este producto en la compra con otro tipo de venta, es obligatorio mantener el mismo tipo de venta por cada producto");

                return;
            }

            var expectedStock = existing.Stock + stockTextBox.Text.ToInt();

            var productCanBeBilled = await _productHandler.ValidateAvailabilityInStock(existing.Id, expectedStock);

            if (!productCanBeBilled)
            {
                MessageBox.Show("La cantidad de productos proporcionada excede la cantidad existente en el almacen");

                return;
            }

            existing.Stock = expectedStock;

            existing.Total = existing.SaleType == Wholesale
                ? expectedStock * _currentProduct.WholesalePrice
                : expectedStock * _currentProduct.UnitPrice;
        }

        private void LoadProductTable()
        {
            var bindingSource = new BindingSource
            {
                DataSource = Products
            };

            productTable.DataSource = bindingSource;
        }

        private void UpdateTotal()
        {
            decimal total = 0;

            foreach(var product in Products)
            {
                total += product.Total;
            }

            totalLabel.Text = total.ToString();
        }

        private void advancedSearchButton_Click(object sender, EventArgs e)
        {
            var productSearchForm = FormExtensions.GetForm<ProductSearch>();

            FormExtensions.OpenFormDialog(productSearchForm);

            if (productSearchForm.ProductId.HasValue) 
                AssignCurrentProduct(productSearchForm.ProductId.Value);
        }

        private void productCodeTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            var isNumber = int.TryParse(productCodeTextBox.Text, out _);

            if (!isNumber)
            {
                MessageBox.Show("Debe ingresar un numero");
                return;
            }

            var productId = productCodeTextBox.Text.ToInt();

            AssignCurrentProduct(productId);
        }

        private async void AssignCurrentProduct(int productId)
        {
            var productDto = await _productHandler.GetByIdAsNoTracking(productId);

            if (productDto == null)
            {
                MessageBox.Show("Producto no encontrado");

                return;
            }

            productNameLabel.Text = productDto.Name;
            productPriceLabel.Text = productDto.UnitPrice.ToString();

            _currentProduct = productDto;
        }

        private void wholesaleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!wholesaleRadioButton.Checked) return;

            if (_currentProduct == null) return;

            productPriceLabel.Text = _currentProduct.WholesalePrice.ToString();
        }

        private void retailRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!retailRadioButton.Checked) return;

            if (_currentProduct == null) return;

            productPriceLabel.Text = _currentProduct.UnitPrice.ToString();
        }

        private void cleanAllButton_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void productTable_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var result = MessageBox.Show("Seguro que desea remover este registro?", "Atencion", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                var currentItemId = productTable.SelectedRows[0].Cells[0].Value.ToInt();

                var product = Products.FirstOrDefault(x => x.Id == currentItemId);

                if (product != null) Products.Remove(product);
            }

            LoadProductTable();
        }
    }

    public class ProductTableModel 
    {
        public int Id { get; set; }
        [DisplayName("Producto")]
        public string Product { get; set; }
        [DisplayName("Tipo de Venta")]
        public string SaleType { get; set; }
        [DisplayName("Cantidad")]
        public int Stock { get; set; }
        public decimal Total { get; set; }
    }
}
