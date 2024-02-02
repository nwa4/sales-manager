using Microsoft.EntityFrameworkCore;
using SalesManager.Core.Entities;

namespace SalesManager.Data.Repositories
{
	public class SalesDataContext(DbContextOptions<SalesDataContext> options) : DbContext(options)
    {
        public DbSet<Window> Windows { get; set; }

        public DbSet<SubElement> SubElements { get; set; }

        public DbSet<SubElementType> SubElementTypes { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Window>()
                .ToTable("Window");

            modelBuilder.Entity<Window>()
                .ToTable("Window");

            modelBuilder.Entity<SubElementType>()
                .ToTable("ElementType");

            modelBuilder.Entity<State>()
                .ToTable("State")
                .HasIndex(x=>x.Name)
                .IsUnique();

            modelBuilder.Entity<Order>()
                .ToTable("Order");

            modelBuilder.Entity<OrderWindow>()
                .ToTable("OrderWindow");

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            StampChangedEntities();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => SaveChangesAsync(true, cancellationToken);

        public override int SaveChanges() => SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            StampChangedEntities();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        private void StampChangedEntities()
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateInserted = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.DateUpdated = DateTime.UtcNow;
                }
            }
        }
    }
}
