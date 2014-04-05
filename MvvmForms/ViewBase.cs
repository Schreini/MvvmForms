using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;
using MvvmForms.Bindings;

namespace MvvmForms
{
    public partial class ViewBase : Form
    {
        internal readonly Dictionary<string, List<ValueBindingBase>> _bindings = new Dictionary<string, List<ValueBindingBase>>();

        private ViewModelBase _viewModel;
        public ViewModelBase ViewModel
        {
            get { return _viewModel; }
            set { _viewModel = value;
                _viewModel.Bindings = _bindings;
                DoBindings();
            }
        }

        public ViewBase()
        {
            InitializeComponent();
        }

        protected void DoBindings()
        {
            InitializeBindings();
            foreach (var binding in _bindings.Values)
            {
                foreach (var x in binding)
                    x.SetValueInControl();
            }
        }

        //abstract
        protected virtual void InitializeBindings()
        {
        }

        protected void AddValueBinding<TViewModel, TControl, TValue>(
            TViewModel viewModel, Expression<Func<TViewModel, TValue>> viewModelProperty,
            TControl control, Expression<Func<TControl, TValue>> controlProperty
            ) where TControl : Control
        {
            var vmPv = new PropertyValue(viewModel.GetPropertyInfoFromExpression(viewModelProperty), viewModel);
            var ctrlPv = new PropertyValue(control.GetPropertyInfoFromExpression(controlProperty), control);

            var vmPropertyName = viewModel.GetPropertyNameFromExpression(viewModelProperty);

            if (!_bindings.ContainsKey(vmPropertyName))
                _bindings.Add(vmPropertyName, new List<ValueBindingBase>());

            _bindings[vmPropertyName].Add(CreateBindingGeneric(vmPv, ctrlPv, control));
        }

        //TODO: hier ist wohl eine Methode pro Control notwendig, damit wir eine Control-Spezifische enum verwenden können
        protected void AddEventBinding<TViewModel, TControl>(
            TViewModel viewModel, Action<TViewModel> vmEvent,
            TControl control, EventEnum evEnum ) 
            where TControl : Control
        {
            if(typeof(TControl) == typeof(Button))
                new ButtonEventBinding<TViewModel>(viewModel, control as Button, vmEvent, evEnum);
        }

        private ValueBindingBase CreateBindingGeneric<TControl>(
            PropertyValue vmPv, PropertyValue ctrlPv, TControl control)
            where TControl : Control
        {
            if (typeof(TControl) == typeof(TextBoxBase) || typeof(TextBoxBase).IsAssignableFrom(typeof(TControl)))
                return new TextBoxBaseTextChangedBinding(vmPv, ctrlPv, control as TextBoxBase);

            return new ValueBinding(vmPv, ctrlPv);
        }

        public enum EventEnum {Click}
    }
}