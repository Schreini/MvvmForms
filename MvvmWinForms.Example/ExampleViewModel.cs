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
                Empty = _date.Length == 0;
                RaisePropertyChanged(() => Date);
            }
        }

        private bool _empty;
        public bool Empty
        {
            get { return _empty; }
            set
            {
                _empty = value;
                RaisePropertyChanged(() => Empty);
            }
        }

        public void EmptyClick()
        {
            Date = Empty ? "nicht mehr leer" : string.Empty;
        }

        public void BtnClick()
        {
            Date = "lalamimi";
        }
    }
}