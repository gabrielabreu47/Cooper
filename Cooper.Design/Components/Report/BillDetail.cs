using Cooper.Application.Bills.Handlers;
using Cooper.Application.Bills.Interfaces;
using Cooper.Design.Extensions;

namespace Cooper.Design.Components.Report
{
    public partial class BillDetail : UserControl
    {
        private readonly IBillHandler _billHandler;
        public int BillId { get; set; }

        public BillDetail(IBillHandler billHandler)
        {
            InitializeComponent();
            _billHandler = billHandler;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var billReportForm = FormExtensions.GetParent<BillReport>(this);

            billReportForm!.ShowBillTable();
        }

        private void BillDetail_Load(object sender, EventArgs e)
        {
            var bill = _billHandler.GetById(BillId);
        }
    }
}
