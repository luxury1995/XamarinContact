using Autofac;
using ContactApp.Services;
using ContactApp.Views;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;

namespace ContactApp
{
    public partial class App :PrismApplication
    {
        public App()
        {
            
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("Navigation/PeopleList");
        }
        protected override void RegisterTypes()
        {
            
            Container.RegisterType(typeof(IDataService), typeof(MockDataService), new ContainerControlledLifetimeManager());
            Container.RegisterTypeForNavigation<NavigationPage>("Navigation");
            Container.RegisterTypeForNavigation<PeopleListPage>("PeopleList");
            Container.RegisterTypeForNavigation<NewPeoplePage>("NewPeople");
         
        }

    }
    
}
