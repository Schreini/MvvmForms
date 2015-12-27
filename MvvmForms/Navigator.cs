using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Autofac;
using MvvmForms.Bindings;

namespace MvvmForms
{
    public class Navigator
    {
        private readonly IContainer _container;

        public Navigator(IContainer container)
        {
            _container = container;
        }

        public Form CreateView(Type viewType)
        {
            var setBinderMethodInfo = viewType.GetMethod("SetBinder");
            var viewModelType = GetViewModelType(viewType);
            var binderType = typeof(Binder<>);

            var viewModel = _container.Resolve(viewModelType);
            var view = _container.Resolve(viewType) as Form;

            var binderGenericTypeArgs = new Type[] { viewModelType };
            var binderGenericType = binderType.MakeGenericType(binderGenericTypeArgs);
            var binder = Activator.CreateInstance(binderGenericType, new[] { viewModel });

            setBinderMethodInfo.Invoke(view, new[] { binder });

            return view;
        }

        public void ShowView(Type viewType)
        {
            var view = CreateView(viewType);
            view.Show();
        }

        private Type GetViewModelType(Type viewType)
        {
            Stack<Type> baseTypes = new Stack<Type>();
            baseTypes.Push(viewType);

            Type baseType;
            Type currentType = viewType;
            while ((baseType = currentType.BaseType).Name != "Object")
            {
                baseTypes.Push(baseType);
                currentType = baseType;
            }

            while ((currentType = baseTypes.Pop()) != viewType)
            {
                if (currentType.Name.StartsWith("ViewBase") && currentType.IsGenericType)
                {
                    return currentType.GetGenericArguments()[0];
                }
            }
            return null;
        }
    }
}
