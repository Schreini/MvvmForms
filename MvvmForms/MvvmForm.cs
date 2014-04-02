using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace MvvmForms
{
    public class MvvmForm : Form
    {
        private readonly Dictionary<string, IList<BindingBase>> _bindings = new Dictionary<string, IList<BindingBase>>();

        //abstract
        protected virtual void InitializeBindings()
        {
        }

        protected void RegisterBinding<T>(Expression<Func<T>> source, TextBox destination)
        {
            var name = this.GetPropertyNameFromExpression(source);
            if(!_bindings.ContainsKey(name))
                _bindings.Add(name, new List<BindingBase>());

            _bindings[name].Add(new TextBoxBinding(this, GetPropertyInfo(name), destination));
        }

        protected void DoBindings()
        {
            InitializeBindings();
            foreach (var binding in _bindings)
            {
                foreach (var b in binding.Value)
                {
                    b.SetInView();
                }
            }
        }

        public void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            var name = this.GetPropertyNameFromExpression(property);
            RaisePropertyChanged(name);
        }

        public void RaisePropertyChanged(string whichProperty)
        {
            if(_bindings.ContainsKey(whichProperty))
                _bindings[whichProperty].ToList().ForEach(b => b.SetInView());
        }

        private PropertyInfo GetPropertyInfo(string whichProperty)
        {
            return GetType().GetProperties().Where(p => p.Name == whichProperty).Single();
        }
    }
}
