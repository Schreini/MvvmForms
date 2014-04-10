using System;
using System.Reflection;

namespace MvvmForms
{
    public class EventValue
    {
        public object Target { get; private set; }
        public EventInfo Info { get; private set; }
        private EventHandler _handler;
        private Action _handlerAction;

        public EventValue(EventInfo info, object o)
        {
            Info = info;
            Target = o;
        }

        public void SetEventHandler(Action handler)
        {
            if(_handler != null)
                throw new Exception("Handler already set");

            _handlerAction = handler;
            _handler = new EventHandler(HandleEvent);

            Info.AddEventHandler(Target, _handler);
        }

        public void RemoveEventHandler()
        {
            Info.RemoveEventHandler(Target, _handler);
            _handler = null;
        }

        private void HandleEvent(object sender, EventArgs e)
        {
            _handlerAction();
        }
    }
}
