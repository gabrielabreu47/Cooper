namespace Cooper.Design.Forms
{
    partial class Index
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
            this.generalTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.menuTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.billButton = new System.Windows.Forms.Button();
            this.productButton = new System.Windows.Forms.Button();
            this.reportButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bodyTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.generalTableLayout.SuspendLayout();
            this.menuTableLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // generalTableLayout
            // 
            this.generalTableLayout.ColumnCount = 2;
            this.generalTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.generalTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82F));
            this.generalTableLayout.Controls.Add(this.menuTableLayout, 0, 0);
            this.generalTableLayout.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.generalTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalTableLayout.Location = new System.Drawing.Point(0, 0);
            this.generalTableLayout.Name = "generalTableLayout";
            this.generalTableLayout.RowCount = 1;
            this.generalTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.generalTableLayout.Size = new System.Drawing.Size(1208, 700);
            this.generalTableLayout.TabIndex = 0;
            // 
            // menuTableLayout
            // 
            this.menuTableLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.menuTableLayout.ColumnCount = 1;
            this.menuTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuTableLayout.Controls.Add(this.billButton, 0, 1);
            this.menuTableLayout.Controls.Add(this.productButton, 0, 2);
            this.menuTableLayout.Controls.Add(this.reportButton, 0, 3);
            this.menuTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuTableLayout.Location = new System.Drawing.Point(3, 3);
            this.menuTableLayout.Name = "menuTableLayout";
            this.menuTableLayout.RowCount = 5;
            this.menuTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.44538F));
            this.menuTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.952899F));
            this.menuTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.952899F));
            this.menuTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.952899F));
            this.menuTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.69592F));
            this.menuTableLayout.Size = new System.Drawing.Size(211, 694);
            this.menuTableLayout.TabIndex = 1;
            // 
            // billButton
            // 
            this.billButton.BackColor = System.Drawing.Color.Transparent;
            this.billButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.billButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.billButton.FlatAppearance.BorderSize = 0;
            this.billButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(114)))), ((int)(((byte)(175)))));
            this.billButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.billButton.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.billButton.ForeColor = System.Drawing.Color.White;
            this.billButton.Location = new System.Drawing.Point(0, 93);
            this.billButton.Margin = new System.Windows.Forms.Padding(0);
            this.billButton.Name = "billButton";
            this.billButton.Size = new System.Drawing.Size(211, 69);
            this.billButton.TabIndex = 0;
            this.billButton.Text = "Facturar";
            this.billButton.UseVisualStyleBackColor = false;
            this.billButton.Click += new System.EventHandler(this.billButton_Click);
            // 
            // productButton
            // 
            this.productButton.BackColor = System.Drawing.Color.Transparent;
            this.productButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.productButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productButton.FlatAppearance.BorderSize = 0;
            this.productButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(114)))), ((int)(((byte)(175)))));
            this.productButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.productButton.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.productButton.ForeColor = System.Drawing.Color.White;
            this.productButton.Location = new System.Drawing.Point(0, 162);
            this.productButton.Margin = new System.Windows.Forms.Padding(0);
            this.productButton.Name = "productButton";
            this.productButton.Size = new System.Drawing.Size(211, 69);
            this.productButton.TabIndex = 1;
            this.productButton.Text = "Almacen";
            this.productButton.UseVisualStyleBackColor = false;
            this.productButton.Click += new System.EventHandler(this.productButton_Click);
            // 
            // reportButton
            // 
            this.reportButton.BackColor = System.Drawing.Color.Transparent;
            this.reportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reportButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportButton.FlatAppearance.BorderSize = 0;
            this.reportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(114)))), ((int)(((byte)(175)))));
            this.reportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportButton.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.reportButton.ForeColor = System.Drawing.Color.White;
            this.reportButton.Location = new System.Drawing.Point(0, 231);
            this.reportButton.Margin = new System.Windows.Forms.Padding(0);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(211, 69);
            this.reportButton.TabIndex = 2;
            this.reportButton.Text = "Reportes";
            this.reportButton.UseVisualStyleBackColor = false;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.bodyTableLayout, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(220, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.91354F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.08646F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(985, 694);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // bodyTableLayout
            // 
            this.bodyTableLayout.BackColor = System.Drawing.Color.White;
            this.bodyTableLayout.ColumnCount = 3;
            this.bodyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.bodyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.bodyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.bodyTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyTableLayout.Location = new System.Drawing.Point(3, 3);
            this.bodyTableLayout.Name = "bodyTableLayout";
            this.bodyTableLayout.RowCount = 2;
            this.bodyTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.bodyTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.44444F));
            this.bodyTableLayout.Size = new System.Drawing.Size(979, 618);
            this.bodyTableLayout.TabIndex = 0;
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 700);
            this.Controls.Add(this.generalTableLayout);
            this.Name = "Index";
            this.Text = "Index";
            this.generalTableLayout.ResumeLayout(false);
            this.menuTableLayout.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel generalTableLayout;
        private TableLayoutPanel menuTableLayout;
        private Button billButton;
        private Button productButton;
        private Button reportButton;
        public TableLayoutPanel bodyTableLayout;
        private TableLayoutPanel tableLayoutPanel1;
    }
}