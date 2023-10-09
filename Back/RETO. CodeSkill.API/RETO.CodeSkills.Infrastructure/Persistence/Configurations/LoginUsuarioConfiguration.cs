using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RETO.CodeSkills.Domain.Entities;

namespace RETO.CodeSkills.Infrastructure.Persistence.Configurations
{
    public class LoginUsuarioConfiguration : IEntityTypeConfiguration<LoginUsuario>
    {
        public void Configure(EntityTypeBuilder<LoginUsuario> builder)
        {
            builder.HasKey(e => e.IdUsuario).HasName("PK__login_us__4E3E04AD662239C4");

            builder.ToTable("login_usuario");

            builder.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            builder.Property(e => e.ContraseñaUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contraseña_usuario");
            builder.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_usuario");
        }
        
    }
}
