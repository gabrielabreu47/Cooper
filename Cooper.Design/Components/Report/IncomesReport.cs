using Cooper.Application.Bills.Handlers;
using Cooper.Application.Bills.Interfaces;
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
    public partial class IncomesReport : UserControl
    {
        private readonly IBillHandler _billHandler;

        public IncomesReport(IBillHandler billHandler)
        {
            InitializeComponent();
            _billHandler = billHandler;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (Parent is not TableLayoutPanel parent)
            {
                throw new Exception("Saco de bobo");
            }

            parent.OpenForm<Report>();
        }

        private void IncomesReport_Load(object sender, EventArgs e)
        {
            startDate.Value = DateTime.Today.AddMonths(-1).Date;

            endDate.Value = DateTime.Today;

            LoadReport(startDate.Value, endDate.Value);
        }

        private async void LoadReport(DateTime startDate, DateTime endDate)
        {
            var timeSpan = new TimeSpan(23, 59, 59);
            endDate = endDate.Date.Add(timeSpan);

            var report = await _billHandler.GetIncomesReport(startDate, endDate);

            billCountLabel.Text = report.InvoicedBills.ToString();
            pendingBillCountLabel.Text = report.PendingBills.ToString();
            totalIncomelabel.Text = $"${report.PaidAmount:N} DOP";
            outsandingIncomeLabel.Text = $"${report.PendingAmount:N} DOP";
        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {
            LoadReport(startDate.Value, endDate.Value);
        }

        private void endDate_ValueChanged(object sender, EventArgs e)
        {
            LoadReport(startDate.Value, endDate.Value);
        }
    }
}
