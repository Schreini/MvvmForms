using System;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace MvvmForms
{
    public partial class Form1 : MvvmForm
    {
        protected override void InitializeBindings()
        {
            OneWayBinding(() => Date, TxtDate);
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
            set { _date = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Date = "lalamimi";
            RaisePropertyChanged(() => Date);
        }
    }

}
