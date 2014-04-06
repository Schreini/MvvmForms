namespace MvvmForms.Events
{
    public class CheckBoxEvents
    {
        public readonly static CheckBoxEvents Click = new CheckBoxEvents(EventNames.Click);

        internal protected CheckBoxEvents(EventNames name)
        {
        }
    }
}
