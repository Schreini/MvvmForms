using System;
using System.Windows.Forms;

namespace MvvmForms.Bindings
{
    public class EventBinding<TControl, TViewModel> : IDisposable
        where TControl : Control
    {
        public TViewModel ViewModel { get; set; }
        public Action<TViewModel> EventListener { get; set; }
        Button b;

        public EventBinding(TViewModel viewModel, TControl control, Action<TViewModel> eventListener)
        {
            ViewModel = viewModel;
            EventListener = eventListener;

            b = control as Button;

            if (b == null)
                return;

            b.Click += Click;
        }

        void Click(object sender, EventArgs e)
        {
            EventListener(ViewModel);
        }

        public void Dispose()
        {
            b.Click += Click;
        }
    }
}
