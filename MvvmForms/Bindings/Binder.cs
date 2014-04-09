using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public TextBinding<TViewModel, string> Text(TextBoxBase textControl)
        {
            // TODO: Reflection current Method name Instead of Magic string?
            var pi = textControl.GetType().GetProperty("Text");
            return new TextBinding<TViewModel, string>(_bindings, _viewModel, new PropertyValue(pi, textControl), textControl);
        }
    }

    public class TextBinding<TViewModel, TValue>
    {
        private readonly Dictionary<string, List<ValueBindingBase>> _bindings;
        private readonly TViewModel _viewModel;
        private readonly PropertyValue _controlPropertyValue;
        private readonly TextBoxBase _textControl;

        internal TextBinding(
            Dictionary<string, List<ValueBindingBase>> bindings, 
            TViewModel viewModel, 
            PropertyValue controlPropertyValue, 
            TextBoxBase textControl)
        {
            _bindings = bindings;
            _viewModel = viewModel;
            _controlPropertyValue = controlPropertyValue;
            _textControl = textControl;
        }

        public void To(Expression<Func<TViewModel, TValue>> to)
        {
            //do the binding
            var vmPv = new PropertyValue(_viewModel.GetPropertyInfoFromExpression(to), _viewModel);

            var vmPropertyName = _controlPropertyValue.Info.Name;

            if (!_bindings.ContainsKey(vmPropertyName))
                _bindings.Add(vmPropertyName, new List<ValueBindingBase>());

            var b = new TextBoxBaseTextChangedBinding(vmPv, _controlPropertyValue, _textControl);

            _bindings[vmPropertyName].Add(b);
        }
    }
}
