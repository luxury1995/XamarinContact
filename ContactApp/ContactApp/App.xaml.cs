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
            //Register Navigation
            Container.RegisterType(typeof(IDataService), typeof(MockDataService), new ContainerControlledLifetimeManager());
            Container.RegisterTypeForNavigation<NavigationPage>("Navigation");
            Container.RegisterTypeForNavigation<PeopleListPage>("PeopleList");
            Container.RegisterTypeForNavigation<NewPeoplePage>("NewPeople");
            Container.RegisterTypeForNavigation<DetailContactPage>("Detail");
            //Dependency Service
            // register the dependencies in the same
            var contactService = DependencyService.Get<ContactService>();
            Container.RegisterInstance<ContactService>(contactService);
           
        }

    }
    
}
