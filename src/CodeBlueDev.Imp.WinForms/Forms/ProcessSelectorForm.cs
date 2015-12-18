using CodeBlueDev.Imp.WinForms.ViewModels;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace CodeBlueDev.Imp.WinForms.Forms
{
    public partial class ProcessSelectorForm : Form
    {
        private readonly BindingList<ProcessSelectorFormViewModel> _processes;

        // TODO: Column Sort with Sort Direction
        // TODO: Allow User to filter based on criteria

        public delegate void ProcessSelectedHandler(Process process);

        public ProcessSelectedHandler ProcessSelect;

        public ProcessSelectorForm()
        {
            _processes = new BindingList<ProcessSelectorFormViewModel>();

            InitializeComponent();

            DataGridViewProcesses.DataSource = _processes;
        }

        private void OnProcessSelectorFormShown(object sender, EventArgs e)
        {
            PopulateProcessesDataGridView();
        }

        private void OnProcessSelectorFormClosing(object sender, FormClosingEventArgs e)
        {
            // If user cancelled selection, continue closing the form.
            if (DialogResult == DialogResult.Cancel)
            {
                return;
            }
            // Get the selected process and make sure it is still valid.
            ProcessSelectorFormViewModel selectedProcessRow = _processes[DataGridViewProcesses.SelectedRows[0].Index];
            try
            {
                Process selectedProcess = Process.GetProcessById(selectedProcessRow.Id);
                SelectProcess(selectedProcess);
            }
            catch (ArgumentException)
            {
                e.Cancel = true;
                MessageBox.Show(
                    $"Process with an Id of {selectedProcessRow.Id} is no longer running or the Id may have expired. Please try again.", 
                    "Invalid Process Selected", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                PopulateProcessesDataGridView();
            }
        }

        private void SelectProcess(Process process)
        {
            ProcessSelectedHandler processSelectedHandler = ProcessSelect;
            processSelectedHandler?.Invoke(process);
        }

        private void OnDataGridViewProcessColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show($"//TODO: Sort by {DataGridViewProcesses.Columns[e.ColumnIndex].Name}");
        }

        private void OnDataGridViewProcessCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Do nothing if the user is resizing rows.
            if (Cursor.Current == Cursors.SizeNS)
            {
                return;
            }
            // If the RowIndex is valid, count the double click as a selection.
            if (e.RowIndex > 0 && e.RowIndex < _processes.Count)
            {
                ButtonSelect.PerformClick();
            }
        }

        private void OnRefreshButtonClick(object sender, EventArgs e)
        {
            PopulateProcessesDataGridView();
        }

        private void PopulateProcessesDataGridView()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _processes.Clear();
                foreach (Process process in Process.GetProcesses())
                {
                    _processes.Add(new ProcessSelectorFormViewModel()
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
