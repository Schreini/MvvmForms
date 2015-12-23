using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MvvmForms.Bindings;

namespace MvvmForms
{
    public class ViewModelBase
    {
        internal Binder Binder { get; set; }
//        internal Dictionary<string, List<ValueBindingBase>> Bindings { get; set; }

        public void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            var name = this.GetPropertyNameFromExpression(property);
            RaisePropertyChanged(name);
        }

        public void RaisePropertyChanged(string vmPropertyName)
        {
            // if there is a RaisePropertyChanged call in the Constructor of a ViewModel
            // Binder will be null.
            if(Binder != null)
                Binder.RaisePropertyChanged(vmPropertyName);
        }
    }
}
