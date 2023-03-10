using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoIRD.Dominio.Entities.Users;

namespace ProyectoIRD.Infraestructura.Datos.Data.Configurations
{
    internal class UserRolConfigurations : IEntityTypeConfiguration<UsersRoles>
    {
        public void Configure(EntityTypeBuilder<UsersRoles> builder)
        {
            builder.ToTable("RolUsuario");
        }
    }
}
