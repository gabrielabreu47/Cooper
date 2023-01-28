using AutoMapper;
using Cooper.Application.Bills.Dtos;
using Cooper.Application.Bills.Enums;
using Cooper.Application.Bills.Handlers;
using Cooper.Application.Bills.Interfaces;
using Cooper.Core.Extensions;
using Cooper.Design.Extensions;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Cooper.Design.Components.Report
{
    public partial class BillReport : UserControl
    {
        private readonly IMapper _mapper;
        private readonly IBillHandler _billHandler;

        public BillReport(IMapper mapper, IBillHandler billHandler)
        {
            InitializeComponent();
            _mapper = mapper;
            _billHandler = billHandler;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (Parent is not TableLayoutPanel parent)
            {
                throw new Exception("Saco de bobo");
            }

            parent.OpenForm<Report>();
        }

        public void ShowBillTable()
        {
            headerContainer.Visible= true;
            mainBody.OpenForm(reportBody, 0, 0);
        }

        private void BillReport_Load(object sender, EventArgs e)
        {
            startDate.Value = DateTime.Now.AddMonths(-1);

            endDate.Value = DateTime.Now;
        }

        private void LoadBillTable(List<BillReportTable> bills)
        {
            billTable.DataSource = new BindingSource
            {
                DataSource = bills
            };

            ShowBillTable();
        }

        private async void billTable_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var billId = billTable.SelectedRows[0].Cells[0].Value.ToInt();

            var bill = await _billHandler.GetById(billId);

            var billDetailForm = FormExtensions.GetForm<BillDetail>();

            _mapper.Map(bill, billDetailForm);

            var productTable = _mapper.Map<List<BillProductDetailModel>>(bill.Products);

            billDetailForm.productTable.DataSource = new BindingSource { DataSource = productTable };

            billDetailForm.GoBack = FilterTable;

            headerContainer.Visible= false;

            mainBody.OpenForm(billDetailForm, 0, 0);
        }

        private async void FilterTable()
        {
            Expression<Func<Core.Entities.Bill, bool>>? expression = null;

            if (!string.IsNullOrEmpty(clientNameTextBox.Text) && outstandingCheckBox.Checked)
                expression = x => (x.ClientName!.ToUpper().StartsWith(clientNameTextBox.Text.ToString().ToUpper())
                    || x.ClientName.ToUpper().Contains(clientNameTextBox.Text.ToString().ToUpper()))
                && x.State == BillStatus.Pending.ToInt();

            else if (!string.IsNullOrEmpty(clientNameTextBox.Text))
                expression = x => x.ClientName!.ToUpper().StartsWith(clientNameTextBox.Text.ToString().ToUpper())
                    || x.ClientName.ToUpper().Contains(clientNameTextBox.Text.ToString().ToUpper());

            else if (outstandingCheckBox.Checked)
                expression = x => x.State == BillStatus.Pending.ToInt();

            var currentBills = expression == null
                ? await _billHandler.Get(startDate.Value, endDate.Value) 
                : await _billHandler.Get(startDate.Value, endDate.Value, expression);

            var bills = _mapper.Map<List<BillReportTable>>(currentBills);

            LoadBillTable(bills);
        }

        private void outstandingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FilterTable();
        }

        private void endDate_ValueChanged(object sender, EventArgs e)
        {
            FilterTable();
        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {
            FilterTable();
        }

        private void wholesalePriceTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            FilterTable();
        }
    }

    public class BillReportTable
    {
        public int Id { get; set; }
        [DisplayName("Fecha")]
        public string Date { get; set; }
        [DisplayName("Cliente")]
        public string ClientName { get; set; }
        public decimal Total { get; set; }
        [DisplayName("Estado")]
        public string Status { get; set; }
    }
}
