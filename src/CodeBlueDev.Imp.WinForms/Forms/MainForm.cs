using System;
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

            _selectedProcess = process;
            // Display values that should not change.
            LabelProcessIdValue.Text = _selectedProcess.Id.ToString();
            LabelProcessNameValue.Text = _selectedProcess.ProcessName;
            // TODO: Logic to do with the selected process.
            // Display values that could change.
            ShowProcessInfo();
            // TODO: Start the timer that will update the values that could change.
        }

        private void OnMainFormClosed(object sender, FormClosedEventArgs e)
        {
            // Cleanup. Is not necessary because of Application Exit but is proper.
            _processSelectorForm.Dispose();
            _selectedProcess = null;
        }

        private void ShowSelectProcessForm()
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
                    ShowSelectProcessForm();
                }
            }
        }

        private void ShowProcessInfo()
        {
            // TODO: Will need to bind to Size event to properly put the labels so they do not overlap.
            LabelNonPagedSystemMemoryValue.Text = _selectedProcess.NonpagedSystemMemorySize64.ToString();
            LabelPagedSystemMemoryValue.Text = _selectedProcess.PagedSystemMemorySize64.ToString();

            LabelPagedMemoryValue.Text = _selectedProcess.PagedMemorySize64.ToString();
            LabelPeakPagedMemoryValue.Text = _selectedProcess.PeakPagedMemorySize64.ToString();

            LabelVirtualMemoryValue.Text = _selectedProcess.VirtualMemorySize64.ToString();
            LabelPeakVirtualMemoryValue.Text = _selectedProcess.PeakVirtualMemorySize64.ToString();
            
            //_selectedProcess.PrivateMemorySize64
            //_selectedProcess.MainWindowTitle
        }
    }
}
