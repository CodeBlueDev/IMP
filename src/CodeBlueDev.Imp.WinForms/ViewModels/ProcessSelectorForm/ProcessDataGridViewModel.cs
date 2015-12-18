using System.ComponentModel;

namespace CodeBlueDev.Imp.WinForms.ViewModels.ProcessSelectorForm
{
    internal class ProcessDataGridViewModel
    {
        [DisplayName("PID")]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }
    }
}
