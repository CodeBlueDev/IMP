using System.ComponentModel;

namespace CodeBlueDev.Imp.WinForms.ViewModels
{
    internal class SelectProcessFormViewModel
    {
        [DisplayName("PID")]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }
    }
}
