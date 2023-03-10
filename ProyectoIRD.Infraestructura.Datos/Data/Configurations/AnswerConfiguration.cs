using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Utils;

namespace ProyectoIRD.Infraestructura.Datos.Data.Configurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("Respuesta");
            builder.Property(a => a.Description)
                .IsRequired()
                .HasColumnName("Descripcion")
                .HasMaxLength(500);
            builder.Property(a => a.QuestionId)
                    .IsRequired()
                    .HasColumnName("PreguntaId");
            builder.Property(a => a.Order)
                    .IsRequired()
                    .HasColumnName("Orden");
            builder.Property(a => a.CreatedAt)
                   .HasColumnName("FechaCreacion");
            builder.Property(a => a.UpdatedAt)
                    .HasColumnName("FechaActualizacion");

        }
    }
}
