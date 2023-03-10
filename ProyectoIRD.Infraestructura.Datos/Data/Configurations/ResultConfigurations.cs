using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoIRD.Dominio.Entities.Surveys;

namespace ProyectoIRD.Infraestructura.Datos.Data.Configurations
{
    public class ResultConfigurations : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.ToTable("Resultado");
            builder.Property(r => r.Description)
                    .HasMaxLength(300)
                    .HasColumnName("Descripcion");
            builder.Property(r => r.SurveyAplicationId)
                    .IsRequired()
                    .HasColumnName("AplicacionEncuestaId");
            builder.Property(r => r.AnswerId)
                    .HasColumnName("RespuestaId");
            builder.Property(r => r.QuestionId)
                    .IsRequired()
                    .HasColumnName("PreguntaId");
            builder.Property(r => r.CreatedAt)
                .HasColumnName("FechaCreación");
            builder.Property(r => r.UpdatedAt)
                .HasColumnName("FechaActualizacion");
            builder.HasOne(r => r.SurveyAplication)
                   .WithMany(sa => sa.Results)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(r => r.Question)
                    .WithMany(q => q.Results)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
