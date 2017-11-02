using System;
using Prism.Mvvm;
using Prism.Navigation;

namespace AppContact.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        public INavigationService _navigationService { get; }

        public ViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}
