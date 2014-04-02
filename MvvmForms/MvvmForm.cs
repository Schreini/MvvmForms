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
        private readonly Dictionary<string, BindingBase> bindings = new Dictionary<string, BindingBase>();

        //abstract
        protected virtual void InitializeBindings()
        {
        }

        protected void RegisterBinding<T>(Expression<Func<T>> source, TextBox destination)
        {
            var name = this.GetPropertyNameFromExpression(source);
            bindings.Add(name, new TextBoxBinding(this, GetPropertyInfo(name), destination));
        }

        protected void DoBindings()
        {
            InitializeBindings();
            foreach (KeyValuePair<string, BindingBase> binding in bindings)
            {
                binding.Value.SetInView();
            }
        }

        public void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            var name = this.GetPropertyNameFromExpression(property);
            RaisePropertyChanged(name);
        }

        public void RaisePropertyChanged(string whichProperty)
        {
            if(bindings.ContainsKey(whichProperty))
                bindings[whichProperty].SetInView();
        }

        private PropertyInfo GetPropertyInfo(string whichProperty)
        {
            return GetType().GetProperties().Where(p => p.Name == whichProperty).Single();
        }
    }
}
