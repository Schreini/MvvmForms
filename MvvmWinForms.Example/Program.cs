using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MvvmForms;
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
            var mainForm = new Form1();
            var exampleViewModel = new ExampleViewModel();
            mainForm.Binder = new Binder<ExampleViewModel>(exampleViewModel);
            mainForm.ViewModel = exampleViewModel;
            Application.Run(mainForm);
        }
    }
}
