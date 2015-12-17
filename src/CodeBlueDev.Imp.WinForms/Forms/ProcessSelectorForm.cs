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

        public ProcessSelectorForm()
        {
            _processes = new BindingList<ProcessSelectorFormViewModel>();

            InitializeComponent();

            DataGridViewProcesses.DataSource = _processes;
        }

        // TODO: have an event that can be tied to when a Process is selected.

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
