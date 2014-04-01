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
        private readonly Dictionary<string, TextBox> bindings = new Dictionary<string, TextBox>();

        //abstract
        protected virtual void InitializeBindings()
        {
        }

        protected void OneWayBinding<T>(Expression<Func<T>> source, TextBox destination)
        {
            bindings.Add(this.GetPropertyNameFromExpression(source), destination);
        }

        protected void DoBindings()
        {
            InitializeBindings();
            foreach (KeyValuePair<string, TextBox> binding in bindings)
            {
                RaisePropertyChanged(binding.Key);
            }
        }

        public void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            var name = this.GetPropertyNameFromExpression(property);
            RaisePropertyChanged(name);
        }

        public void RaisePropertyChanged(string whichProperty)
        {
            var pi = GetType().GetProperties().Where(p => p.Name == whichProperty).Single();
            Object o;
            o = this;
            bindings[whichProperty].Text = (string)pi.GetValue(o, BindingFlags.Default, null, null, null);
        }
    }
}
