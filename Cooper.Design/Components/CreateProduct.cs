using AutoMapper;
using Cooper.Application.Products.Dtos;
using Cooper.Application.Products.Interfaces;

namespace Cooper.Design.Components
{
    public partial class CreateProduct : UserControl
    {
        private readonly IMapper _mapper;
        private readonly IProductHandler _productHandler;

        public CreateProduct(IProductHandler productHandler, IMapper mapper)
        {
            _mapper = mapper;
            _productHandler = productHandler;
            InitializeComponent();
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            var createProductDto = _mapper.Map<CreateProductDto>(this);
            await _productHandler.Create(createProductDto);
            Parent.Show();
            Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Parent.Show();
            Hide();
        }
    }
}
