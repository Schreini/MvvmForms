using MvvmForms;
using MvvmForms.Bindings;

namespace MvvmWinForms.Example
{
    public partial class Form1 : ExampleBase
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void InitializeBindings(Binder<ExampleViewModel> binder)
        {
            binder.Text(TxtDate).OnTextChanged(vm => vm.Date);
            binder.Text(TxtDate2).OnTextChanged(vm => vm.Date);
            binder.Text(LblDate).OnTextChanged(vm => vm.Date);
            binder.Checked(CbxEmpty).OnClick(vm => vm.Empty);

            binder.ToViewModel(button1).OnClick(vm => vm.BtnClick());
        }
    }

    // necessary to work around Visual Studio designer bug for forms with generic base classes
    public class ExampleBase : ViewBase<ExampleViewModel>
    {
    }
}
