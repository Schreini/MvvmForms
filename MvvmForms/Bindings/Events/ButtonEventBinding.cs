using System;
using System.Windows.Forms;
using MvvmForms.Events;

namespace MvvmForms.Bindings.Events
{
    class ButtonEventBinding<TViewModel>
    {
        public Button Button { get; private set; }
        public Action<TViewModel> EventListener { get; set; }
        public TViewModel ViewModel { get; set; }
        public ButtonEvents Event { get; private set; }

        public ButtonEventBinding(TViewModel viewModel, Button button, Action<TViewModel> eventListener, ButtonEvents ev)
        {
            ViewModel = viewModel;
            Event = ev;
            Button = button;
            EventListener = eventListener;

            if(ev == ButtonEvents.Click)
                Button.Click += Click;
        }

        void Click(object sender, EventArgs e)
        {
            EventListener(ViewModel);
        }

        public void Dispose()
        {
            if (Event == ButtonEvents.Click)
                Button.Click -= Click;
        }
    }
}
