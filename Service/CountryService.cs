using Microsoft.EntityFrameworkCore;
using WebApiExercise.DataModels;
using WebApiExercise.IService;
using WebApiExercise.Models;

namespace WebApiExercise.Service
{
    public class CountryService : ICountryService
    {
        private readonly WebApiDataContext dataContext;
        public CountryService(WebApiDataContext context)
        {
            dataContext = context;
        }
        public async Task<int> CreateCountry(Country country)
        {
            dataContext.Countries.Add(country);
            await dataContext.SaveChangesAsync();
            return country.CountryId;
        }

        public async Task<Country> DeleteCountry(int countrtyId)
        {
            var deleteCountry = await dataContext.Countries.FindAsync(countrtyId);

            if (deleteCountry != null)
            {
                dataContext.Countries.Remove(deleteCountry);
                await dataContext.SaveChangesAsync();
            }

            return deleteCountry; // Return the deleted country or null if not found
        }

        public async Task<List<Country>> GetCountry()
        {
            return await dataContext.Countries.ToListAsync();
        }

        public async Task<Country> UpdateCountry(Country country)
        {
            var existingCountry = await dataContext.Countries.FindAsync(country.CountryId);

            if (existingCountry != null)
            {
                existingCountry.CountryName = country.CountryName;

                await dataContext.SaveChangesAsync();
            }

            return existingCountry;
        }
    }
}
