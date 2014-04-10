using System;
using MvvmForms;
using MvvmForms.Bindings;
using MvvmForms.Events;

namespace MvvmWinForms.Example
{
    public partial class Form1 : ExampleBase
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void InitializeBindings()
        {
            //AddValueBinding(ViewModel, vm => vm.Date, TxtDate, t => t.Text);
            //AddValueBinding(ViewModel, vm => vm.Date, TxtDate2, t => t.Text);
            Binder.Text(TxtDate).OnTextChanged(vm => vm.Date);
            Binder.Text(TxtDate2).OnTextChanged(vm => vm.Date);
            Binder.Text(LblDate).OnTextChanged(vm => vm.Date);

            AddValueBinding(ViewModel, vm => vm.Empty, CbxEmpty, c => c.Checked);

            AddEventBinding(ViewModel, vm => vm.BtnClick(), button1, ButtonEvents.Click);
            AddEventBinding(ViewModel, vm => vm.EmptyClick(), CbxEmpty, CheckBoxEvents.Click);
        }
    }

    // necessary to work arround Visual Studio designer bug for forms with generic base classes
    public class ExampleBase : ViewBase<ExampleViewModel> { }
}
