using Microsoft.EntityFrameworkCore;
using Zevit.Domain.Entities;

namespace Zevit.Infrastructure.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Contact> Contacts { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }

    }


}
