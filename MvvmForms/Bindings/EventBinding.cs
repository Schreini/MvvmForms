using System;

namespace MvvmForms.Bindings
{
    abstract class EventBinding<TViewModel> : IDisposable
    {
        public TViewModel ViewModel { get; private set; }
        public Action<TViewModel> EventListener { get; private set; }

        protected EventBinding(TViewModel viewModel, Action<TViewModel> eventListener)
        {
            ViewModel = viewModel;
            EventListener = eventListener;
        }

        public abstract void Dispose();
    }
}
