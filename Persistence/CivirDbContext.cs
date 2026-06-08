namespace Civir.Infrastructure.Persistence
{
    using Civir.Domain.Entities;
    using Civir.Domain.Common   ;
    using Microsoft.EntityFrameworkCore;

    public class CivirDbContext : DbContext
    {
        public CivirDbContext(DbContextOptions<CivirDbContext> options) : base(options)
        {
        }

 public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is BaseDomainModel &&
                   (e.State == EntityState.Added || e.State == EntityState.Modified));
        foreach (var entry in entries)
        {
            var entity = (BaseDomainModel)entry.Entity;
            var now = DateTime.UtcNow;
            if (entry.State == EntityState.Added)
            {
                entity.CreatedAt = now;
            }
            else
            {
                // Preserve the original CreatedAt value on updates
                entry.Property(nameof(BaseDomainModel.CreatedAt)).IsModified = false;
            }
            entity.UpdatedAt = now;
        }
        return base.SaveChangesAsync(cancellationToken);
    }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}