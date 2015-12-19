﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CodeBlueDev.Imp.WinForms.Forms
{
    public partial class MainForm : Form
    {
        private readonly ProcessSelectorForm _processSelectorForm;

        private Process _selectedProcess;

        public MainForm()
        {
            InitializeComponent();
            // Initialize the form that will allow the user to select a Process.
            _processSelectorForm = new ProcessSelectorForm();
            _processSelectorForm.ProcessSelect += OnProcessSelect;
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            // Do not show the form until a process has been selected.
            Hide();
            // Show the form to select a process from.
            ShowSelectProcessForm();
        }

        private void OnProcessSelect(Process process)
        {
            // If the Process was selected on a separate thread, invoke the 
            // OnProcessSelect method on the originating thread.
            if (InvokeRequired)
            {
                Invoke(new Action<Process>(OnProcessSelect), process);
                return;
            }
            // Save the Selected Process.
            _selectedProcess = process;
            // Display values that should not change.
            LabelProcessIdValue.Text = _selectedProcess.Id.ToString();
            LabelProcessNameValue.Text = _selectedProcess.ProcessName;
            // TODO: Figure out if process is 64 bit process and display to user.
            // TODO: Display the owner if we are able to retrieve it.
            // Display values that could change.
            ShowProcessInfo();
            // TODO: Logic to do with the selected process modules.
            // TODO: Start the timer that will update the values that could change.
        }

        private void OnMainFormClosed(object sender, FormClosedEventArgs e)
        {
            // Cleanup.
            _processSelectorForm.Dispose();
            _selectedProcess = null;
            // TODO: Dispose of timer.
        }

        private void OnSelectProcessToolStripMenuItemClick(object sender, EventArgs e)
        {
            ShowSelectProcessForm();
        }

        private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        private void OnUpdateWindowTitleButtonClick(object sender, EventArgs e)
        {
            // TODO:
        }

        private void ShowSelectProcessForm()
        {
            while (true)
            {
                // ProcessSelectorForm was closed or cancelled
                if (_processSelectorForm.ShowDialog() != DialogResult.OK)
                {
                    // Check if the user has already selected a process.
                    if (_selectedProcess != null)
                    {
                        return;
                    }
                    // Check if the user wants to exit. 
                    if (MessageBox.Show("", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Close();
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

        private void ShowProcessInfo()
        {
            // TODO: Will need to bind to Size event to properly put the labels so they do not overlap.
            LabelWindowTitleValue.Text = _selectedProcess.MainWindowTitle;

            LabelNonPagedSystemMemoryValue.Text = _selectedProcess.NonpagedSystemMemorySize64.ToString();
            LabelPagedSystemMemoryValue.Text = _selectedProcess.PagedSystemMemorySize64.ToString();

            LabelPagedMemoryValue.Text = _selectedProcess.PagedMemorySize64.ToString();
            LabelPeakPagedMemoryValue.Text = _selectedProcess.PeakPagedMemorySize64.ToString();

            LabelVirtualMemoryValue.Text = _selectedProcess.VirtualMemorySize64.ToString();
            LabelPeakVirtualMemoryValue.Text = _selectedProcess.PeakVirtualMemorySize64.ToString();

            LabelPrivateMemoryValue.Text = _selectedProcess.PrivateMemorySize64.ToString();
        }
    }
}
