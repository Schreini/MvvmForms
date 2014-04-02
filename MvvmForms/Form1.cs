using System;

namespace MvvmForms
{
    public partial class Form1 : MvvmForm
    {
        protected override void InitializeBindings()
        {
            RegisterBinding(() => Date, TxtDate);
            RegisterBinding(() => Date, TxtDate2);
        }

        public Form1()
        {
            InitializeComponent();
            DoBindings();
        }

        private string _date = "initial value";
        public string Date
        {
            get { return _date; }
            set
            {
                _date = value;
                RaisePropertyChanged(() => Date);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Date = "lalamimi";
        }
    }

}
