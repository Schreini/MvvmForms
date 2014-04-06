using System;
using System.Windows.Forms;
using MvvmForms.Events;

namespace MvvmForms.Bindings.Events
{
    class ControlEventBinding<TViewModel> : EventBinding<TViewModel>
    {
        public ControlEventBinding(TViewModel viewModel, Control control, Action<TViewModel> eventListener, ControlEvents ev) 
            : base(viewModel, eventListener)
        {
        }

        public override void Dispose()
        {
            //TODO: dispose implementieren
        }
    }
}
