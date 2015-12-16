using CodeBlueDev.Imp.WinForms.ViewModels;
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
    public partial class SelectProcessForm : Form
    {
        private BindingList<SelectProcessFormViewModel> _processBindingList;

        public SelectProcessForm()
        {
            _processBindingList = new BindingList<SelectProcessFormViewModel>();

            InitializeComponent();

            DataGridViewProcesses.DataSource = _processBindingList;
        }

        // TODO: have an event that can be tied to when a Process is selected.

        private void OnSelectProcessFormShown(object sender, EventArgs e)
        {
            _processBindingList.Clear();

            foreach (Process process in Process.GetProcesses())
            {
                // TODO: Convert to ViewModel and display to the user.
                _processBindingList.Add(new SelectProcessFormViewModel()
                {
                    Id = process.Id,
                });
            }
        }
    }
}
