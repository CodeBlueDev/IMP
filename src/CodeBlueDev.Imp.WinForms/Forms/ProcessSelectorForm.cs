﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using CodeBlueDev.Imp.WinForms.ViewModels.ProcessSelectorForm;

namespace CodeBlueDev.Imp.WinForms.Forms
{
    /// <summary>
    /// Displays a list of Processes to select a Process from.
    /// </summary>
    public partial class ProcessSelectorForm : Form
    {
        /// <summary>
        /// The list of Processes to show in the DataGridView.
        /// </summary>
        private readonly BindingList<ProcessDataGridViewModel> _processes;

        // TODO: Column Sort with Sort Direction
        // TODO: Allow User to filter based on criteria

        /// <summary>
        /// Handler used when an event is selected from the list of Processes.
        /// </summary>
        /// <param name="selectedProcess">The Process that was selected.</param>
        public delegate void ProcessSelectedHandler(Process selectedProcess);

        /// <summary>
        /// The event activated when an event is selected from the list of Processes.
        /// </summary>
        public ProcessSelectedHandler ProcessSelect;

        /// <summary>
        /// Creates an instance of the ProcessSelectorForm to display a list of Processes to
        /// select a Process from.
        /// </summary>
        public ProcessSelectorForm()
        {
            _processes = new BindingList<ProcessDataGridViewModel>();

            InitializeComponent();

            ProcessDataGridView.DataSource = _processes;
        }

        private void OnProcessSelectorFormShown(object sender, EventArgs e)
        {
            PopulateProcessDataGridView();
        }

        private void OnProcessSelectorFormClosing(object sender, FormClosingEventArgs e)
        {
            // If user cancelled selection, continue closing the form.
            if (DialogResult == DialogResult.Cancel)
            {
                return;
            }
            // Get the selected process and make sure it is still valid.
            ProcessDataGridViewModel selectedProcessRow = _processes[ProcessDataGridView.SelectedRows[0].Index];
            try
            {
                Process selectedProcess = Process.GetProcessById(selectedProcessRow.Id);
                SelectProcess(selectedProcess);
            }
            // The process is not valid.
            catch (ArgumentException)
            {
                e.Cancel = true;
                MessageBox.Show(
                    $"Process with an Id of {selectedProcessRow.Id} is no longer running or the Id may have expired. Please try again.", 
                    "Invalid Process Selected", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                PopulateProcessDataGridView();
            }
        }

        /// <summary>
        /// Notifies any event subscribers with the Process that has been selected.
        /// </summary>
        /// <param name="selectedProcess">The Process selected.</param>
        private void SelectProcess(Process selectedProcess)
        {
            ProcessSelectedHandler processSelectedHandler = ProcessSelect;
            processSelectedHandler?.Invoke(selectedProcess);
        }

        private void OnProcessDataGridViewColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show($"//TODO: Sort by {ProcessDataGridView.Columns[e.ColumnIndex].Name}");
        }

        private void OnProcessDataGridViewCellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
            PopulateProcessDataGridView();
        }

        /// <summary>
        /// Updates the DataGridView with the list of currently running Processes.
        /// </summary>
        private void PopulateProcessDataGridView()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _processes.Clear();
                foreach (Process process in Process.GetProcesses())
                {
                    _processes.Add(new ProcessDataGridViewModel()
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
