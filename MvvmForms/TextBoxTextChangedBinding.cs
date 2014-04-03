using System.Windows.Forms;

namespace MvvmForms
{
    public class TextBoxTextChangedBinding : ValueBinding<string>
    {
        public TextBox Control { get; set; }

        public TextBoxTextChangedBinding(
            PropertyValue<string> viewModelPropertyValue, 
            PropertyValue<string> controlPropertyValue, 
            TextBox control) 
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
