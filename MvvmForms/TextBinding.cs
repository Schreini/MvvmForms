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
            //ToDo: Warum geht hier GetValue(Source) nicht ???
            Destination.Text = (string)PropInfo.GetValue(Source, BindingFlags.Default, null, null, null);
        }
    }
}