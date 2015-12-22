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
        /// The Timer used to update the Process information every tick cycle.
        /// </summary>
        private readonly Timer processTimer;

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

            // Create a new instance of the timer.
            processTimer = new Timer();

            // Associate a time delay and a method that handles the tick event.
            processTimer.Interval = 5000;
            processTimer.Tick += OnProcessTimerTick;
        }

        /// <summary>
        /// Raised by the <see cref="E:System.Windows.Forms.Form.Load"/> event. Shows the ProcessSelectorForm when the MainForm is loaded.
        /// </summary>
        /// <param name="sender">The object responsible for raising the event.</param>
        /// <param name="e">A <see cref="T:System.EventArgs"/> that contains the event data. </param>
        private void OnMainFormLoad(object sender, EventArgs e)
        {
            // Do not show the form until a process has been selected.
            this.Hide();

            // Show the form to select a process from.
            this.ShowSelectProcessForm();
        }

        /// <summary>
        /// Raised by the <see cref="E:ProcessSelectorForm.ProcessSelect"/> event when a Process is selected from the ProcessSelectorForm.
        /// </summary>
        /// <param name="process">The process selected.</param>
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

            // Start the timer that will update the values that could change.
            processTimer.Start();
        }

        /// <summary>
        /// Raised by the <see cref="E:System.Windows.Forms.Form.Closed"/> event. Cleans up before exiting.
        /// </summary>
        /// <param name="sender">The object responsible for raising the event.</param>
        /// <param name="e">A <see cref="T:System.Windows.Forms.FormClosedEventArgs"/> that contains the event data. </param>
        private void OnMainFormClosed(object sender, FormClosedEventArgs e)
        {
            // Cleanup.
            this.processSelectorForm.Dispose();
            this.selectedProcess = null;

            // Check if the timer is going.
            if(this.processTimer.Enabled)
            {
                this.processTimer.Stop();
            }

            // Cleanup the timer
            this.processTimer.Tick -= OnProcessTimerTick;
            this.processTimer.Dispose();
        }

        /// <summary>
        /// Shows the SelectProcessForm to select a Process when the SelectProcessToolStripMenuItem is selected.
        /// </summary>
        /// <param name="sender">The <see langword="object"/> responsible for raising the event.</param>
        /// <param name="e">A <see cref="T:System.EventArgs"/> that contains the event data.</param>
        private void OnSelectProcessToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.ShowSelectProcessForm();
        }

        /// <summary>
        /// Exits the application when the ExitMenuToolStripMenuItem is selected.
        /// </summary>
        /// <param name="sender">The <see langword="object"/> responsible for raising the event.</param>
        /// <param name="e">A <see cref="T:System.EventArgs"/> that contains the event data.</param>
        private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Updates the WindowTitle of the selected Process.
        /// </summary>
        /// <param name="sender">The <see langword="object"/> responsible for raising the event.</param>
        /// <param name="e">A <see cref="T:System.EventArgs"/> that contains the event data.</param>
        private void OnUpdateWindowTitleButtonClick(object sender, EventArgs e)
        {
            // TODO:
        }

        /// <summary>
        /// Updates the Process information every tick cycle.
        /// </summary>
        /// <param name="sender">The <see langword="object"/> responsible for raising the event.</param>
        /// <param name="e">A <see cref="T:System.EventArgs"/> that contains the event data.</param>
        private void OnProcessTimerTick(object sender, EventArgs e)
        {
            // Verify we have a process before trying to update values.
            if (selectedProcess == null)
            {
                return;
            }

            // Stop the timer so we aren't ticking anymore.
            this.processTimer.Stop();

            // Update the display so the user knows what we are doing.
            this.ToolStripStatusLabelMain.Text = "Refreshing Process Information...";
            this.Refresh();
            
            // Update the Process information.
            this.selectedProcess.Refresh();
            this.ShowProcessInfo();

            // Update the display to let the user know we are done.
            this.ToolStripStatusLabelMain.Text = "Refreshed Process Information";
            this.Refresh();

            // restart the timer.
            this.processTimer.Start();
        }

        /// <summary>
        /// Shows <see cref="ProcessSelectorForm"/>SelectorForm and determines whether or not the form should be redisplayed if no Process is selected..
        /// </summary>
        private void ShowSelectProcessForm()
        {
            if(processTimer.Enabled)
            {
                processTimer.Stop();
            }

            while (true)
            {
                // ProcessSelectorForm was closed or canceled
                if (this.processSelectorForm.ShowDialog() != DialogResult.OK)
                {
                    // Check if the user has already selected a process.
                    if (this.selectedProcess != null)
                    {
                        processTimer.Start();
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
