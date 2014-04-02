using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace MvvmForms
{
    //TODO: HACK: TVAlue hier ist nur ein übler Quickfix
    public class MvvmForm<TValue> : Form
    {
        private readonly Dictionary<string, IList<ValueBinding<TValue>>> _bindings = new Dictionary<string, IList<ValueBinding<TValue>>>();

        //abstract
        protected virtual void InitializeBindings()
        {
        }

        /*
        protected void RegisterBinding<T>(Expression<Func<T>> source, TextBox destination)
        {
            var name = this.GetPropertyNameFromExpression(source);
            if(!_bindings.ContainsKey(name))
                _bindings.Add(name, new List<BindingBase>());

            _bindings[name].Add(new TextBoxBinding(this, this.GetPropertyInfo(name), destination));
        }
        */

        protected void RegisterBinding(
            /*object viewModel,*/ Expression<Func<TValue>> viewModelProperty,
            object control, Expression<Func<TValue>> controlProperty
            )
        {
            var vmPv = new PropertyValue<TValue>(this.GetPropertyInfoFromExpression(viewModelProperty), this);
            var ctrlPv = new PropertyValue<TValue>(control.GetPropertyInfoFromExpression(controlProperty), control);

            var vmPropertyName = this.GetPropertyNameFromExpression(viewModelProperty);
            if(!_bindings.ContainsKey(vmPropertyName))
                _bindings.Add(vmPropertyName, new List<ValueBinding<TValue>>());

            _bindings[vmPropertyName].Add(new ValueBinding<TValue>(vmPv, ctrlPv));
        }

        protected void DoBindings()
        {
            InitializeBindings();
            foreach (var binding in _bindings)
            {
                foreach (var b in binding.Value)
                {
                    b.SetInView();
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
            if(_bindings.ContainsKey(whichProperty))
                _bindings[whichProperty].ToList().ForEach(b => b.SetInView());
        }
    }
}
