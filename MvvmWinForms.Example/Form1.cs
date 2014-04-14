using MvvmForms;

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
            Binder.Text(TxtDate).OnTextChanged(vm => vm.Date);
            Binder.Text(TxtDate2).OnTextChanged(vm => vm.Date);
            Binder.Text(LblDate).OnTextChanged(vm => vm.Date);
            Binder.Checked(CbxEmpty).OnClick(vm => vm.Empty);

            Binder.ToViewModel(button1).OnClick(vm => vm.BtnClick());
        }
    }

    // necessary to work arround Visual Studio designer bug for forms with generic base classes
    public class ExampleBase : ViewBase<ExampleViewModel> { }
}
