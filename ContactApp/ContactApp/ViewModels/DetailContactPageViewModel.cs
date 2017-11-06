using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AppContact.ViewModels;
using ContactApp.Models;
using ContactApp.Services;
using Prism.Navigation;

namespace ContactApp.ViewModels
{
    public class DetailContactPageViewModel : ViewModelBase
    {
        private ContactService _dataService;
        private Contact _contact;
        private ObservableCollection<Contact> _listContacts;
        private ObservableCollection<String> _listPhones;
        private ObservableCollection<String> _listEmails;
        private int heightRequest;
        public int HeightRequestListView
        {
            get => heightRequest;
            set => SetProperty(ref heightRequest, value);
        }
        private int heightEmailListRequest;
        public int HeightEmailListRequest
        {
            get => heightEmailListRequest;
            set => SetProperty(ref heightEmailListRequest, value);
        }

        public ObservableCollection<Contact> ListContacts
        {
            get => _listContacts;
            set => SetProperty(ref _listContacts, value);
        }

        public ObservableCollection<String> ListPhones
        {
            get => _listPhones;
            set => SetProperty(ref _listPhones, value, OnHeightListChanged, "ListPhones");
        }

        public ObservableCollection<String> ListEmails
        {
            get => _listEmails;
            set => SetProperty(ref _listEmails, value,OnHeightEmailListChanged,"ListEmails");
        }

        public Contact Contact
        {
            get => _contact;
            set => SetProperty(ref _contact, value);
        }

        public DetailContactPageViewModel(INavigationService navigationService, ContactService dataService) : base(navigationService)
        {
            _dataService = dataService;
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("id"))
            {
                var id = parameters["id"];
                Contact = _dataService.GetContact(id.ToString());
                ListPhones = Contact.Phones;
                ListEmails = Contact.Emails;
            }
        }
        void OnHeightListChanged()
        {
            HeightRequestListView = 50 * ((ListPhones != null && ListPhones.Count > 0) ? ListPhones.Count : 1);
        }

        void OnHeightEmailListChanged()
        {
            HeightEmailListRequest = 50 * ((ListEmails != null && ListEmails.Count > 0) ? ListEmails.Count : 1);
        }

    }
}
