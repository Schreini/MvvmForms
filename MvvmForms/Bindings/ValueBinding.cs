namespace MvvmForms.Bindings
{
    public class ValueBinding : ValueBindingBase
    {
        public ValueBinding(PropertyValue viewModelPropertyValue, PropertyValue controlPropertyValue) 
            : base(viewModelPropertyValue, controlPropertyValue)
        {
        }

        public override void Dispose()
        {
        }
    }

}
