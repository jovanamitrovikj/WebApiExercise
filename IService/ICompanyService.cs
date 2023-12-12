using WebApiExercise.Models;

namespace WebApiExercise.IService
{
    public interface ICompanyService
    {
        Task<int> CreateCompany(Company company);
        Task<Company> UpdateCompany(Company company);
        Task<List<Company>> GetCompany();
        Task<Company> DeleteCompanyById(int companyId);
    }
}
