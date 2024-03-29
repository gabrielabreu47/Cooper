﻿
using Cooper.Design.Components.Bill;
using Cooper.Design.Components.Product;
using Cooper.Design.Components.Report;
using Cooper.Design.Extensions;

namespace Cooper.Design.Forms
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        private void SetFocus(Button focusedButton)
        {
            foreach (var control in menuTableLayout.Controls)
            {
                if (control is not Button) continue;

                var button = control as Button;

                if (button == focusedButton)
                {
                    button.BackColor = Color.FromArgb(63, 114, 175);
                    continue;
                }

                button.BackColor = Color.FromArgb(17, 45, 78);
            }
        }

        private void billButton_Click(object sender, EventArgs e)
        {
            SetFocus(billButton);
            bodyTableLayout.OpenForm<CreateBill>();
        }

        private void productButton_Click(object sender, EventArgs e)
        {
            OpenProductForm();
        }

        private void OpenProductForm()
        {
            SetFocus(productButton);
            var productForm = FormExtensions.GetForm<Product>();
            productForm.Refresh = OpenProductForm;
            bodyTableLayout.OpenForm(productForm);
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            SetFocus(reportButton);
            bodyTableLayout.OpenForm<Report>();
        }

        private void Index_Load(object sender, EventArgs e)
        {
            SetFocus(billButton);
            bodyTableLayout.OpenForm<CreateBill>();
        }
    }
}
