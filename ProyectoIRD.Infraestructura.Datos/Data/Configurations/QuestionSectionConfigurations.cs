using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Infraestructura.Datos.Data.Configurations
{
    public class QuestionSectionConfigurations : IEntityTypeConfiguration<QuestionSection>
    {
        public void Configure(EntityTypeBuilder<QuestionSection> builder)
        {
            builder.ToTable("SeccionPregunta");
            builder.Property(x => x.Description)
                    .IsRequired()
                    .HasColumnName("Descripcion")
                    .HasMaxLength(100);
            builder.HasIndex("Description", "SurveyId").IsUnique();
            builder.Property(x => x.SurveyId)
                    .IsRequired()
                    .HasColumnName("EncuestaId");
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
