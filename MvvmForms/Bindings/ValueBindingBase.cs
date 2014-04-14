using System;

namespace MvvmForms.Bindings
{
    public abstract class ValueBindingBase : IDisposable
    {
        private PropertyValue ViewModelPropertyValue { get; set; }
        private PropertyValue ControlPropertyValue { get; set; }

        protected ValueBindingBase(PropertyValue viewModelPropertyValue, PropertyValue controlPropertyValue)
        {
            ViewModelPropertyValue = viewModelPropertyValue;
            ControlPropertyValue = controlPropertyValue;
        }

        protected void SetValueInViewModel()
        {
            ViewModelPropertyValue.Value = ControlPropertyValue.Value;
        }

        public void SetValueInControl()
        {
            ControlPropertyValue.Value = ViewModelPropertyValue.Value;
        }

        public abstract void Dispose();
    }
}