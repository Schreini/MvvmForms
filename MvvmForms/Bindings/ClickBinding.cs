using System;

namespace MvvmForms.Bindings
{
    public class ClickBinding <TViewModel>
    {
        private readonly TViewModel _viewModel;
        private readonly EventValue _eventValue;

        internal ClickBinding(TViewModel viewModel, EventValue eventValue)
        {
            _viewModel = viewModel;
            _eventValue = eventValue;
        }

        public void OnClick(Action<TViewModel> clickHandler)
        {
            _eventValue.SetEventHandler(() => clickHandler(_viewModel));
        }
    }
}