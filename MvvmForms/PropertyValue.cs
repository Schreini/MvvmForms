using System.Reflection;

namespace MvvmForms
{
    public class PropertyValue<TValue>
    {
        private readonly PropertyInfo _info;
        private readonly object _o;

        public PropertyValue(PropertyInfo info, object o)
        {
            _info = info;
            _o = o;
        }

        public TValue Value
        {
            get { return (TValue)_info.GetValue(_o, null); }
            set { _info.SetValue(_o, value, null); }
        }
    }

    public class PropertyValue
    {
        private readonly PropertyInfo _info;
        private readonly object _o;

        public PropertyValue(PropertyInfo info, object o)
        {
            _info = info;
            _o = o;
        }

        public object Value
        {
            get { return _info.GetValue(_o, null); }
            set { _info.SetValue(_o, value, null); }
        }
    }
}
