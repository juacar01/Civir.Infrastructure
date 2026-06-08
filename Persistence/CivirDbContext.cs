namespace Civir.Infrastructure.Persistence
{
    using Civir.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class CivirDbContext : DbContext
    {
        public CivirDbContext(DbContextOptions<CivirDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}