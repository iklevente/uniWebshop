using UniWebShop.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace UniWebShop.DataAccess.DataAccess
{
    public class UniWebShopDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            var database = Environment.GetEnvironmentVariable("DATABASE_NAME") ?? "emir";
            var userId = Environment.GetEnvironmentVariable("DATABASE_USER") ?? "sa";
            var password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "1Secure*Password1";
            var connectionString = $"Server={server};Database={database};User Id={userId};Password={password};TrustServerCertificate=true;";

            options.UseSqlServer(connectionString);
        }

        public DbSet<UserQuestion> UserQuestions { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Tags)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries))
                .Metadata.SetValueComparer(new ValueComparer<string[]>(
                    (a, b) => a.SequenceEqual(b),
                    a => a.Aggregate(0, (h, x) => HashCode.Combine(h, x.GetHashCode())),
                    a => a.ToArray()));
        }



    }
}
