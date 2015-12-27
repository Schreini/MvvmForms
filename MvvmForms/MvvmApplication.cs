using System;
using System.Windows.Forms;
using Autofac;

namespace MvvmForms
{
    public abstract class MvvmApplication
    {
        private IContainer _container;

        public void Run()
        {
            SetupAutofac();
            var navigator = new Navigator(_container);

            var mainView = navigator.CreateView(StartupType);

            Application.Run(mainView);
        }

        private void SetupAutofac()
        {
            var builder = new ContainerBuilder();
            InitializeIoc(builder);
            _container = builder.Build();
        }

        protected abstract void InitializeIoc(ContainerBuilder builder);
        protected abstract Type StartupType { get; }
    }
}
