using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AppContact.ViewModels;
using ContactApp.EventArg;
using ContactApp.Models;
using ContactApp.Services;
using Plugin.Messaging;
using Prism.Navigation;
using Xamarin.Forms;

namespace ContactApp.ViewModels
{
    public class DetailContactPageViewModel : ViewModelBase
    {
        private ContactService _dataService;
        private Contact _contact;
        private ObservableCollection<Contact> _listContacts;
        private ObservableCollection<PhoneModel> _listPhones;
        private ObservableCollection<String> _listEmails;
        public Command CallCommand { get; set; }
        public Command EmailCommand { get; set; }
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

        public ObservableCollection<PhoneModel> ListPhones
        {
            get => _listPhones;
            set => SetProperty(ref _listPhones, value, OnHeightListChanged, "ListPhones");
        }

        public ObservableCollection<String> ListEmails
        {
            get => _listEmails;
            set => SetProperty(ref _listEmails, value, OnHeightEmailListChanged, "ListEmails");
        }

        public Contact Contact
        {
            get => _contact;
            set => SetProperty(ref _contact, value);
        }

        public DetailContactPageViewModel(INavigationService navigationService, ContactService dataService) : base(navigationService)
        {
            _dataService = dataService;
            CallCommand = new Command<PhoneCellArgs>(executePhone);
            EmailCommand = new Command<AddressCellArgs>(executeEmail);
        }

        private void executePhone(PhoneCellArgs obj)
        {
            if (obj.EnumEvent.Equals(Enum.EnumEvent.Call))
            {
                var phoneDialer = CrossMessaging.Current.PhoneDialer;
                if (phoneDialer.CanMakePhoneCall)
                    phoneDialer.MakePhoneCall(obj.PhoneNumber);
            }
            else
            {
                var messageDialer = CrossMessaging.Current.SmsMessenger;
                if (messageDialer.CanSendSms)
                {
                    messageDialer.SendSms(obj.PhoneNumber, "");
                    Application.Current.MainPage.DisplayAlert("Done", obj.PhoneNumber, "OK");
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("False", "Device not support", "OK");
                }
            }
        }

        private void executeEmail(AddressCellArgs obj)
        {
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            var emailBuilder = new EmailMessageBuilder()
                .To(obj.EmailAdress)
                .Subject("Hello Yolo BTC")
                .Build();
            if (emailMessenger.CanSendEmail)
            {
                emailMessenger.SendEmail(email: emailBuilder);
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("False", "Device not support", "OK");
            }
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
