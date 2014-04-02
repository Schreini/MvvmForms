using System.Reflection;
using System.Windows.Forms;

namespace MvvmForms
{

    //ToDo: implement IDisposable
    //ToDo: Eventlistener lösen
    /*
    public class TextBoxBinding : BindingBase
    {
        public object Source { get; set; }
        public PropertyInfo PropInfo { get; set; }
        TextBox Destination { get; set; }
        private bool _settingInView = false;

        public TextBoxBinding(MvvmForm form, PropertyInfo propInfo, TextBox destination)
        {
            Source = form;
            PropInfo = propInfo;
            Destination = destination;
            Destination.TextChanged += (s, e) =>
                {
                    if (!_settingInView)
                        SetInViewModel();
                };
        }

        public override void SetInView()
        {
            try
            {
                _settingInView = true;
                Destination.Text = (string) PropInfo.GetValue(Source, null);
            }
            finally
            {
                _settingInView = false;
            }
        }

        public override void SetInViewModel()
        {
            PropInfo.SetValue(Source, Destination.Text, null);
        }
    }
    */
}