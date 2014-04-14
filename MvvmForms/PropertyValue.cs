using System.Reflection;

namespace MvvmForms
{
    public class PropertyValue
    {
        private object Target { get; set; }
        public PropertyInfo Info { get; private set; }

        public PropertyValue(PropertyInfo info, object o)
        {
            Info = info;
            Target = o;
        }

        public object Value
        {
            get { return Info.GetValue(Target, null); }
            set { Info.SetValue(Target, value, null); }
        }
    }
}
