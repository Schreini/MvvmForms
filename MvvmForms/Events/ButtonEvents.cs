using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmForms.Events
{
    public class ButtonEvents
    {
        public readonly static ButtonEvents Click = new ButtonEvents(EventNames.Click);

        internal protected ButtonEvents (EventNames name)
        {
        }
    }
}
