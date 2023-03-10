using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoIRD.Dominio.Entities.Surveys;

namespace ProyectoIRD.Infraestructura.Datos.Data.Configurations
{
    public class SurveyConfigurations : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.ToTable("Encuesta");

            builder.Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnName("Titulo");
            builder.Property(s => s.Description)
                    .IsRequired()
                    .HasColumnName("Descripcion")
                    .HasMaxLength(500);
            builder.Property(s => s.IsActive)
                .IsRequired()
                .HasColumnName("Estado");
            builder.Property(s => s.Validity)
                    .HasColumnName("Vigencia");                
            builder.Property(s => s.CreatedAt)
                   .HasColumnName("FechaCreacion");
            builder.Property(s => s.UpdatedAt)
                    .HasColumnName("FechaActualizacion");
      
        }
    }
}
