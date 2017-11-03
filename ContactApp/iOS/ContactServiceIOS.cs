using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ContactApp.iOS;
using ContactApp.Models;
using ContactApp.Services;
using Contacts;
using Foundation;

[assembly: Xamarin.Forms.Dependency(typeof(ContactServiceIOS))]
namespace ContactApp.iOS
{
    public class ContactServiceIOS : ContactService
    {
        public string HelloAndroid()
        {
            return "IOS";
        }

        public Task<ObservableCollection<Contact>> GetContacts()
        {
            ObservableCollection<Contact> Contacts;
            var ContactList = new List<Contact>();
            var fetchKeys = new NSString[]
            {
                CNContactKey.GivenName,
                CNContactKey.FamilyName,
                CNContactKey.OrganizationName
            };
            NSError error;
            var ContainerId = new CNContactStore().DefaultContainerIdentifier;
            using (var predicate = CNContact.GetPredicateForContactsInContainer(ContainerId))
            using (var store = new CNContactStore())
            {
                var listContacts = store.GetUnifiedContacts(predicate, fetchKeys, out error);
                foreach (var item in listContacts){
                    var contact = new Contact();
                    contact.FirstName = item.GivenName;
                    contact.LastName = item.FamilyName;
                    contact.Company = item.OrganizationName;
                    ContactList.Add(contact);
                }
            }
            Contacts = new ObservableCollection<Contact>(ContactList);
            return Task.FromResult(Contacts);
        }
    }
}
