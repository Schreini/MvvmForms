using System;
using System.Windows.Forms;
using MvvmForms.Bindings;

namespace MvvmWinForms.Example
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var vm = new ExampleViewModel();
            var b = new Binder<ExampleViewModel>(vm);
            var mainForm = new Form1();
            mainForm.SetBinder(b);

            Application.Run(mainForm);
        }
    }
}
