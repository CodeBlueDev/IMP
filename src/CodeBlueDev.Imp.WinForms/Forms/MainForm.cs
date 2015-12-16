using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeBlueDev.Imp.WinForms.Forms
{
    public partial class MainForm : Form
    {
        private readonly SelectProcessForm _selectProcessForm;

        private Process _selectedProcess;

        public MainForm()
        {
            _selectProcessForm = new SelectProcessForm();

            InitializeComponent();
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            // Do not show the form until a process has been selected.
            Hide();
            // Show the form to select a process from.
            ShowSelectProcessForm();
        }

        private void ShowSelectProcessForm()
        {
            // SelectProcessForm was closed or cancelled
            if (_selectProcessForm.ShowDialog() != DialogResult.OK)
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
            _selectProcessForm.Dispose();
            _selectedProcess = null;
        }
    }
}
