using System;
using MvvmForms;

namespace MvvmWinForms.Example
{
    public class ExampleViewModel : ViewModelBase
    {
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

        public void BtnClick()
        {
            Date = "lalamimi";
        }
    }
}