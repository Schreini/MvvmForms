using System;
using System.Windows.Forms;

namespace MvvmForms.Bindings
{
    class ButtonEventBinding<TViewModel> : EventBinding<TViewModel>
    {
        public Button Button { get; private set; }

        public ButtonEventBinding(TViewModel viewModel, Button button, Action<TViewModel> eventListener, ViewBase.EventEnum evEnum)
            : base(viewModel, eventListener)
        {
            Button = button;

            switch (evEnum)
            {
                case ViewBase.EventEnum.Click:
                    Button.Click += Click;
                    break;
            }
        }

        void Click(object sender, EventArgs e)
        {
            EventListener(ViewModel);
        }

        public override void Dispose()
        {
            Button.Click -= Click;
        }
    }
}
