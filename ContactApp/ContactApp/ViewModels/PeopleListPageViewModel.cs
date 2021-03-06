﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AppContact.ViewModels;
using ContactApp.Models;
using ContactApp.Services;
using ContactApp.ViewModels.Extension;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace ContactApp.ViewModels
{
    public class PeopleListPageViewModel : ViewModelBase
    {
        private int Flag;

        private IDataService _dataServices;
        private ObservableCollection<Contact> _contacts;

        public ObservableCollection<Contact> Contacts
        {
            get => _contacts;
            set => SetProperty(ref _contacts, value);
        }
        public ObservableCollection<Grouping<string, Contact>> _groupContact;

        public ObservableCollection<Grouping<string, Contact>> ContactGroups
        {
            get => _groupContact;
            set => SetProperty(ref _groupContact, value);
        }

        public ICommand AddNewCommand { get; set; }

        public ICommand DetailCommand { get; set; }


        public PeopleListPageViewModel(INavigationService navigationService, IDataService iDataService) : base(navigationService)
        {
            _dataServices = iDataService;
            AddNewCommand = new DelegateCommand(AddNew);
            DetailCommand = new DelegateCommand<Contact>(DetailExecute);
        }

        private void DetailExecute(Contact obj)
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("id",obj.Id);
            _navigationService.NavigateAsync("DetailContact",navigationParams);
        }

        private void AddNew()
        {
            _navigationService.NavigateAsync("NewPeople");
        }

        //private void DetailExecute(Contact contact)
        //{
        //    var navigationParams = new NavigationParameters();
        //    navigationParams.Add("id", contact.Id);
        //    _navigationService.NavigateAsync("DetailContact", navigationParams);
        //}
        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            // Check if list contact null then get cont
            if (Contacts != null && Contacts.Any())
            {
                Flag = 1;
            }
            if (Flag != 1)
            {
                Contacts = await DependencyService.Get<ContactService>().GetContacts();
                var sorted = from contact in Contacts
                             orderby contact.Fullname
                             group contact by contact.NameSort into ContactGroup
                             select new Grouping<string, Contact>(ContactGroup.Key, ContactGroup);
                ContactGroups = new ObservableCollection<Grouping<string, Contact>>(sorted);
            }
            else
            {
                var sorted = from contact in Contacts
                             orderby contact.Fullname
                             group contact by contact.NameSort into ContactGroup
                             select new Grouping<string, Contact>(ContactGroup.Key, ContactGroup);
                ContactGroups = new ObservableCollection<Grouping<string, Contact>>(sorted);
            }
        }
    }
}
