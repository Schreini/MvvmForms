using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Forms;
using MvvmForms.Bindings;

namespace MvvmForms
{
    public class MvvmForm<TViewModel> : Form where TViewModel : new()
    {
        private readonly Dictionary<string, List<ValueBindingBase>> _bindings = new Dictionary<string, List<ValueBindingBase>>();

        public TViewModel ViewModel { get; private set; }

        public MvvmForm()
        {
        }

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

            if (!_bindings.ContainsKey(vmPropertyName))
                _bindings.Add(vmPropertyName, new List<ValueBindingBase>());

            _bindings[vmPropertyName].Add(CreateBindingGeneric(vmPv, ctrlPv, control));
        }

        private ValueBindingBase CreateBindingGeneric<TControl>(
            PropertyValue vmPv, PropertyValue ctrlPv, TControl control)
            where TControl : Control
        {
            //if (typeof(TControl) == typeof(TextBoxBase) || typeof(TextBoxBase).IsAssignableFrom(typeof(TControl)))
            //    return new TextBoxBaseTextChangedBinding(vmPv, ctrlPv, control as TextBoxBase);

            return new ValueBinding(vmPv, ctrlPv);
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MvvmForm
            // 
            this.ClientSize = new System.Drawing.Size(528, 220);
            this.Name = "MvvmForm";
            this.ResumeLayout(false);

        }
    }
}
