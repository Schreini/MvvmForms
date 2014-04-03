namespace MvvmForms.Bindings
{
    public class GenericBinding<TValue> : ValueBinding<TValue>
    {
        public GenericBinding(PropertyValue<TValue> viewModelPropertyValue, PropertyValue<TValue> controlPropertyValue) 
            : base(viewModelPropertyValue, controlPropertyValue)
        {
        }

        public override void Dispose()
        {
            //nothing to do (yet?)
        }
    }
}
