

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RETO.CodeSkills.Domain.Entities;

namespace RETO.CodeSkills.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Docente> Docentes { get; set; }

        DbSet<LoginUsuario> LoginUsuarios { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
      
    }
}
