using Microsoft.EntityFrameworkCore;
using Prueba.Tekton.Domain;


namespace Prueba.Tekton.Infraestructure.Persistence
{
    public class PruebaTektonDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public PruebaTektonDbContext(DbContextOptions<PruebaTektonDbContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=localhost; 
        //        Initial Catalog=Streamer;user id=sa;password=VaxiDrez2025$")
        //    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
        //    .EnableSensitiveDataLogging();
        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Product>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateDate = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdateDate = DateTime.Now;
                        entry.Entity.UpdateBy = "system";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>();
        }
    }
}
