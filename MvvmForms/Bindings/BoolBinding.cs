using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmForms.Bindings
{
    public class BoolBinding : ValueBinding<bool>
    {
        public BoolBinding(PropertyValue<bool> viewModelPropertyValue, PropertyValue<bool> controlPropertyValue) 
            : base(viewModelPropertyValue, controlPropertyValue)
        {
        }

        public override void Dispose()
        {
        }
    }
}
