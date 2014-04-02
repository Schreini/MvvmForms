namespace MvvmForms
{
    public class ValueBinding<TValue>
    {
        public PropertyValue<TValue> ViewModelPropertyValue { get; set; }
        public PropertyValue<TValue> ControlPropertyValue { get; set; }

        public ValueBinding(PropertyValue<TValue> viewModelPropertyValue, PropertyValue<TValue> controlPropertyValue)
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
    }
}
