using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiExercise.IService;
using WebApiExercise.Models;

namespace WebApiExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            try
            {
                var contacts = await _contactService.GetAllContacts();
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in a way that makes sense for your application
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("withCompanyAndCountry")]
        public async Task<ActionResult<List<Contact>>> GetContactWithCompanyAndCountries(Contact contact)
        {
            
            try
            {
                var contacts = await _contactService.GetContactWithCompanyAndCountry(contact);
                var result = MapToContactWithCompanyAndCountry(contacts);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in a way that makes sense for your application
                return StatusCode(500, "Internal server error");
            }
        }
        private List<Contact> MapToContactWithCompanyAndCountry(List<Contact> contacts)
        {
            var result = new List<Contact>();

            foreach (var contact in contacts)
            {
                result.Add(new Contact
                {
                    ContactId = contact.ContactId,
                    ContactName = contact.ContactName,
                    CompanyId = contact.Company.CompanyId,
                    CountryId = contact.Country.CountryId
                });
            }

            return result;
        }


        [HttpGet("filter")]
        public async Task<ActionResult<List<Contact>>> FilterContacts(int? countryId, int? companyId)
        {
            try
            {
                var contacts = await _contactService.FilterContacts(countryId, companyId);
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in a way that makes sense for your application
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

