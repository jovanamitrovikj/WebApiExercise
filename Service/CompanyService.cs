using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using WebApiExercise.DataModels;
using WebApiExercise.IService;
using WebApiExercise.Models;

namespace WebApiExercise.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly WebApiDataContext dataContext;
        public CompanyService(WebApiDataContext context)
        {
            dataContext = context;
        }
        public async Task<int> CreateCompany(Company company)
        {
            dataContext.Companies.Add(company);
            await dataContext.SaveChangesAsync();
            return company.CompanyId;
        }

        public async Task<Company> DeleteCompanyById(int companyId)
        {
            var deleteCompany = await dataContext.Companies.FindAsync(companyId);

            if (deleteCompany != null)
            {
                dataContext.Companies.Remove(deleteCompany);
                await dataContext.SaveChangesAsync();
            }

            return deleteCompany;
        }

        public async Task<List<Company>> GetCompany()
        {
            return await dataContext.Companies.ToListAsync();
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            var existCompany = await dataContext.Companies.FindAsync(company.CompanyId);

            if (existCompany != null)
            {
                existCompany.CompanyName = company.CompanyName;

                await dataContext.SaveChangesAsync();
            }

            return existCompany;
        }
    }
}
