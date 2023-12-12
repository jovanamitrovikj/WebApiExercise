using WebApiExercise.Models;

namespace WebApiExercise.IService
{
    public interface IContactService
    {
       
        Task<List<Contact>> GetAllContacts();
        
        Task<List<Contact>> GetContactWithCompanyAndCountry(Contact contact);
        Task<int> CreateContact(Contact contact);
        Task UpdateContact(int contactId, Contact contact);
        Task DeleteContact(int contactId);
        Task<List<Contact>> FilterContacts(int? countryId, int? companyId);


    }
}
