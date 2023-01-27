using AutoMapper;
using Cooper.Application.Bills.Enums;
using Cooper.Application.Bills.Handlers;
using Cooper.Application.Bills.Interfaces;
using Cooper.Core.Extensions;
using Cooper.Design.Extensions;
using System.ComponentModel;

namespace Cooper.Design.Components.Report
{
    public partial class BillDetail : UserControl
    {
        private readonly IBillHandler _billHandler;

        public int BillId { get; set; }
        public bool IsPending { get; set; }
        public Action GoBack { get; set; }

        public BillDetail(IBillHandler billHandler)
        {
            InitializeComponent();
            _billHandler = billHandler;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GoBack.Invoke();
        }

        private async void changeBillStatusButton_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Seguro que desea marcar esta factura como pagada?",
                "Atencion", MessageBoxButtons.YesNoCancel);
            
            if (dialogResult != DialogResult.Yes) return;
            
            await _billHandler.UpdateStatus(BillId, BillStatus.Invoiced);
            
            statusLabel.Text = BillStatus.Invoiced.GetDescription();
            
            IsPending = false;
            
            changeBillStatusButton.Visible = false;
        }

        private void BillDetail_Load(object sender, EventArgs e)
        {
            if (IsPending)
            {
                changeBillStatusButton.Visible = true;
            }
        }
    }

    public class BillProductDetailModel
    {
        [DisplayName("Id")]
        public int ProductId { get; set; }
        [DisplayName("Producto")]
        public string ProductName { get; set; }
        [DisplayName("Precio de venta")]
        public decimal Price { get; set; }
        [DisplayName("Cantidad")]
        public int Stock { get; set; }
        [DisplayName("Tipo de venta")]
        public string SaleType { get; set; }
        public decimal Total { get; set; }
    }
}
