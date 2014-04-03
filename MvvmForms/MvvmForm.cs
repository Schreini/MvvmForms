using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using MvvmForms.Bindings;

namespace MvvmForms
{
    public class MvvmForm : Form
    {
        private readonly Dictionary<string, IList<ValueBinding<string>>> _stringBindings = new Dictionary<string, IList<ValueBinding<string>>>();
        private readonly Dictionary<Type, List<Bndng>> _bindings = new Dictionary<Type, List<Bndng>>();

        //abstract
        protected virtual void InitializeBindings()
        {
        }

        #region string specific stuff

        protected void RegisterBoolBinding<TControl>(
            /*object viewModel,*/ Expression<Func<bool>> viewModelProperty,
            TControl control, Expression<Func<TControl, bool>> controlProperty
            ) where TControl : Control
        {
            var vmPv = new PropertyValue(this.GetPropertyInfoFromExpression(viewModelProperty), this);
            var ctrlPv = new PropertyValue(control.GetPropertyInfoFromExpression(controlProperty), control);

            var vmPropertyName = this.GetPropertyNameFromExpression(viewModelProperty);
            if (!_bindings.ContainsKey(typeof(bool)))
                _bindings.Add(typeof(bool), new List<Bndng>());

            Bndng bndng = _bindings[typeof (bool)].Where(b => b.VmPropertyName == vmPropertyName).SingleOrDefault();
            if(bndng==null)
            {
                bndng = new Bndng(vmPropertyName);
                _bindings[typeof(bool)].Add(bndng);
            }
            bndng.ValueBindings.Add(CreateBindingGeneric(vmPv, ctrlPv, control));
            //Add(CreateBinding(vmPv, ctrlPv, control));
        }

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
            if (typeof(TControl) == typeof(TextBoxBase) || typeof(TextBoxBase).IsAssignableFrom(typeof(TControl)))
                return new TextBoxBaseTextChangedBinding(vmPv, ctrlPv, control as TextBoxBase);

            return new GenericBinding<string>(vmPv, ctrlPv);
        }

        private ValueBinding CreateBindingGeneric<TControl>(
            PropertyValue vmPv, PropertyValue ctrlPv, TControl control)
            where TControl : Control
        {
            //if (typeof(TControl) == typeof(TextBoxBase) || typeof(TextBoxBase).IsAssignableFrom(typeof(TControl)))
            //    return new TextBoxBaseTextChangedBinding(vmPv, ctrlPv, control as TextBoxBase);

            return new ValueBinding(vmPv, ctrlPv);
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

            var binding = _bindings[typeof (bool)].Where(b => b.VmPropertyName == whichProperty).SingleOrDefault();
            if(binding != null)
            {
                binding.ValueBindings.ToList().ForEach(b => b.SetValueInControl());
            }
        }
    }

    public class Bndng
    {
        public string VmPropertyName { get; private set; }
        public IList<ValueBinding> ValueBindings { get; private set; }

        public Bndng(string vmPropertyName)
        {
            VmPropertyName = vmPropertyName;
            ValueBindings = new List<ValueBinding>();
        }
    }
}
