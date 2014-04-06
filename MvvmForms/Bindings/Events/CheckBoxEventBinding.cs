using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MvvmForms.Events;

namespace MvvmForms.Bindings.Events
{
    namespace MvvmForms.Bindings.Events
    {
        class CheckBoxEventBinding<TViewModel>
        {
            public CheckBox CheckBox { get; private set; }
            public Action<TViewModel> EventListener { get; set; }
            public TViewModel ViewModel { get; set; }
            public CheckBoxEvents Event { get; private set; }

            public CheckBoxEventBinding(TViewModel viewModel, CheckBox checkBox, Action<TViewModel> eventListener, CheckBoxEvents ev)
            {
                ViewModel = viewModel;
                Event = ev;
                CheckBox = checkBox;
                EventListener = eventListener;

                if (ev == CheckBoxEvents.Click)
                    CheckBox.Click += Click;
            }

            void Click(object sender, EventArgs e)
            {
                EventListener(ViewModel);
            }

            public void Dispose()
            {
                if (Event == CheckBoxEvents.Click)
                    CheckBox.Click -= Click;
            }
        }
    }
}
