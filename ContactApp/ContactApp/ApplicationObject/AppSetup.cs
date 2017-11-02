using System;
using Autofac;
using ContactApp.Services;
using ContactApp.ViewModels;

namespace ContactApp.ApplicationObject
{
    public class AppSetup
    {
        public IContainer CreateContainer()
        {
            var containerBuilder = new ContainerBuilder();
            RegisterDependencies(containerBuilder);
            return containerBuilder.Build();
        }
        protected virtual void RegisterDependencies(ContainerBuilder cb){
            cb.RegisterType<IDataService>().As<IDataService>();
        }
    }
}
