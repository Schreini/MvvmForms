using System.Collections.Generic;
using System.Windows.Forms;

namespace MvvmForms.Bindings
{
    public class Binder<TViewModel>
    {
        private readonly TViewModel _viewModel;
        public Dictionary<string, List<ValueBindingBase>> _bindings;

        public Binder(TViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public TextBinding<TViewModel, string> Text(Control textControl)
        {
            // TODO: Reflection current Method name Instead of Magic string?
            var pi = textControl.GetType().GetProperty("Text");
            return new TextBinding<TViewModel, string>(_bindings, _viewModel, new PropertyValue(pi, textControl), textControl);
        }

        public CheckedBinding<TViewModel, bool> Checked(CheckBox checkBox)
        {
            var pi = checkBox.GetType().GetProperty("Checked");
            return new CheckedBinding<TViewModel, bool>(
                _bindings, _viewModel, new PropertyValue(pi, checkBox), checkBox);
        }

        public ClickBinding<TViewModel> ToViewModel(Button button)
        {
            var ei = button.GetType().GetEvent("Click");
            return new ClickBinding<TViewModel>(_viewModel, new EventValue(ei, button));
        }
    }
}
