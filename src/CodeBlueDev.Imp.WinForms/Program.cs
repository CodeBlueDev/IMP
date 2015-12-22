// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="CodeBlueDev">
//   All rights reserved.
// </copyright>
// <summary>
//   The entry-point for the program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CodeBlueDev.Imp.WinForms
{
    using System;
    using System.Windows.Forms;

    using Forms;

    /// <summary>
    /// The entry-point for the program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <exception cref="Exception">An error occurred in the data source and either there is no handler for the <see cref="E:System.Windows.Forms.DataGridView.DataError" /> event or the handler has set the <see cref="P:System.Windows.Forms.DataGridViewDataErrorEventArgs.ThrowException" /> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException" />.</exception>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
