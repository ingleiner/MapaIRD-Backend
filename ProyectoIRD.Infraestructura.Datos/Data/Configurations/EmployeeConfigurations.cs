using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoIRD.Dominio.Entities;

namespace ProyectoIRD.Infraestructura.Datos.Data.Configurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder.ToTable("Empleado");
            builder.Property(u => u.IdentityCard)
                .IsRequired()
                .HasColumnName("DocumentoIdentidad")
                .HasMaxLength(11)
                .IsUnicode(true);
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasColumnName("Nombres")
                .HasMaxLength(50);
            builder.Property(u => u.LastName)
                .IsRequired()
                .HasColumnName("Apellidos")
                .HasMaxLength(50);
            builder.Property(u => u.Email)
                 .IsRequired()
                 .IsUnicode(false)
                 .HasMaxLength(50);
            builder.Property(u => u.PersonalPhone)
                .HasColumnName("Celular")
                .HasMaxLength(10)
                .IsUnicode(false);
            builder.Property(u => u.WorkPhone)
                .HasColumnName("Telefono")
                .HasMaxLength(10)
                .IsUnicode(false);
            builder.Property(u => u.JobTitle)
                .HasColumnName("Cargo")
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(u => u.IsActive)
                .HasColumnName("Activo");
            builder.Property(u => u.CreatedAt)
                .HasColumnName("FechaCreacion");
            builder.Property(u => u.UpdatedAt)
                .HasColumnName("FechaActualizacíon");
        }
    }
}
