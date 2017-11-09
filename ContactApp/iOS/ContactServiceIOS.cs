using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ContactApp.iOS;
using ContactApp.Models;
using ContactApp.Services;
using Contacts;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(ContactServiceIOS))]
namespace ContactApp.iOS
{
    public class ContactServiceIOS : ContactService
    {
        ObservableCollection<Contact> Contacts;
        public Contact GetContact(string id)
        {
            var contact = Contacts.FirstOrDefault(x => x.Id == id);
            return contact;
        }

        public Task<ObservableCollection<Contact>> GetContacts()
        {

            var ContactList = new List<Contact>();
            var fetchKeys = new NSString[]
            {
                CNContactKey.GivenName,
                CNContactKey.FamilyName,
                CNContactKey.OrganizationName,
                CNContactKey.Identifier,
                CNContactKey.ImageData,
                CNContactKey.PhoneNumbers,
                CNContactKey.EmailAddresses,
                CNContactKey.ThumbnailImageData
            };
            NSError error;
            var ContainerId = new CNContactStore().DefaultContainerIdentifier;
            using (var predicate = CNContact.GetPredicateForContactsInContainer(ContainerId))
            using (var store = new CNContactStore())
            {
                var listContacts = store.GetUnifiedContacts(predicate, fetchKeys, out error);
                foreach (var item in listContacts)
                {
                    var contact = new Contact();
                    contact.Id = item.Identifier;
                    contact.FirstName = item.GivenName;
                    contact.LastName = item.FamilyName;
                    contact.Company = item.OrganizationName;
                    var PhonesList = new List<PhoneModel>();
                    foreach (var phone in item.PhoneNumbers)
                    {
                        var phoneModel = new PhoneModel();
                        phoneModel.PhoneNumber = phone.Value.StringValue;
                        //phoneModel.PhoneType = phone.Label;
                        var phoneType = phone.Label;
                        string[] phoneSplit = phoneType.Split(new char[] { '_', '<' , '>' , '!', '$' }, StringSplitOptions.RemoveEmptyEntries);
                        phoneModel.PhoneType = phoneSplit[0];
                        PhonesList.Add(phoneModel);
                        contact.Phones = new ObservableCollection<PhoneModel>(PhonesList);
                    }

                    var EmailList = new List<String>();
                    foreach (var email in item.EmailAddresses)
                    {
                        EmailList.Add(email.Value);
                        contact.Emails = new ObservableCollection<string>(EmailList);
                    }
                    ContactList.Add(contact);
                }
            }
            Contacts = new ObservableCollection<Contact>(ContactList);
            return Task.FromResult(Contacts);
        }
    }
}
