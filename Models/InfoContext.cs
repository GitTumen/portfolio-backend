using Microsoft.EntityFrameworkCore;

namespace DotNetApi.Models
{
    public class InfoContext: DbContext
    {
        public InfoContext(DbContextOptions<InfoContext> options)
        : base(options)
        {
        }

        public DbSet<InfoItem> InfoItems { get; set; } = null!;
    }
}
