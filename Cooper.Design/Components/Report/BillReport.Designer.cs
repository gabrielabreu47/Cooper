namespace Cooper.Design.Components.Report
{
    partial class BillReport
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainBody = new System.Windows.Forms.TableLayoutPanel();
            this.reportBody = new System.Windows.Forms.TableLayoutPanel();
            this.billTable = new System.Windows.Forms.DataGridView();
            this.headerContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.clientNameTextBox = new System.Windows.Forms.TextBox();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.outstandingCheckBox = new System.Windows.Forms.CheckBox();
            this.backButton = new System.Windows.Forms.Button();
            this.mainBody.SuspendLayout();
            this.reportBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.billTable)).BeginInit();
            this.headerContainer.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainBody
            // 
            this.mainBody.ColumnCount = 1;
            this.mainBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainBody.Controls.Add(this.reportBody, 0, 0);
            this.mainBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainBody.Location = new System.Drawing.Point(0, 0);
            this.mainBody.Name = "mainBody";
            this.mainBody.RowCount = 1;
            this.mainBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainBody.Size = new System.Drawing.Size(1038, 792);
            this.mainBody.TabIndex = 0;
            // 
            // reportBody
            // 
            this.reportBody.ColumnCount = 1;
            this.reportBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.reportBody.Controls.Add(this.billTable, 0, 1);
            this.reportBody.Controls.Add(this.headerContainer, 0, 0);
            this.reportBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportBody.Location = new System.Drawing.Point(3, 3);
            this.reportBody.Name = "reportBody";
            this.reportBody.RowCount = 2;
            this.reportBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.956104F));
            this.reportBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.04389F));
            this.reportBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.reportBody.Size = new System.Drawing.Size(1032, 786);
            this.reportBody.TabIndex = 1;
            // 
            // billTable
            // 
            this.billTable.AllowUserToAddRows = false;
            this.billTable.AllowUserToDeleteRows = false;
            this.billTable.AllowUserToOrderColumns = true;
            this.billTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.billTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.billTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.billTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.billTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.billTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.billTable.DefaultCellStyle = dataGridViewCellStyle4;
            this.billTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.billTable.Location = new System.Drawing.Point(3, 65);
            this.billTable.MultiSelect = false;
            this.billTable.Name = "billTable";
            this.billTable.ReadOnly = true;
            this.billTable.RowHeadersWidth = 70;
            this.billTable.RowTemplate.Height = 25;
            this.billTable.ShowCellErrors = false;
            this.billTable.ShowCellToolTips = false;
            this.billTable.ShowEditingIcon = false;
            this.billTable.ShowRowErrors = false;
            this.billTable.Size = new System.Drawing.Size(1026, 718);
            this.billTable.TabIndex = 10;
            this.billTable.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.billTable_RowHeaderMouseDoubleClick);
            // 
            // headerContainer
            // 
            this.headerContainer.ColumnCount = 2;
            this.headerContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.headerContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.headerContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.headerContainer.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.headerContainer.Controls.Add(this.backButton, 0, 0);
            this.headerContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerContainer.Location = new System.Drawing.Point(0, 3);
            this.headerContainer.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.headerContainer.Name = "headerContainer";
            this.headerContainer.RowCount = 1;
            this.headerContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.headerContainer.Size = new System.Drawing.Size(1029, 56);
            this.headerContainer.TabIndex = 9;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.10647F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.43514F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.41028F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.04813F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.endDate, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.clientNameTextBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.startDate, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.outstandingCheckBox, 3, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(84, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(942, 50);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // endDate
            // 
            this.endDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.endDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.endDate.CustomFormat = "dd/MM/yyyy";
            this.endDate.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDate.Location = new System.Drawing.Point(582, 10);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(129, 29);
            this.endDate.TabIndex = 9;
            this.endDate.ValueChanged += new System.EventHandler(this.endDate_ValueChanged);
            // 
            // clientNameTextBox
            // 
            this.clientNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.clientNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.clientNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clientNameTextBox.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clientNameTextBox.Location = new System.Drawing.Point(10, 12);
            this.clientNameTextBox.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.clientNameTextBox.Name = "clientNameTextBox";
            this.clientNameTextBox.PlaceholderText = "Cliente";
            this.clientNameTextBox.Size = new System.Drawing.Size(433, 26);
            this.clientNameTextBox.TabIndex = 9;
            this.clientNameTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.wholesalePriceTextBox_KeyUp);
            // 
            // startDate
            // 
            this.startDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.startDate.CustomFormat = "dd/MM/yyyy";
            this.startDate.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDate.Location = new System.Drawing.Point(456, 10);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(120, 29);
            this.startDate.TabIndex = 8;
            this.startDate.ValueChanged += new System.EventHandler(this.startDate_ValueChanged);
            // 
            // outstandingCheckBox
            // 
            this.outstandingCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.outstandingCheckBox.AutoSize = true;
            this.outstandingCheckBox.BackColor = System.Drawing.Color.White;
            this.outstandingCheckBox.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.outstandingCheckBox.Location = new System.Drawing.Point(717, 10);
            this.outstandingCheckBox.Name = "outstandingCheckBox";
            this.outstandingCheckBox.Size = new System.Drawing.Size(222, 29);
            this.outstandingCheckBox.TabIndex = 10;
            this.outstandingCheckBox.Text = "Pendientes de Pago";
            this.outstandingCheckBox.UseVisualStyleBackColor = false;
            this.outstandingCheckBox.CheckedChanged += new System.EventHandler(this.outstandingCheckBox_CheckedChanged);
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.BackColor = System.Drawing.Color.White;
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.backButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(114)))), ((int)(((byte)(175)))));
            this.backButton.Location = new System.Drawing.Point(0, 3);
            this.backButton.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(78, 50);
            this.backButton.TabIndex = 9;
            this.backButton.Text = "Volver";
            this.backButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // BillReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.mainBody);
            this.Name = "BillReport";
            this.Size = new System.Drawing.Size(1038, 792);
            this.Load += new System.EventHandler(this.BillReport_Load);
            this.mainBody.ResumeLayout(false);
            this.reportBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.billTable)).EndInit();
            this.headerContainer.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel mainBody;
        private TableLayoutPanel reportBody;
        private TableLayoutPanel headerContainer;
        private TableLayoutPanel tableLayoutPanel3;
        private DateTimePicker endDate;
        private TextBox clientNameTextBox;
        private DateTimePicker startDate;
        private CheckBox outstandingCheckBox;
        private Button backButton;
        private DataGridView billTable;
    }
}
