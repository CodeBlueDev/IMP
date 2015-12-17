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

        public ProcessSelectorForm()
        {
            _processes = new BindingList<ProcessSelectorFormViewModel>();

            InitializeComponent();

            DataGridViewProcesses.DataSource = _processes;
        }

        // TODO: have an event that can be tied to when a Process is selected.

        private void OnSelectProcessFormShown(object sender, EventArgs e)
        {
            PopulateProcessesDataGridView();
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
                    // TODO: Convert to ViewModel and display to the user.
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
