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
            this.MenuStripMain = new System.Windows.Forms.MenuStrip();
            this.ToolStripMain = new System.Windows.Forms.ToolStrip();
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.ToolStripMain);
            this.Controls.Add(this.MenuStripMain);
            this.MainMenuStrip = this.MenuStripMain;
            this.Name = "MainForm";
            this.Text = "IMP";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnMainFormClosed);
            this.Load += new System.EventHandler(this.OnMainFormLoad);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.MenuStrip MenuStripMain;
        private System.Windows.Forms.ToolStrip ToolStripMain;

        #endregion
    }
}

