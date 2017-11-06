using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Models;
using Xamarin.Forms;

namespace ContactApp.Services
{
    public class MockDataService : IDataService
    {
        public ObservableCollection<Contact> Contacts { get; set; }

        public Task AddContact(Contact contact)
        {
            //Automatic generate contact id
            contact.Id = Guid.NewGuid().ToString();
            Contacts.Add(contact);
            return Task.FromResult(contact);
        }
    }
}
