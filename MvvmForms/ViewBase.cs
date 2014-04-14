using System;
using System.Windows.Forms;
using MvvmForms.Bindings;

namespace MvvmForms
{
    public partial class ViewBase<TViewModel> : Form where TViewModel : ViewModelBase
    {
        private Binder<TViewModel> Binder { get; set; }

        public ViewBase()
        {
            InitializeComponent();
        }

        //abstract
        protected virtual void InitializeBindings(Binder<TViewModel> binder)
        {
        }

        public void SetBinder(Binder<TViewModel> binder)
        {
            if(Binder!=null)
            {
                throw new Exception("Can set Binder only once.");
            }

            Binder = binder;

            InitializeBindings(Binder);
            Binder.DoBindings();
        }
    }
}