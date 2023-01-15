using AutoMapper;
using Cooper.Application.Bills.Handlers;
using Cooper.Application.Bills.Interfaces;
using Cooper.Core.Extensions;
using Cooper.Design.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            bodyTableLayoutPanel.OpenForm(billTable, 0, 0);
        }

        private void BillReport_Load(object sender, EventArgs e)
        {
            startDate.Value = DateTime.Now.AddMonths(-1);

            endDate.Value = DateTime.Now;

            LoadBillTable();
        }

        private void LoadBillTable(List<BillReportTable> bills)
        {
            billTable.DataSource = new BindingSource
            {
                DataSource = bills
            };
        }

        private async void LoadBillTable()
        {
            var currentBills = await _billHandler.Get(startDate.Value, endDate.Value);

            var bills = _mapper.Map<List<BillReportTable>>(currentBills);

            LoadBillTable(bills);
        }

        private async void billTable_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var billId = billTable.SelectedRows[0].Cells[0].Value.ToInt();

            var bill = await _billHandler.GetById(billId);

            var billDetailForm = FormExtensions.GetForm<BillDetail>();

            _mapper.Map(bill, billDetailForm);

            bodyTableLayoutPanel.OpenForm(billDetailForm, 0, 0);
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
