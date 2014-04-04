﻿using System;
using MvvmForms;

namespace MvvmWinForms.Example
{
    public partial class Form1 : MvvmForm<ExampleViewModel>
    {
        public Form1(VvmBinder binder) : base(binder)
        {
            InitializeComponent();
            // oder in einer methode OnViewModelSet
            binder.ForViewModel(ViewModel)
                .FromProperty(vm => vm.Date)
                    .ToControl(TxtDate).Register(t => t.Text)
                    .ToControl(TxtDate2).Register(t => t.Text)
                    .ToControl(LblDate).Register(l => l.Text);
            DoBindings();
        }

        protected override void InitializeBindings()
        {
            RegisterBinding(() => Date, TxtDate, t => t.Text);
            RegisterBinding(() => Date, TxtDate2, t => t.Text);
            RegisterBinding(() => Date, LblDate, l => l.Text);
            RegisterBinding(() => Empty, CbxEmpty, c => c.Checked);
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

    public class ExampleViewModel
    {
        
    }

}
