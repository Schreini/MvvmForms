using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;
using MvvmForms.Bindings;

namespace MvvmForms
{
    public class MvvmForm : Form
    {
        private readonly Dictionary<Type, List<Bndng>> _bindings = new Dictionary<Type, List<Bndng>>();

        //abstract
        protected virtual void InitializeBindings()
        {
        }

        protected void RegisterBinding<TControl, TValue>(
            /*object viewModel,*/ Expression<Func<TValue>> viewModelProperty,
            TControl control, Expression<Func<TControl, TValue>> controlProperty
            ) where TControl : Control
        {
            var vmPv = new PropertyValue(this.GetPropertyInfoFromExpression(viewModelProperty), this);
            var ctrlPv = new PropertyValue(control.GetPropertyInfoFromExpression(controlProperty), control);

            var vmPropertyName = this.GetPropertyNameFromExpression(viewModelProperty);
            if (!_bindings.ContainsKey(typeof(TValue)))
                _bindings.Add(typeof(TValue), new List<Bndng>());

            Bndng bndng = _bindings[typeof(TValue)].Where(b => b.VmPropertyName == vmPropertyName).SingleOrDefault();
            if(bndng==null)
            {
                bndng = new Bndng(vmPropertyName);
                _bindings[typeof(TValue)].Add(bndng);
            }
            bndng.ValueBindings.Add(CreateBindingGeneric(vmPv, ctrlPv, control));
        }

        private ValueBindingBase CreateBindingGeneric<TControl>(
            PropertyValue vmPv, PropertyValue ctrlPv, TControl control)
            where TControl : Control
        {
            if (typeof(TControl) == typeof(TextBoxBase) || typeof(TextBoxBase).IsAssignableFrom(typeof(TControl)))
                return new TextBoxBaseTextChangedBinding(vmPv, ctrlPv, control as TextBoxBase);

            return new ValueBinding(vmPv, ctrlPv);
        }

        protected void DoBindings()
        {
            InitializeBindings();
            foreach (var binding in _bindings)
            {
                foreach (var b in binding.Value)
                {
                    foreach(var x in b.ValueBindings)
                        x.SetValueInControl();
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
            PropertyInfo pi = GetType().GetProperty(whichProperty);
            if (!_bindings.ContainsKey(pi.PropertyType))
                return;

            var binding = _bindings[pi.PropertyType].Where(b => b.VmPropertyName == whichProperty).SingleOrDefault();
            if(binding != null)
            {
                binding.ValueBindings.ToList().ForEach(b => b.SetValueInControl());
            }
        }
    }

    public class Bndng
    {
        public string VmPropertyName { get; private set; }
        public IList<ValueBindingBase> ValueBindings { get; private set; }

        public Bndng(string vmPropertyName)
        {
            VmPropertyName = vmPropertyName;
            ValueBindings = new List<ValueBindingBase>();
        }
    }
}
