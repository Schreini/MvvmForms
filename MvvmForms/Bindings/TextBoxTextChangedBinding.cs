using System;
using System.Windows.Forms;

namespace MvvmForms.Bindings
{
    public class TextBoxBaseTextChangedBinding : ValueBinding<string>
    {
        public TextBoxBase Control { get; set; }

        public TextBoxBaseTextChangedBinding(
            PropertyValue<string> viewModelPropertyValue, 
            PropertyValue<string> controlPropertyValue, 
            TextBoxBase  control) 
            : base(viewModelPropertyValue, controlPropertyValue)
        {
            Control = control;
            Control.TextChanged += TextChanged;
        }

        void TextChanged(object sender, EventArgs e)
        {
            SetValueInViewModel();
        }

        public override void Dispose()
        {
            Control.TextChanged -= TextChanged;
        }
    }
}
