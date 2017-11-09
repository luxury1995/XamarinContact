using System;
using Prism.Mvvm;

namespace ContactApp.Models
{
    public class PhoneModel :BindableBase
    {
        public PhoneModel()
        {
        }
        private string _phoneType;
        private string _phoneNumber;

        public string PhoneType
        {
            get => _phoneType;
            set => SetProperty(ref _phoneType, value);
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }
    }
}
