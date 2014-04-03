using System;

namespace MvvmForms.Bindings
{
    public abstract class ValueBindingBase : IDisposable
    {
        public PropertyValue ViewModelPropertyValue { get; set; }
        public PropertyValue ControlPropertyValue { get; set; }

        public ValueBindingBase(PropertyValue viewModelPropertyValue, PropertyValue controlPropertyValue)
        {
            ViewModelPropertyValue = viewModelPropertyValue;
            ControlPropertyValue = controlPropertyValue;
        }

        public void SetValueInViewModel()
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