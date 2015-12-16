namespace CodeBlueDev.Imp.WinForms.Forms
{
    partial class SelectProcessForm
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
            this.DataGridViewProcesses = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewProcesses)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewProcesses
            // 
            this.DataGridViewProcesses.AllowUserToAddRows = false;
            this.DataGridViewProcesses.AllowUserToDeleteRows = false;
            this.DataGridViewProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewProcesses.Location = new System.Drawing.Point(13, 13);
            this.DataGridViewProcesses.Name = "DataGridViewProcesses";
            this.DataGridViewProcesses.ReadOnly = true;
            this.DataGridViewProcesses.Size = new System.Drawing.Size(259, 150);
            this.DataGridViewProcesses.TabIndex = 0;
            // 
            // SelectProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.DataGridViewProcesses);
            this.Name = "SelectProcessForm";
            this.Text = "SelectProcessForm";
            this.Shown += new System.EventHandler(this.OnSelectProcessFormShown);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewProcesses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewProcesses;
    }
}