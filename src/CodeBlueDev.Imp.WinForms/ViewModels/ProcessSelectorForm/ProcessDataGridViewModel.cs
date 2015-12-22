// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessDataGridViewModel.cs" company="CodeBlueDev">
//   All rights reserved.
// </copyright>
// <summary>
//   The class used to display the properties of the Process in the DataGridView.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CodeBlueDev.Imp.WinForms.ViewModels.ProcessSelectorForm
{
    using System.ComponentModel;

    /// <summary>
    /// The class used to display the properties of the Process in the DataGridView.
    /// </summary>
    internal class ProcessDataGridViewModel
    {
        /// <summary>
        /// The Id of the Process.
        /// </summary>
        [DisplayName("PID")]
        public int Id { get; set; }

        /// <summary>
        /// The Name of the Process.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Window Title of the Process.
        /// </summary>
        public string Title { get; set; }
    }
}
