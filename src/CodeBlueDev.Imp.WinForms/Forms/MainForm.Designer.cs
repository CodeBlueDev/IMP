namespace CodeBlueDev.Imp.WinForms.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.MenuStripMain = new System.Windows.Forms.MenuStrip();
            this.ToolStripMain = new System.Windows.Forms.ToolStrip();
            this.StatusStripMain = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabelMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.GroupBoxProcessInfo = new System.Windows.Forms.GroupBox();
            this.LabelPagedSystemMemoryValue = new System.Windows.Forms.Label();
            this.LabelPagedSystemMemory = new System.Windows.Forms.Label();
            this.LabelNonPagedSystemMemoryValue = new System.Windows.Forms.Label();
            this.LabelNonPagedSystemMemory = new System.Windows.Forms.Label();
            this.LabelProcessNameValue = new System.Windows.Forms.Label();
            this.LabelProcessName = new System.Windows.Forms.Label();
            this.LabelProcessIdValue = new System.Windows.Forms.Label();
            this.LabelProcessId = new System.Windows.Forms.Label();
            this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.LabelPagedMemory = new System.Windows.Forms.Label();
            this.LabelPagedMemoryValue = new System.Windows.Forms.Label();
            this.LabelPeakPagedMemory = new System.Windows.Forms.Label();
            this.LabelPeakPagedMemoryValue = new System.Windows.Forms.Label();
            this.LabelVirtualMemory = new System.Windows.Forms.Label();
            this.LabelVirtualMemoryValue = new System.Windows.Forms.Label();
            this.LabelPeakVirtualMemory = new System.Windows.Forms.Label();
            this.LabelPeakVirtualMemoryValue = new System.Windows.Forms.Label();
            this.StatusStripMain.SuspendLayout();
            this.GroupBoxProcessInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStripMain
            // 
            this.MenuStripMain.Location = new System.Drawing.Point(0, 0);
            this.MenuStripMain.Name = "MenuStripMain";
            this.MenuStripMain.Size = new System.Drawing.Size(484, 24);
            this.MenuStripMain.TabIndex = 0;
            // 
            // ToolStripMain
            // 
            this.ToolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStripMain.Location = new System.Drawing.Point(0, 24);
            this.ToolStripMain.Name = "ToolStripMain";
            this.ToolStripMain.Size = new System.Drawing.Size(484, 25);
            this.ToolStripMain.TabIndex = 1;
            // 
            // StatusStripMain
            // 
            this.StatusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabelMain});
            this.StatusStripMain.Location = new System.Drawing.Point(0, 240);
            this.StatusStripMain.Name = "StatusStripMain";
            this.StatusStripMain.Size = new System.Drawing.Size(484, 22);
            this.StatusStripMain.TabIndex = 2;
            // 
            // ToolStripStatusLabelMain
            // 
            this.ToolStripStatusLabelMain.Name = "ToolStripStatusLabelMain";
            this.ToolStripStatusLabelMain.Size = new System.Drawing.Size(0, 17);
            // 
            // GroupBoxProcessInfo
            // 
            this.GroupBoxProcessInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxProcessInfo.Controls.Add(this.LabelPeakVirtualMemoryValue);
            this.GroupBoxProcessInfo.Controls.Add(this.LabelPeakVirtualMemory);
            this.GroupBoxProcessInfo.Controls.Add(this.LabelVirtualMemoryValue);
            this.GroupBoxProcessInfo.Controls.Add(this.LabelVirtualMemory);
            this.GroupBoxProcessInfo.Controls.Add(this.LabelPeakPagedMemoryValue);
            this.GroupBoxProcessInfo.Controls.Add(this.LabelPeakPagedMemory);
            this.GroupBoxProcessInfo.Controls.Add(this.LabelPagedMemoryValue);
            this.GroupBoxProcessInfo.Controls.Add(this.LabelPagedMemory);
            this.GroupBoxProcessInfo.Controls.Add(this.LabelPagedSystemMemoryValue);
            this.GroupBoxProcessInfo.Controls.Add(this.LabelPagedSystemMemory);
            this.GroupBoxProcessInfo.Controls.Add(this.LabelNonPagedSystemMemoryValue);
            this.GroupBoxProcessInfo.Controls.Add(this.LabelNonPagedSystemMemory);
            this.GroupBoxProcessInfo.Controls.Add(this.LabelProcessNameValue);
            this.GroupBoxProcessInfo.Controls.Add(this.LabelProcessName);
            this.GroupBoxProcessInfo.Controls.Add(this.LabelProcessIdValue);
            this.GroupBoxProcessInfo.Controls.Add(this.LabelProcessId);
            this.GroupBoxProcessInfo.Location = new System.Drawing.Point(12, 52);
            this.GroupBoxProcessInfo.Name = "GroupBoxProcessInfo";
            this.GroupBoxProcessInfo.Size = new System.Drawing.Size(460, 122);
            this.GroupBoxProcessInfo.TabIndex = 0;
            this.GroupBoxProcessInfo.TabStop = false;
            this.GroupBoxProcessInfo.Text = "Process Info";
            // 
            // LabelPagedSystemMemoryValue
            // 
            this.LabelPagedSystemMemoryValue.Location = new System.Drawing.Point(376, 42);
            this.LabelPagedSystemMemoryValue.Name = "LabelPagedSystemMemoryValue";
            this.LabelPagedSystemMemoryValue.Size = new System.Drawing.Size(78, 13);
            this.LabelPagedSystemMemoryValue.TabIndex = 11;
            this.LabelPagedSystemMemoryValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTipMain.SetToolTip(this.LabelPagedSystemMemoryValue, "The amount of pageable system memory, in bytes, allocated for the selected Proces" +
        "s.");
            // 
            // LabelPagedSystemMemory
            // 
            this.LabelPagedSystemMemory.AutoSize = true;
            this.LabelPagedSystemMemory.Location = new System.Drawing.Point(252, 42);
            this.LabelPagedSystemMemory.Name = "LabelPagedSystemMemory";
            this.LabelPagedSystemMemory.Size = new System.Drawing.Size(118, 13);
            this.LabelPagedSystemMemory.TabIndex = 10;
            this.LabelPagedSystemMemory.Text = "Paged System Memory:";
            this.ToolTipMain.SetToolTip(this.LabelPagedSystemMemory, "The amount of pageable system memory, in bytes, allocated for the selected Proces" +
        "s.");
            // 
            // LabelNonPagedSystemMemoryValue
            // 
            this.LabelNonPagedSystemMemoryValue.Location = new System.Drawing.Point(152, 42);
            this.LabelNonPagedSystemMemoryValue.Name = "LabelNonPagedSystemMemoryValue";
            this.LabelNonPagedSystemMemoryValue.Size = new System.Drawing.Size(94, 13);
            this.LabelNonPagedSystemMemoryValue.TabIndex = 9;
            this.LabelNonPagedSystemMemoryValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTipMain.SetToolTip(this.LabelNonPagedSystemMemoryValue, "The amount of nonpaged system memory, in bytes, allocated for the selected Proces" +
        "s.");
            // 
            // LabelNonPagedSystemMemory
            // 
            this.LabelNonPagedSystemMemory.AutoSize = true;
            this.LabelNonPagedSystemMemory.Location = new System.Drawing.Point(6, 42);
            this.LabelNonPagedSystemMemory.Name = "LabelNonPagedSystemMemory";
            this.LabelNonPagedSystemMemory.Size = new System.Drawing.Size(137, 13);
            this.LabelNonPagedSystemMemory.TabIndex = 8;
            this.LabelNonPagedSystemMemory.Text = "Nonpaged System Memory:";
            this.ToolTipMain.SetToolTip(this.LabelNonPagedSystemMemory, "The amount of nonpaged system memory, in bytes, allocated for the selected Proces" +
        "s.");
            // 
            // LabelProcessNameValue
            // 
            this.LabelProcessNameValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelProcessNameValue.Location = new System.Drawing.Point(192, 20);
            this.LabelProcessNameValue.Name = "LabelProcessNameValue";
            this.LabelProcessNameValue.Size = new System.Drawing.Size(262, 13);
            this.LabelProcessNameValue.TabIndex = 0;
            this.LabelProcessNameValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTipMain.SetToolTip(this.LabelProcessNameValue, "The name of the selected Process.");
            // 
            // LabelProcessName
            // 
            this.LabelProcessName.AutoSize = true;
            this.LabelProcessName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelProcessName.Location = new System.Drawing.Point(94, 20);
            this.LabelProcessName.Name = "LabelProcessName";
            this.LabelProcessName.Size = new System.Drawing.Size(92, 13);
            this.LabelProcessName.TabIndex = 0;
            this.LabelProcessName.Text = "Process Name:";
            this.LabelProcessName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTipMain.SetToolTip(this.LabelProcessName, "The name of the selected Process.");
            // 
            // LabelProcessIdValue
            // 
            this.LabelProcessIdValue.Location = new System.Drawing.Point(34, 20);
            this.LabelProcessIdValue.Name = "LabelProcessIdValue";
            this.LabelProcessIdValue.Size = new System.Drawing.Size(54, 13);
            this.LabelProcessIdValue.TabIndex = 0;
            this.LabelProcessIdValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTipMain.SetToolTip(this.LabelProcessIdValue, "The Unique Identifier associated with the Process.");
            // 
            // LabelProcessId
            // 
            this.LabelProcessId.AutoSize = true;
            this.LabelProcessId.Cursor = System.Windows.Forms.Cursors.Default;
            this.LabelProcessId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelProcessId.Location = new System.Drawing.Point(6, 20);
            this.LabelProcessId.Name = "LabelProcessId";
            this.LabelProcessId.Size = new System.Drawing.Size(22, 13);
            this.LabelProcessId.TabIndex = 0;
            this.LabelProcessId.Text = "Id:";
            this.LabelProcessId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTipMain.SetToolTip(this.LabelProcessId, "The Unique Identifier associated with the Process.");
            // 
            // LabelPagedMemory
            // 
            this.LabelPagedMemory.AutoSize = true;
            this.LabelPagedMemory.Location = new System.Drawing.Point(7, 64);
            this.LabelPagedMemory.Name = "LabelPagedMemory";
            this.LabelPagedMemory.Size = new System.Drawing.Size(81, 13);
            this.LabelPagedMemory.TabIndex = 12;
            this.LabelPagedMemory.Text = "Paged Memory:";
            // 
            // LabelPagedMemoryValue
            // 
            this.LabelPagedMemoryValue.Location = new System.Drawing.Point(94, 64);
            this.LabelPagedMemoryValue.Name = "LabelPagedMemoryValue";
            this.LabelPagedMemoryValue.Size = new System.Drawing.Size(152, 13);
            this.LabelPagedMemoryValue.TabIndex = 13;
            this.LabelPagedMemoryValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelPeakPagedMemory
            // 
            this.LabelPeakPagedMemory.AutoSize = true;
            this.LabelPeakPagedMemory.Location = new System.Drawing.Point(252, 64);
            this.LabelPeakPagedMemory.Name = "LabelPeakPagedMemory";
            this.LabelPeakPagedMemory.Size = new System.Drawing.Size(109, 13);
            this.LabelPeakPagedMemory.TabIndex = 14;
            this.LabelPeakPagedMemory.Text = "Peak Paged Memory:";
            // 
            // LabelPeakPagedMemoryValue
            // 
            this.LabelPeakPagedMemoryValue.Location = new System.Drawing.Point(367, 64);
            this.LabelPeakPagedMemoryValue.Name = "LabelPeakPagedMemoryValue";
            this.LabelPeakPagedMemoryValue.Size = new System.Drawing.Size(87, 13);
            this.LabelPeakPagedMemoryValue.TabIndex = 15;
            this.LabelPeakPagedMemoryValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelVirtualMemory
            // 
            this.LabelVirtualMemory.AutoSize = true;
            this.LabelVirtualMemory.Location = new System.Drawing.Point(7, 86);
            this.LabelVirtualMemory.Name = "LabelVirtualMemory";
            this.LabelVirtualMemory.Size = new System.Drawing.Size(79, 13);
            this.LabelVirtualMemory.TabIndex = 16;
            this.LabelVirtualMemory.Text = "Virtual Memory:";
            // 
            // LabelVirtualMemoryValue
            // 
            this.LabelVirtualMemoryValue.Location = new System.Drawing.Point(92, 86);
            this.LabelVirtualMemoryValue.Name = "LabelVirtualMemoryValue";
            this.LabelVirtualMemoryValue.Size = new System.Drawing.Size(154, 13);
            this.LabelVirtualMemoryValue.TabIndex = 17;
            this.LabelVirtualMemoryValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelPeakVirtualMemory
            // 
            this.LabelPeakVirtualMemory.AutoSize = true;
            this.LabelPeakVirtualMemory.Location = new System.Drawing.Point(252, 86);
            this.LabelPeakVirtualMemory.Name = "LabelPeakVirtualMemory";
            this.LabelPeakVirtualMemory.Size = new System.Drawing.Size(107, 13);
            this.LabelPeakVirtualMemory.TabIndex = 18;
            this.LabelPeakVirtualMemory.Text = "Peak Virtual Memory:";
            // 
            // LabelPeakVirtualMemoryValue
            // 
            this.LabelPeakVirtualMemoryValue.Location = new System.Drawing.Point(365, 86);
            this.LabelPeakVirtualMemoryValue.Name = "LabelPeakVirtualMemoryValue";
            this.LabelPeakVirtualMemoryValue.Size = new System.Drawing.Size(89, 13);
            this.LabelPeakVirtualMemoryValue.TabIndex = 19;
            this.LabelPeakVirtualMemoryValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.GroupBoxProcessInfo);
            this.Controls.Add(this.StatusStripMain);
            this.Controls.Add(this.ToolStripMain);
            this.Controls.Add(this.MenuStripMain);
            this.MainMenuStrip = this.MenuStripMain;
            this.Name = "MainForm";
            this.Text = "IMP";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnMainFormClosed);
            this.Load += new System.EventHandler(this.OnMainFormLoad);
            this.StatusStripMain.ResumeLayout(false);
            this.StatusStripMain.PerformLayout();
            this.GroupBoxProcessInfo.ResumeLayout(false);
            this.GroupBoxProcessInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MenuStripMain;
        private System.Windows.Forms.ToolStrip ToolStripMain;
        private System.Windows.Forms.ToolTip ToolTipMain;
        private System.Windows.Forms.GroupBox GroupBoxProcessInfo;
        private System.Windows.Forms.Label LabelProcessIdValue;
        private System.Windows.Forms.Label LabelProcessId;
        private System.Windows.Forms.Label LabelProcessName;
        private System.Windows.Forms.Label LabelProcessNameValue;
        private System.Windows.Forms.Label LabelNonPagedSystemMemory;
        private System.Windows.Forms.Label LabelNonPagedSystemMemoryValue;
        private System.Windows.Forms.Label LabelPagedSystemMemory;
        private System.Windows.Forms.Label LabelPagedSystemMemoryValue;
        private System.Windows.Forms.StatusStrip StatusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabelMain;
        private System.Windows.Forms.Label LabelPagedMemory;
        private System.Windows.Forms.Label LabelPagedMemoryValue;
        private System.Windows.Forms.Label LabelPeakPagedMemoryValue;
        private System.Windows.Forms.Label LabelPeakPagedMemory;
        private System.Windows.Forms.Label LabelVirtualMemory;
        private System.Windows.Forms.Label LabelVirtualMemoryValue;
        private System.Windows.Forms.Label LabelPeakVirtualMemoryValue;
        private System.Windows.Forms.Label LabelPeakVirtualMemory;
    }
}

