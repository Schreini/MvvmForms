using System.Reflection;

namespace MvvmForms
{
    public class PropertyValue
    {
        private readonly object _o;

        public PropertyInfo Info { get; private set; }

        public PropertyValue(PropertyInfo info, object o)
        {
            Info = info;
            _o = o;
        }

        public object Value
        {
            get { return Info.GetValue(_o, null); }
            set { Info.SetValue(_o, value, null); }
        }

    }
}
