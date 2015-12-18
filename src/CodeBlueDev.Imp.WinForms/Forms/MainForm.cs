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

            _processSelectorForm = new ProcessSelectorForm();
            _processSelectorForm.ProcessSelected += OnProcessSelect;
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
            if (InvokeRequired)
            {
                Invoke(new Action<Process>(OnProcessSelect), process);
                return;
            }

            // TODO: Logic to do with the selected process.
        }

        private void ShowSelectProcessForm()
        {
            // ProcessSelectorForm was closed or cancelled
            if (_processSelectorForm.ShowDialog() != DialogResult.OK)
            {
                // Check if the user has already selected a process.
                if(_selectedProcess != null)
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

        private void OnMainFormClosed(object sender, FormClosedEventArgs e)
        {
            // Cleanup. Is not necessary because of Application Exit but is proper.
            _processSelectorForm.Dispose();
            _selectedProcess = null;
        }
    }
}
