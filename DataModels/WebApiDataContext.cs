using Microsoft.EntityFrameworkCore;
using WebApiExercise.Models;

namespace WebApiExercise.DataModels
{
    public class WebApiDataContext:DbContext
    {
        public WebApiDataContext(DbContextOptions<WebApiDataContext> options)
           : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country> Countries { get; set; }
       
    }
}
