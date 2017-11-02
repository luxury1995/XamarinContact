using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ContactApp.Models;

namespace ContactApp.Services
{
    public interface ContactService
    {
        Task<ObservableCollection<Contact>> GetContacts();
        string HelloAndroid();
    }
}
