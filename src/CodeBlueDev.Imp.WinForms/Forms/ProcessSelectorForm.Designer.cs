namespace CodeBlueDev.Imp.WinForms.Forms
{
    partial class ProcessSelectorForm
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
            this.ProcessDataGridView = new System.Windows.Forms.DataGridView();
            this.ButtonRefresh = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ProcessDataGridView
            // 
            this.ProcessDataGridView.AllowUserToAddRows = false;
            this.ProcessDataGridView.AllowUserToDeleteRows = false;
            this.ProcessDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProcessDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProcessDataGridView.Location = new System.Drawing.Point(12, 12);
            this.ProcessDataGridView.MultiSelect = false;
            this.ProcessDataGridView.Name = "ProcessDataGridView";
            this.ProcessDataGridView.ReadOnly = true;
            this.ProcessDataGridView.RowHeadersVisible = false;
            this.ProcessDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProcessDataGridView.Size = new System.Drawing.Size(415, 489);
            this.ProcessDataGridView.TabIndex = 0;
            this.ProcessDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnProcessDataGridViewCellDoubleClick);
            this.ProcessDataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OnProcessDataGridViewColumnHeaderMouseClick);
            // 
            // ButtonRefresh
            // 
            this.ButtonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonRefresh.Location = new System.Drawing.Point(12, 507);
            this.ButtonRefresh.Name = "ButtonRefresh";
            this.ButtonRefresh.Size = new System.Drawing.Size(75, 23);
            this.ButtonRefresh.TabIndex = 1;
            this.ButtonRefresh.Text = "&Refresh";
            this.ButtonRefresh.UseVisualStyleBackColor = true;
            this.ButtonRefresh.Click += new System.EventHandler(this.OnRefreshButtonClick);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(352, 507);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 2;
            this.ButtonCancel.Text = "&Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // ButtonSelect
            // 
            this.ButtonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonSelect.Location = new System.Drawing.Point(271, 507);
            this.ButtonSelect.Name = "ButtonSelect";
            this.ButtonSelect.Size = new System.Drawing.Size(75, 23);
            this.ButtonSelect.TabIndex = 3;
            this.ButtonSelect.Text = "&Select";
            this.ButtonSelect.UseVisualStyleBackColor = true;
            // 
            // ProcessSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(439, 542);
            this.Controls.Add(this.ButtonSelect);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonRefresh);
            this.Controls.Add(this.ProcessDataGridView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(455, 475);
            this.Name = "ProcessSelectorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Process";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnProcessSelectorFormClosing);
            this.Shown += new System.EventHandler(this.OnProcessSelectorFormShown);
            ((System.ComponentModel.ISupportInitialize)(this.ProcessDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ProcessDataGridView;
        private System.Windows.Forms.Button ButtonRefresh;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonSelect;
    }
}