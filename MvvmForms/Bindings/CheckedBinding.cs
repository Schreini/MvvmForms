using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace MvvmForms.Bindings
{
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

            var eventInfo = _textControl.GetType().GetEvent("Click");
            var ce = new EventValue(eventInfo, _textControl);

            var b = new TwoWayBinding(vmPv, _controlPropertyValue, ce);

            _bindings[vmPropertyName].Add(b);
        }
    }
}