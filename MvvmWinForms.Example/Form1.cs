using System;
using MvvmForms;

namespace MvvmWinForms.Example
{
    public partial class Form1 : MvvmForm
    {
        protected override void InitializeBindings()
        {
            RegisterStringBinding(() => Date, TxtDate, t => t.Text);
            RegisterStringBinding(() => Date, TxtDate2, t => t.Text);
            RegisterStringBinding(() => Date, LblDate, l => l.Text);
            RegisterBoolBinding(() => Empty, CbxEmpty, c => c.Checked);
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
                RaisePropertyChanged(() => Empty);
            }
        }

        public bool Empty { get { return Date.Length == 0; } }

        private void button1_Click(object sender, EventArgs e)
        {
            Date = "lalamimi";
        }
    }

}
