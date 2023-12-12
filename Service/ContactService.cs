using Microsoft.EntityFrameworkCore;
using WebApiExercise.DataModels;
using WebApiExercise.IService;
using WebApiExercise.Models;

namespace WebApiExercise.Service
{
    public class ContactService : IContactService
    {
        private readonly WebApiDataContext dataContext;
        public ContactService(WebApiDataContext context)
        {
            dataContext = context;
        }
        public async Task<int> CreateContact(Contact contact)
        {
            dataContext.Contacts.Add(contact);
            await dataContext.SaveChangesAsync();
            return contact.ContactId;
        }

        public async Task DeleteContact(int contactId)
        {
            var contactToDelete = await dataContext.Contacts.FindAsync(contactId);
            if (contactToDelete != null)
            {
                dataContext.Contacts.Remove(contactToDelete);
                await dataContext.SaveChangesAsync();
            }
        }

        public async Task<List<Contact>> FilterContacts(int? countryId, int? companyId)
        {
            IQueryable<Contact> query = dataContext.Contacts;

            if (countryId.HasValue)
                query = query.Where(c => c.CountryId == countryId);

            if (companyId.HasValue)
                query = query.Where(c => c.CompanyId == companyId);

            return await query.ToListAsync();
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await dataContext.Contacts.ToListAsync();
        }

        public async Task<List<Contact>> GetContactWithCompanyAndCountry(Contact contact)
        {
            return await dataContext.Contacts
                .Include(c => c.Company)
                .Include(c => c.Country)
                .ToListAsync();
        }

        public async Task UpdateContact(int contactId, Contact contact)
        {
            var existingContact = await dataContext.Contacts.FindAsync(contactId);

            if (existingContact != null)
            {
                existingContact.ContactName = contact.ContactName;
                existingContact.CompanyId = contact.CompanyId;
                existingContact.CountryId = contact.CountryId;

                await dataContext.SaveChangesAsync();
            }
        }
    }
}



