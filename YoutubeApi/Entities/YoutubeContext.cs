using Microsoft.EntityFrameworkCore;

namespace YoutubeApi.Entities
{
    public class YoutubeContext : DbContext
    {
        public YoutubeContext(DbContextOptions<YoutubeContext> options) :base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
