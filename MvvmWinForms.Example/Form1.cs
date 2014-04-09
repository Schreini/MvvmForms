using MvvmForms;
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
            AddValueBinding(ViewModel, vm => vm.Date, TxtDate, t => t.Text);
            AddValueBinding(ViewModel, vm => vm.Date, TxtDate2, t => t.Text);
            AddValueBinding(ViewModel, vm => vm.Date, LblDate, l => l.Text);
            AddValueBinding(ViewModel, vm => vm.Empty, CbxEmpty, c => c.Checked);

            AddEventBinding(ViewModel, vm => vm.BtnClick(), button1, ButtonEvents.Click);
            AddEventBinding(ViewModel, vm => vm.EmptyClick(), CbxEmpty, CheckBoxEvents.Click);
        }
    }

    public class ExampleBase : ViewBase<ExampleViewModel> { }
}
