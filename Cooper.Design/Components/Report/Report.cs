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
    public partial class Report : UserControl
    {
        public Report()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Parent is not TableLayoutPanel parent)
            {
                throw new Exception("Saco de bobo");
            }

            parent.OpenForm<BillReport>();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (Parent is not TableLayoutPanel parent)
            {
                throw new Exception("Saco de bobo");
            }

            parent.OpenForm<BillReport>();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Parent is not TableLayoutPanel parent)
            {
                throw new Exception("Saco de bobo");
            }

            parent.OpenForm<IncomesReport>();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (Parent is not TableLayoutPanel parent)
            {
                throw new Exception("Saco de bobo");
            }

            parent.OpenForm<IncomesReport>();
        }
    }
}
