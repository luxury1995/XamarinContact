using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ContactApp.Models;

namespace ContactApp.Services
{
    public interface IDataService
    {
        Task<ObservableCollection<Contact>> GetListContacts();
        //Add new Contact
        Task AddContact(Contact contact);
        //Get Contact
      
    }
}
