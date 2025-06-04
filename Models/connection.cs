using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Models
{
    public class connection : DbContext
    {
        public connection(DbContextOptions<connection> options) : base (options){ }
       public DbSet<student> students { get; set; }
    }
}
