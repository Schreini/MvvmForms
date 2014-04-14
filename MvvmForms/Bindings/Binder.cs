using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
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

        public ButtonClickBinding<TViewModel> ToViewModel(Button button)
        {
            var ei = button.GetType().GetEvent("Click");
            return new ButtonClickBinding<TViewModel>(_viewModel, new EventValue(ei, button));
        }
    }

    public class ButtonClickBinding <TViewModel>
    {
        private readonly TViewModel _viewModel;
        private readonly EventValue _eventValue;

        internal ButtonClickBinding(TViewModel viewModel, EventValue eventValue)
        {
            _viewModel = viewModel;
            _eventValue = eventValue;
        }

        public void OnClick(Action<TViewModel> clickHandler)
        {
            _eventValue.SetEventHandler(() => clickHandler(_viewModel));
        }
    }

    public class TextBinding<TViewModel, TValue>
    {
        private readonly Dictionary<string, List<ValueBindingBase>> _bindings;
        private readonly TViewModel _viewModel;
        private readonly PropertyValue _controlPropertyValue;
        private readonly Control _textControl;

        internal TextBinding(
            Dictionary<string, List<ValueBindingBase>> bindings,
            TViewModel viewModel,
            PropertyValue controlPropertyValue,
            Control textControl)
        {
            _bindings = bindings;
            _viewModel = viewModel;
            _controlPropertyValue = controlPropertyValue;
            _textControl = textControl;
        }

        public void OnTextChanged(Expression<Func<TViewModel, TValue>> to)
        {
            //do the binding
            var vmPv = new PropertyValue(_viewModel.GetPropertyInfoFromExpression(to), _viewModel);
            var vmPropertyName = vmPv.Info.Name;

            if (!_bindings.ContainsKey(vmPropertyName))
                _bindings.Add(vmPropertyName, new List<ValueBindingBase>());

            EventInfo eventInfo = _textControl.GetType().GetEvent("TextChanged");
            var ce = new EventValue(eventInfo, _textControl);

            var b = new TwoWayBinding(vmPv, _controlPropertyValue, ce);

            _bindings[vmPropertyName].Add(b);
        }
    }

    public class CheckedBinding<TViewModel, TValue>
    {
        private readonly Dictionary<string, List<ValueBindingBase>> _bindings;
        private readonly TViewModel _viewModel;
        private readonly PropertyValue _controlPropertyValue;
        private readonly Control _textControl;

        internal CheckedBinding(
            Dictionary<string, List<ValueBindingBase>> bindings,
            TViewModel viewModel,
            PropertyValue controlPropertyValue,
            Control textControl)
        {
            _bindings = bindings;
            _viewModel = viewModel;
            _controlPropertyValue = controlPropertyValue;
            _textControl = textControl;
        }

        public void OnClick(Expression<Func<TViewModel, TValue>> to)
        {
            //do the binding
            var vmPv = new PropertyValue(_viewModel.GetPropertyInfoFromExpression(to), _viewModel);
            var vmPropertyName = vmPv.Info.Name;

            if (!_bindings.ContainsKey(vmPropertyName))
                _bindings.Add(vmPropertyName, new List<ValueBindingBase>());

            EventInfo eventInfo = _textControl.GetType().GetEvent("Click");
            var ce = new EventValue(eventInfo, _textControl);

            var b = new TwoWayBinding(vmPv, _controlPropertyValue, ce);

            _bindings[vmPropertyName].Add(b);
        }
    }

}
