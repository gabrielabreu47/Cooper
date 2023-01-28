namespace Cooper.Design.Forms
{
    partial class Dialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bodyLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // bodyLayoutPanel
            // 
            this.bodyLayoutPanel.ColumnCount = 1;
            this.bodyLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bodyLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.bodyLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.bodyLayoutPanel.Name = "bodyLayoutPanel";
            this.bodyLayoutPanel.RowCount = 1;
            this.bodyLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bodyLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.bodyLayoutPanel.Size = new System.Drawing.Size(860, 646);
            this.bodyLayoutPanel.TabIndex = 0;
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 646);
            this.Controls.Add(this.bodyLayoutPanel);
            this.Name = "Dialog";
            this.Text = "Dialog";
            this.ResumeLayout(false);

        }

        #endregion

        public TableLayoutPanel bodyLayoutPanel;
    }
}