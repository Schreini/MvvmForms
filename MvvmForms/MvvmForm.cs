using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace MvvmForms
{
    public class MvvmForm : Form
    {
        private readonly Dictionary<string, IList<ValueBinding<string>>> _stringBindings = new Dictionary<string, IList<ValueBinding<string>>>();

        //abstract
        protected virtual void InitializeBindings()
        {
        }

        /*
        protected void RegisterBinding<T>(Expression<Func<T>> source, TextBox destination)
        {
            var name = this.GetPropertyNameFromExpression(source);
            if(!_stringBindings.ContainsKey(name))
                _stringBindings.Add(name, new List<BindingBase>());

            _stringBindings[name].Add(new TextBoxBinding(this, this.GetPropertyInfo(name), destination));
        }
        */

        /*
        protected void RegisterBinding<TControl, TValue>(
            /*object viewModel,/ Expression<Func<TValue>> viewModelProperty,
            TControl control, Expression<Func<TControl, TValue>> controlProperty
            ) where TControl : Control
        {
            var vmPv = new PropertyValue<TValue>(this.GetPropertyInfoFromExpression(viewModelProperty), this);
            var ctrlPv = new PropertyValue<TValue>(control.GetPropertyInfoFromExpression(controlProperty), control);

            var vmPropertyName = this.GetPropertyNameFromExpression(viewModelProperty);
            if(!_stringBindings.ContainsKey(vmPropertyName))
                _stringBindings.Add(vmPropertyName, new List<ValueBinding<string>>());

            _stringBindings[vmPropertyName].Add(CreateBinding<TControl>(vmPv, ctrlPv, control));
        }

        private ValueBinding<TValue> CreateBinding<TControl, TValue>(
            PropertyValue<TValue> vmPv, PropertyValue<TValue> ctrlPv, TControl control)
            where TControl : Control
        {
            if (typeof(TControl) == typeof(TextBox))
                return new TextBoxTextChangedBinding<TValue>(vmPv, ctrlPv, control as TextBox);

            return new ValueBinding<TValue>(vmPv, ctrlPv);
        }
        */

        #region string specific stuff

        protected void RegisterStringBinding<TControl>(
            /*object viewModel,*/ Expression<Func<string>> viewModelProperty,
            TControl control, Expression<Func<TControl, string>> controlProperty
            ) where TControl : Control
        {
            var vmPv = new PropertyValue<string>(this.GetPropertyInfoFromExpression(viewModelProperty), this);
            var ctrlPv = new PropertyValue<string>(control.GetPropertyInfoFromExpression(controlProperty), control);

            var vmPropertyName = this.GetPropertyNameFromExpression(viewModelProperty);
            if (!_stringBindings.ContainsKey(vmPropertyName))
                _stringBindings.Add(vmPropertyName, new List<ValueBinding<string>>());

            _stringBindings[vmPropertyName].Add(CreateBinding(vmPv, ctrlPv, control));
        }

        private ValueBinding<string> CreateBinding<TControl>(
            PropertyValue<string> vmPv, PropertyValue<string> ctrlPv, TControl control)
            where TControl : Control
        {
            if (typeof(TControl) == typeof(TextBox))
                return new TextBoxTextChangedBinding<string>(vmPv, ctrlPv, control as TextBox);

            return new ValueBinding<string>(vmPv, ctrlPv);
        }

        #endregion

        protected void DoBindings()
        {
            InitializeBindings();
            foreach (var binding in _stringBindings)
            {
                foreach (var b in binding.Value)
                {
                    b.SetValueInControl();
                }
            }
        }

        public void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            var name = this.GetPropertyNameFromExpression(property);
            RaisePropertyChanged(name);
        }

        public void RaisePropertyChanged(string whichProperty)
        {
            if(_stringBindings.ContainsKey(whichProperty))
                _stringBindings[whichProperty].ToList().ForEach(b => b.SetValueInControl());
        }
    }
}
