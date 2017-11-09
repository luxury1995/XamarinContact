using System;
using ContactApp.iOS;
using ContactApp.Services;
using Foundation;
using Plugin.Messaging;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(PhoneDialer))]
namespace ContactApp.iOS
{
    public class PhoneDialer :IDialer
    {
        public PhoneDialer(){
            
        }


        public void Dial(string phoneNumber)
        {
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
            {
                phoneDialer.MakePhoneCall(phoneNumber);
            }
        }
    }
}
