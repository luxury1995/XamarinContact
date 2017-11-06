using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ContactApp.Models;

namespace ContactApp.Services
{
    public interface IDataService
    {
        Task AddContact(Contact contact);
        //Get Contact
      
    }
}
