using System.Collections.Generic;
using System.Windows.Forms;

namespace MvvmForms.Bindings
{
    public class Binder
    {
        private readonly Dictionary<string, List<ValueBindingBase>> _bindings = new Dictionary<string, List<ValueBindingBase>>();

        protected Dictionary<string, List<ValueBindingBase>> Bindings
        {
            get { return _bindings; }
        }

        public void RaisePropertyChanged(string vmPropertyName)
        {
            var binding = Bindings[vmPropertyName];
            if (binding != null)
            {
                binding.ForEach(b => b.SetValueInControl());
            }
        }

        internal void DoBindings()
        {
            foreach (var binding in Bindings.Values)
            {
                foreach (var x in binding)
                    x.SetValueInControl();
            }
        }
    }

    public class Binder<TViewModel> : Binder where TViewModel : ViewModelBase
    {
        private readonly TViewModel _viewModel;

        public Binder(TViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.Binder = this;
        }

        public TextBinding<TViewModel, string> Text(Control textControl)
        {
            // TODO: Reflection current Method name Instead of Magic string?
            var pi = textControl.GetType().GetProperty("Text");
            return new TextBinding<TViewModel, string>(Bindings, _viewModel, new PropertyValue(pi, textControl), textControl);
        }

        public CheckedBinding<TViewModel, bool> Checked(CheckBox checkBox)
        {
            var pi = checkBox.GetType().GetProperty("Checked");
            return new CheckedBinding<TViewModel, bool>(
                Bindings, _viewModel, new PropertyValue(pi, checkBox), checkBox);
        }

        public ClickBinding<TViewModel> ToViewModel(Button button)
        {
            var ei = button.GetType().GetEvent("Click");
            return new ClickBinding<TViewModel>(_viewModel, new EventValue(ei, button));
        }
    }
}
