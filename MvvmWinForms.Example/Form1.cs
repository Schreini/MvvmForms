using System;
using MvvmForms;

namespace MvvmWinForms.Example
{
    public partial class Form1 : ViewBase
    {
        // necessary to work arround Visual Studio designer bug for forms with generic base classes
        public new ExampleViewModel ViewModel { 
            get { return (ExampleViewModel)base.ViewModel; } 
            set { base.ViewModel = value; } 
        }

        public Form1()
        {
            InitializeComponent();
        }

        protected override void InitializeBindings()
        {
            AddValueBinding(ViewModel, vm => vm.Date, TxtDate, t => t.Text);
            AddValueBinding(ViewModel, vm => vm.Date, TxtDate2, t => t.Text);
            AddValueBinding(ViewModel, vm => vm.Date, LblDate, l => l.Text);
            AddValueBinding(ViewModel, vm => vm.Empty, CbxEmpty, c => c.Checked);

            AddEventBinding(ViewModel, vm => vm.BtnClick(), button1);
        }
    }
}
