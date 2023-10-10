using Microsoft.EntityFrameworkCore;
using RETO.CodeSkills.Application.Interfaces;
using RETO.CodeSkills.Domain.Entities;
using System.Reflection;


namespace RETO.CodeSkills.Infrastructure.Persistence.DbContexts
{
    public partial class DBRETOContext : DbContext, IApplicationDbContext
    {
        public DBRETOContext() { }
        public DBRETOContext(DbContextOptions<DBRETOContext> options)
        : base(options)
        {

        }

        public virtual DbSet<Docente> Docentes { get; set; }

        public virtual DbSet<LoginUsuario> LoginUsuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            OnModelCreatingPartial(modelBuilder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
