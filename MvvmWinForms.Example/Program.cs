using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MvvmForms;

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
            mainForm.ViewModel = new ExampleViewModel();
            Application.Run(mainForm);
        }
    }
}
