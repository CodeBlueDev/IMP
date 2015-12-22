// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainForm.cs" company="CodeBlueDev">
//   All rights reserved.
// </copyright>
// <summary>
//   Creates an instance of the MainForm to display the contents of a Process.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CodeBlueDev.Imp.WinForms.Forms
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;

    /// <summary>
    /// Creates an instance of the MainForm to display the contents of a Process.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The text displayed when the user does not select a process.
        /// </summary>
        private const string ProcessSelectorFormMessageBoxText = "Unable to run application without a process. Would you like to select a process?";

        /// <summary>
        /// The caption displayed when the user does not select a process.
        /// </summary>
        private const string ProcessSelectorFormMessageBoxCaption = "Must select a process";

        /// <summary>
        /// The form used to select the Process.
        /// </summary>
        private readonly ProcessSelectorForm processSelectorForm;

        /// <summary>
        /// The selected process.
        /// </summary>
        private Process selectedProcess;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class. 
        /// </summary>
        /// <exception cref="Exception">An error occurred in the data source and either there is no handler for the <see cref="E:System.Windows.Forms.DataGridView.DataError" /> event or the handler has set the <see cref="P:System.Windows.Forms.DataGridViewDataErrorEventArgs.ThrowException" /> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException" />.</exception>
        public MainForm()
        {
            this.InitializeComponent();

            // Initialize the form that will allow the user to select a Process.
            this.processSelectorForm = new ProcessSelectorForm();
            this.processSelectorForm.ProcessSelect += this.OnProcessSelect;
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            // Do not show the form until a process has been selected.
            this.Hide();

            // Show the form to select a process from.
            this.ShowSelectProcessForm();
        }

        private void OnProcessSelect(Process process)
        {
            // If the Process was selected on a separate thread, invoke the 
            // OnProcessSelect method on the originating thread.
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<Process>(this.OnProcessSelect), process);
                return;
            }

            // Save the Selected Process.
            this.selectedProcess = process;

            // Display values that should not change.
            this.LabelProcessIdValue.Text = this.selectedProcess.Id.ToString();
            this.LabelProcessNameValue.Text = this.selectedProcess.ProcessName;

            // TODO: Figure out if process is 64 bit process and display to user.

            // TODO: Display the owner if we are able to retrieve it.

            // Display values that could change.
            this.ShowProcessInfo();

            // TODO: Logic to do with the selected process modules.

            // TODO: Start the timer that will update the values that could change.
        }

        private void OnMainFormClosed(object sender, FormClosedEventArgs e)
        {
            // Cleanup.
            this.processSelectorForm.Dispose();
            this.selectedProcess = null;

            // TODO: Dispose of timer.
        }

        private void OnSelectProcessToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.ShowSelectProcessForm();
        }

        private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnUpdateWindowTitleButtonClick(object sender, EventArgs e)
        {
            // TODO:
        }

        /// <summary>
        ///  <see cref="ProcessSelectorForm"/>SelectorForm and determines whether or not the form should be redisplayed.
        /// </summary>
        private void ShowSelectProcessForm()
        {
            while (true)
            {
                // ProcessSelectorForm was closed or cancelled
                if (this.processSelectorForm.ShowDialog() != DialogResult.OK)
                {
                    // Check if the user has already selected a process.
                    if (this.selectedProcess != null)
                    {
                        return;
                    }

                    // Check if the user wants to exit. 
                    if (MessageBox.Show(
                        ProcessSelectorFormMessageBoxText, 
                        ProcessSelectorFormMessageBoxCaption, 
                        MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        this.Close();
                    }
                    else
                    {
                        // User must select a process.
                        continue;
                    }
                }

                break;
            }
        }

        /// <summary>
        /// Show process window title and memory information.
        /// </summary>
        private void ShowProcessInfo()
        {
            // TODO: Will need to bind to Size event to properly put the labels so they do not overlap.
            this.LabelWindowTitleValue.Text = this.selectedProcess.MainWindowTitle;

            this.LabelNonPagedSystemMemoryValue.Text = this.selectedProcess.NonpagedSystemMemorySize64.ToString();
            this.LabelPagedSystemMemoryValue.Text = this.selectedProcess.PagedSystemMemorySize64.ToString();

            this.LabelPagedMemoryValue.Text = this.selectedProcess.PagedMemorySize64.ToString();
            this.LabelPeakPagedMemoryValue.Text = this.selectedProcess.PeakPagedMemorySize64.ToString();

            this.LabelVirtualMemoryValue.Text = this.selectedProcess.VirtualMemorySize64.ToString();
            this.LabelPeakVirtualMemoryValue.Text = this.selectedProcess.PeakVirtualMemorySize64.ToString();
            
            this.LabelPrivateMemoryValue.Text = this.selectedProcess.PrivateMemorySize64.ToString();
        }
    }
}
