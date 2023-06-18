using Microsoft.EntityFrameworkCore;

namespace DotNetApi.Models
{
    public class CustomersContext: DbContext
    {
        public CustomersContext(DbContextOptions<CustomersContext> options)
        : base(options)
        {
        }

        public DbSet<CustomersItem> CustomersItems { get; set; } = null!;
    }
}
