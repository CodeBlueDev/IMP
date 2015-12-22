using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using CodeBlueDev.Imp.WinForms.ViewModels.ProcessSelectorForm;
using CodeBlueDev.Imp.WinForms.Properties;

namespace CodeBlueDev.Imp.WinForms.Forms
{

    /// <summary>
    /// Displays a list of Processes to select a <see cref="Process"/> from.
    /// </summary>
    public partial class ProcessSelectorForm : Form
    {
        /// <summary>
        /// The list of Processes to show in the <see cref="DataGridView"/>.
        /// </summary>
        private readonly BindingList<ProcessDataGridViewModel> processes;

        // TODO: Column Sort with Sort Direction
        // TODO: Allow User to filter based on criteria

        /// <summary>
        /// Handler used when an event is selected from the list of Processes.
        /// </summary>
        /// <param name="selectedProcess">The <see cref="Process"/> that was selected.</param>
        public delegate void ProcessSelectedHandler(Process selectedProcess);

        /// <summary>
        /// The event activated when an event is selected from the list of Processes.
        /// </summary>
        public ProcessSelectedHandler ProcessSelect;

        /// <summary>
        /// Creates an instance of the ProcessSelectorForm to display a list of Processes to
        /// select a <see cref="Process"/> from.
        /// </summary>
        /// <exception cref="Exception">An error occurred in the data source and either there is no handler for the <see cref="E:System.Windows.Forms.DataGridView.DataError" /> event or the handler has set the <see cref="P:System.Windows.Forms.DataGridViewDataErrorEventArgs.ThrowException" /> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException" />.</exception>
        public ProcessSelectorForm()
        {
            this.processes = new BindingList<ProcessDataGridViewModel>();

            this.InitializeComponent();

            this.ProcessDataGridView.DataSource = this.processes;
        }

        /// <summary>
        /// Raised by the <see cref="E:System.Windows.Forms.Form.Shown"/> event.
        /// </summary>
        /// <param name="sender">The object responsible for raising the event.</param>
        /// <param name="e">A <see cref="T:System.EventArgs"/> that contains the event data. </param>
        private void OnProcessSelectorFormShown(object sender, EventArgs e)
        {
            this.PopulateProcessDataGridView();
        }

        /// <summary>
        /// Raised by the <see cref="E:System.Windows.Forms.Form.FormClosing"/> event.
        /// </summary>
        /// <param name="sender">The object responsible for raising the event.</param>
        /// <param name="e">A <see cref="T:System.Windows.Forms.FormClosingEventArgs"/> that contains the event data. </param>
        private void OnProcessSelectorFormClosing(object sender, FormClosingEventArgs e)
        {
            // If user canceled selection, continue closing the form.
            if (this.DialogResult == DialogResult.Cancel)
            {
                return;
            }
            // Get the selected process and make sure it is still valid.
            ProcessDataGridViewModel selectedProcessRow =
                this.processes[this.ProcessDataGridView.SelectedRows[0].Index];
            try
            {
                Process selectedProcess = Process.GetProcessById(selectedProcessRow.Id);
                this.SelectProcess(selectedProcess);
            }
            // The process is not valid.
            catch (ArgumentException)
            {
                e.Cancel = true;
                MessageBox.Show(
                    $"Process with an Id of {selectedProcessRow.Id} is no longer running or the Id may have expired. Please try again.", 
                    Resources.ProcessSelectorForm_OnProcessSelectorFormClosing_InvalidProcessSelected, 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.PopulateProcessDataGridView();
            }
        }

        /// <summary>
        /// Notifies any event subscribers with the <see cref="Process"/> that has been selected.
        /// </summary>
        /// <param name="selectedProcess">The Process selected.</param>
        private void SelectProcess(Process selectedProcess)
        {
            ProcessSelectedHandler processSelectedHandler = this.ProcessSelect;
            processSelectedHandler?.Invoke(selectedProcess);
        }

        /// <summary>
        /// Raised by the <see cref="E:System.Windows.Forms.DataGridView.ColumnHeaderMouseClick"/> event.
        /// </summary>
        /// <param name="sender">The object responsible for raising the event.</param>
        /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellMouseEventArgs"/> that contains the event data. </param>
        private void OnProcessDataGridViewColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show($"//TODO: Sort by {this.ProcessDataGridView.Columns[e.ColumnIndex].Name}");
        }

        /// <summary>
        /// Raised by the <see cref="E:System.Windows.Forms.DataGridView.CellDoubleClick"/> event.
        /// </summary>
        /// <param name="sender">The object responsible for raising the event.</param>
        /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"/> that contains the event data. </param>
        private void OnProcessDataGridViewCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Do nothing if the user is resizing rows.
            if (Cursor.Current == Cursors.SizeNS)
            {
                return;
            }
            // If the RowIndex is valid, count the double click as a selection.
            if (e.RowIndex > 0 && e.RowIndex < this.processes.Count)
            {
                this.ButtonSelect.PerformClick();
            }
        }

        /// <summary>
        /// Raised by the <see cref="E:System.Windows.Forms.Control.Click"/> event.
        /// </summary>
        /// <param name="sender">The object responsible for raising the event.</param>
        /// <param name="e">A <see cref="T:System.EventArgs"/> that contains the event data. </param>
        private void OnRefreshButtonClick(object sender, EventArgs e)
        {
            this.PopulateProcessDataGridView();
        }

        /// <summary>
        /// Updates the <see cref="DataGridView"/> with the list of currently running Processes.
        /// </summary>
        private void PopulateProcessDataGridView()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.processes.Clear();
                foreach (Process process in Process.GetProcesses())
                {
                    this.processes.Add(new ProcessDataGridViewModel()
                    {
                        Id = process.Id,
                        Name = process.ProcessName,
                        Title = process.MainWindowTitle,
                    });
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
