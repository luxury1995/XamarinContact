using System;
using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace ContactApp.Models
{
    public class Contact : BindableBase
    {
        private ObservableCollection<PhoneModel> phones;
        private ObservableCollection<String> emails;

        private string _id;
        private string _firstname;
        private string _lastname;
        private string _company;
        private string _jobtitle;
        private string _email;
        private string _phone;
        private string _street;
        private string _city;
        private string _postalcode;
        private string _state;
        private byte[] _photourl;

        public string Id {
            get => _id;
            set => SetProperty(ref _id, value);
            
        }

        public string FirstName
        {
            get => _firstname;
            set => SetProperty(ref _firstname, value);
        }
        public string LastName
        {
            get => _lastname;
            set => SetProperty(ref _lastname, value);
        }
        public string Company
        {
            get => _company;
            set => SetProperty(ref _company, value);
        }
        public string JobTitle
        {
            get => _jobtitle;
            set => SetProperty(ref _jobtitle, value);
        }
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        public string Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }
        public string Street
        {
            get => _street;
            set => SetProperty(ref _street, value);
        }
        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        public string PostalCode
        {
            get => _postalcode;
            set => SetProperty(ref _postalcode, value);
        }
        public string State
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }
        public byte[] PhotoUrl { 
            get => _photourl; 
            set => SetProperty(ref _photourl, value); }

        public string Fullname => FirstName + " " + LastName;
        public string NameSort
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Fullname) || Fullname.Length == 0)
                    return "?";

                return Fullname[0].ToString().ToUpper();
            }
        }


        public ObservableCollection<PhoneModel> Phones
        {
            get => phones;
            set => SetProperty(ref phones, value);
        }

        public ObservableCollection<String> Emails
        {
            get => emails;
            set => SetProperty(ref emails, value);
        }
    }
}
