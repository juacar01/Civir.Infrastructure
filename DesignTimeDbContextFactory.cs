using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Civir.Infrastructure.Persistence;

namespace Civir.Infrastructure;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CivirDbContext>
{
    public CivirDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CivirDbContext>();
        
        // Coloca una cadena de conexión temporal local solo para generar la migración
        optionsBuilder.UseSqlServer("Server=localhost;Database=CivirDatabase;User Id=sa;Password=*a123456;TrustServerCertificate=True;");

        return new CivirDbContext(optionsBuilder.Options);
    }
}
