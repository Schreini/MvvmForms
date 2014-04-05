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
            RegisterBinding(ViewModel, vm => vm.Date, TxtDate, t => t.Text);
            RegisterBinding(ViewModel, vm => vm.Date, TxtDate2, t => t.Text);
            RegisterBinding(ViewModel, vm => vm.Date, LblDate, l => l.Text);
            RegisterBinding(ViewModel, vm => vm.Empty, CbxEmpty, c => c.Checked);
            //ToDo EventBinding
            RegisterEventBinding(ViewModel, vm => vm.BtnClick(), button1);
            //RegisterEventBinding(ViewModel, vm => vm.BtnClick(button1, EventArgs.Empty), button1, c => c.Click);


            // oder in einer methode OnViewModelSet
            //binder.ForViewModel(ViewModel)
            //    .FromProperty(vm => vm.Date)
            //        .ToControl(TxtDate).Register(t => t.Text)
            //        .ToControl(TxtDate2).Register(t => t.Text)
            //        .ToControl(LblDate).Register(l => l.Text);
        }
    }
}
