using System.Reflection;
using System.Windows.Forms;

namespace MvvmForms
{
    public class TextBinding : BindingBase
    {
        public object Source { get; set; }
        public PropertyInfo PropInfo { get; set; }
        TextBox Destination { get; set; }

        public TextBinding(MvvmForm source, PropertyInfo propInfo, TextBox destination)
        {
            Source = source;
            PropInfo = propInfo;
            Destination = destination;
        }

        public override void Bind()
        {
            Destination.Text = (string) PropInfo.GetValue(Source, null);
        }
    }
}