namespace MvvmForms.Bindings
{
    public class TwoWayBinding : ValueBindingBase
    {
        private EventValue BoundEvent { get; set; }

        public TwoWayBinding(PropertyValue viewModelPropertyValue, PropertyValue controlPropertyValue, EventValue boundEvent)
            : base(viewModelPropertyValue, controlPropertyValue)
        {
            BoundEvent = boundEvent;
            BoundEvent.SetEventHandler(SetValueInViewModel);
        }

        public override void Dispose()
        {
            BoundEvent.RemoveEventHandler();
        }
    }
}
