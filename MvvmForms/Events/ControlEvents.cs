using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmForms.Events
{
    public class ControlEvents
    {
        internal protected ControlEvents(EventNames name)
        {
            Name = name.ToString();
        }

        public string Name { get; private set; }
    }
}
