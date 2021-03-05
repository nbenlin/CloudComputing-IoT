using Microsoft.EntityFrameworkCore;
using PeopleWebApp.Models;
 

namespace PeopleWebApp
{
    public class PeopleDb : DbContext
    {
        public PeopleDb(DbContextOptions<PeopleDb> options) : base(options)
        {
        }
        public DbSet<Person> People { get; set; }
    }
}
