using System.Collections.Generic;
using System.Windows.Forms;
using MvvmForms.Bindings;

namespace MvvmForms
{
    public partial class ViewBase<TViewModel> : Form where TViewModel : ViewModelBase
    {
        private readonly Dictionary<string, List<ValueBindingBase>> _bindings = new Dictionary<string, List<ValueBindingBase>>();

        private TViewModel _viewModel;
        public TViewModel ViewModel
        {
            get { return _viewModel; }
            set { _viewModel = value;
                _viewModel.Bindings = _bindings;
                DoBindings();
            }
        }

        private Binder<TViewModel> _binder;
        public Binder<TViewModel> Binder
        {
            get { return _binder; }
            set { _binder = value;
                _binder._bindings = _bindings;
            }
        }

        public ViewBase()
        {
            InitializeComponent();
        }

        protected void DoBindings()
        {
            InitializeBindings();
            foreach (var binding in _bindings.Values)
            {
                foreach (var x in binding)
                    x.SetValueInControl();
            }
        }

        //abstract
        protected virtual void InitializeBindings()
        {
        }
    }
}