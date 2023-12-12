using WebApiExercise.Models;

namespace WebApiExercise.IService
{
    public interface ICountryService
    {
        Task<int> CreateCountry(Country country);
        Task<Country> UpdateCountry(Country country);
        Task<List<Country>> GetCountry();
        Task<Country> DeleteCountry(int countrtyId);
    }
}
