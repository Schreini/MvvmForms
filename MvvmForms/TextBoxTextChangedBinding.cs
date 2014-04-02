using System.Windows.Forms;

namespace MvvmForms
{
    public class TextBoxTextChangedBinding<TValue> : ValueBinding<TValue>
    {
        public TextBox Control { get; set; }

        public TextBoxTextChangedBinding(PropertyValue<TValue> viewModelPropertyValue, PropertyValue<TValue> controlPropertyValue, TextBox control) 
            : base(viewModelPropertyValue, controlPropertyValue)
        {
            Control = control;
            Control.TextChanged += TextChanged;
        }

        void TextChanged(object sender, System.EventArgs e)
        {
            SetValueInViewModel();
        }
    }
}
