using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Enums;
using ProyectoIRD.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Infraestructura.Datos.Data.Configurations
{
    public class QuiestionConfigurations : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Pregunta");
            builder.Property(q => q.Description)
                    .IsRequired()
                    .HasColumnName("Descripcion")
                    .HasMaxLength(500);
            builder.Property(q => q.QuestionSectionId)
                    .IsRequired()
                    .HasColumnName("SeccionPreguntaId");
            builder.Property(q => q.CreatedAt)
                   .HasColumnName("FechaCreacion");
            builder.Property(q => q.Order)
                    .IsRequired()
                    .HasColumnName("Orden");
            builder.Property(q => q.UpdatedAt)
                    .HasColumnName("FechaActualizacion");
            builder.Property(q => q.Item)
                    .IsRequired();
            builder.Property(p => p.QuestionType)
                    .IsRequired()
                    .HasColumnName("TipoPregunta")
                    .HasConversion(
                     v => v.ToString(),
                     v => (QuestionType)Enum.Parse(typeof(QuestionType), v));
        }
    }
}
