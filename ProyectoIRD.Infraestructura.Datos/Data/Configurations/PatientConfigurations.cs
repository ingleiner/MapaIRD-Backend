using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoIRD.Dominio.Entities.Surveys;

namespace ProyectoIRD.Infraestructura.Datos.Data.Configurations
{
    public class PatientConfigurations : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Paciente");

            builder.Property(c => c.TypeDocument)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("TipoDocumento");
            builder.HasIndex(c => c.DocumentId).IsUnique();
            builder.Property(c => c.DocumentId)
                .IsRequired()
                .HasMaxLength(12)
                .HasColumnName("DocumentoIdentidad");
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasColumnName("Nombres")
                .HasMaxLength(50);
            builder.Property(u => u.LastName)
                .IsRequired()
                .HasColumnName("Apellidos")
                .HasMaxLength(50);
            builder.Property(u => u.EPS)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.MedicalStudy)
                .IsRequired()
                .HasColumnName("EstudioMedico")
                .HasMaxLength(250);
            builder.Property(u => u.CreatedAt)
                .HasColumnName("FechaCreación");
            builder.Property(u => u.UpdatedAt)
                .HasColumnName("FechaActualizacion");


        }
    }
}
