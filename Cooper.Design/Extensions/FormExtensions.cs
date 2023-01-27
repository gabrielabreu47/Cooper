using Cooper.Design.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Cooper.Design.Extensions
{
    internal static class FormExtensions
    {
        public static T GetForm<T>() where T : UserControl
        {
            return Program.ServiceProvider.GetRequiredService<T>();
        }

        public static T? GetParent<T>(Control control) where T : Control
        {
            while (control is not T)
            {
                if (control.Parent is null) throw new Exception("saco de bobo");

                control = control.Parent;
            }

            return control as T;
        }

        public static Panel OpenForm<T>(this Panel panel) where T : UserControl
        {
            panel.Controls.Clear();

            var form = Program.ServiceProvider.GetRequiredService<T>();

            if (form == null) throw new Exception("Form is not registered in the service collection");

            form.Dock = DockStyle.Fill;

            panel.Controls.Add(form);

            return panel;
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

        public static Panel OpenForm<T>(this Panel panel, T form, int column = 1, int row = 1)
            where T : UserControl
        {
            panel.Controls.Clear();

            form.Dock = DockStyle.Fill;

            panel.Controls.Add(form);

            return panel;
        }

        public static TableLayoutPanel OpenForm<T>(this TableLayoutPanel tableLayoutPanel, T form,  int column = 1, int row = 1)
            where T : Control
        { 
            tableLayoutPanel.Controls.Clear();

            form.Dock = DockStyle.Fill;

            tableLayoutPanel.Controls.Add(form, column, row);

            return tableLayoutPanel;
        }

        public static void OpenFormDialog<T>(Action? OnClose = null) where T : UserControl
        {
            var form = Program.ServiceProvider.GetRequiredService<T>();

            if (form == null) throw new Exception("Form is not registered in the service collection");

            var dialog = new Dialog();

            dialog.bodyLayoutPanel.OpenForm<T>(0, 0);

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK || result == DialogResult.Yes && OnClose != null) OnClose?.Invoke();
        }

        public static void OpenFormDialog<T>(T form, Action? OnClose = null) where T : UserControl
        {
            var dialog = new Dialog();

            dialog.bodyLayoutPanel.OpenForm(form, 0, 0);

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK && OnClose != null) OnClose.Invoke();
        }
    }
}
