using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoIRD.Dominio.Entities.Surveys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Infraestructura.Datos.Data.Configurations
{
    public class SurveyAplicationConfiguration : IEntityTypeConfiguration<SurveyAplication>
    {
        public void Configure(EntityTypeBuilder<SurveyAplication> builder)
        {
            builder.ToTable("AplicacionEncuesta");
            builder.Property(sa => sa.PatientId)
                .IsRequired()
                .HasColumnName("PacienteId");
            builder.Property(sa => sa.SurveyId)
                .IsRequired()
                .HasColumnName("EncuestaId");
            builder.Property(sa => sa.CreatedAt)
                .IsRequired()
                .HasColumnName("FechaCreacion");
            builder.Property(sa => sa.UpdatedAt)
                .HasColumnName("FechaActualizacion");
            builder.HasMany(r => r.Results)
                    .WithOne(sa => sa.SurveyAplication)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
