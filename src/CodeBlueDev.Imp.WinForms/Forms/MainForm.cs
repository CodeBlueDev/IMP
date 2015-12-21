using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CodeBlueDev.Imp.WinForms.Forms
{
    /// <summary>
    /// Creates an instance of the MainForm to display the contents of a Process.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The form used to select the Process.
        /// </summary>
        private readonly ProcessSelectorForm _processSelectorForm;

        /// <summary>
        /// The selected process.
        /// </summary>
        private Process _selectedProcess;

        /// <summary>
        /// The text displayed when the user does not select a process.
        /// </summary>
        private const string ProcessSelectorFormMessageBoxText = "Unable to run application without a process. Would you like to select a process?";

        /// <summary>
        /// The caption displayed when the user does not select a process.
        /// </summary>
        private const string ProcessSelectorFormMessageBoxCaption = "Must select a process";

        /// <summary>
        /// Shows details of the selected Process and allows operations on it.
        /// </summary>
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

        /// <summary>
        /// Shows the ProcessSelectorForm and determines whether or not the form should be
        /// redisplayed.
        /// </summary>
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
                    if (MessageBox.Show(
                        ProcessSelectorFormMessageBoxText, 
                        ProcessSelectorFormMessageBoxCaption, 
                        MessageBoxButtons.YesNo) == DialogResult.No)
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

        /// <summary>
        /// Show process window title and memory information.
        /// </summary>
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
