using Blog_Site.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog_Site.Repositories
{
    public class BlogSiteDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Data Source=FUJITSU-DESKTOP\\SQLEXPRESS;Initial Catalog=BlogSiteDB;Integrated Security=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                Username = "admin",
                Password = "admin",
                FirstName = "admin",
                LastName = "admin",
                IsAdmin = true
            });

            modelBuilder.Entity<User>()
                .HasAlternateKey(nameof(User.Username));
        }
    }
}