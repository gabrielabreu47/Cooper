using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooper.Design.Extensions
{
    internal static class FormExtensions
    {
        public static Panel OpenForm<T>(this Panel tableLayoutPanel) where T : UserControl
        {
            tableLayoutPanel.Controls.Clear();

            var form = Program.ServiceProvider.GetRequiredService<T>();

            if (form == null) throw new Exception("Form is not registered in the service collection");

            form.Dock = DockStyle.Fill;

            tableLayoutPanel.Controls.Add(form);

            return tableLayoutPanel;
        }

        public static TableLayoutPanel OpenForm<T>(this TableLayoutPanel tableLayoutPanel, int column = 1, int row = 1) where T : UserControl
        {
            tableLayoutPanel.Controls.Clear();

            var form = Program.ServiceProvider.GetRequiredService<T>();

            if (form == null) throw new Exception("Form is not registered in the service collection");

            form.Dock = DockStyle.Fill;

            tableLayoutPanel.Controls.Add(form, column, row);

            return tableLayoutPanel;
        }
    }
}
