using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MvvmForms.Bindings;

namespace MvvmForms
{
    public class ViewModelBase
    {
        internal Dictionary<string, List<ValueBindingBase>> Bindings { get; set; }

        public void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            var name = this.GetPropertyNameFromExpression(property);
            RaisePropertyChanged(name);
        }

        public void RaisePropertyChanged(string vmPropertyName)
        {
            var binding = Bindings[vmPropertyName];
            if (binding != null)
            {
                binding.ForEach(b => b.SetValueInControl());
            }
        }
    }
}
