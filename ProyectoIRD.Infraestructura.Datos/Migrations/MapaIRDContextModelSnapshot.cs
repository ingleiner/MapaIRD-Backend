﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoIRD.Infraestructura.Datos.Data;

#nullable disable

namespace ProyectoIRD.Infraestructura.Datos.Migrations
{
    [DbContext(typeof(MapaIRDContext))]
    partial class MapaIRDContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RolClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UsuarioClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UsuarioLogin", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UsuarioToken", (string)null);
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaCreacion");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nombres");

                    b.Property<long>("IdentityCard")
                        .HasMaxLength(11)
                        .IsUnicode(true)
                        .HasColumnType("bigint")
                        .HasColumnName("DocumentoIdentidad");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("Activo");

                    b.Property<string>("JobTitle")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Cargo");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Apellidos");

                    b.Property<string>("PersonalPhone")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Celular");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaActualizacíon");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("WorkPhone")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Telefono");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Empleado", (string)null);
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Surveys.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaCreacion");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Descripcion");

                    b.Property<int>("Order")
                        .HasColumnType("int")
                        .HasColumnName("Orden");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PreguntaId");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaActualizacion");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserId");

                    b.ToTable("Respuesta", (string)null);
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Surveys.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaCreación");

                    b.Property<string>("DocumentId")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("DocumentoIdentidad");

                    b.Property<string>("EPS")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nombres");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Apellidos");

                    b.Property<string>("MedicalStudy")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("EstudioMedico");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeDocument")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("TipoDocumento");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaActualizacion");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Paciente", (string)null);
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Surveys.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaCreacion");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Descripcion");

                    b.Property<string>("Item")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int")
                        .HasColumnName("Orden");

                    b.Property<Guid>("QuestionSectionId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("SeccionPreguntaId");

                    b.Property<string>("QuestionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TipoPregunta");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaActualizacion");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionSectionId");

                    b.HasIndex("UserId");

                    b.ToTable("Pregunta", (string)null);
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Surveys.QuestionSection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaCreacion");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Descripcion");

                    b.Property<int>("Order")
                        .HasColumnType("int")
                        .HasColumnName("Orden");

                    b.Property<Guid>("SurveyId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("EncuestaId");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaActualizacion");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.HasIndex("UserId");

                    b.HasIndex("Description", "SurveyId")
                        .IsUnique();

                    b.ToTable("SeccionPregunta", (string)null);
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Surveys.Result", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AnswerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RespuestaId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaCreación");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("Descripcion");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PreguntaId");

                    b.Property<Guid>("SurveyAplicationId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AplicacionEncuestaId");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaActualizacion");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SurveyAplicationId");

                    b.HasIndex("UserId");

                    b.ToTable("Resultado", (string)null);
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Surveys.Survey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaCreacion");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Descripcion");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("Estado");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("Titulo");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaActualizacion");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Validity")
                        .HasColumnType("datetime2")
                        .HasColumnName("Vigencia");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Encuesta", (string)null);
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Surveys.SurveyAplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaCreacion");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PacienteId");

                    b.Property<Guid>("SurveyId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("EncuestaId");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaActualizacion");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("SurveyId");

                    b.HasIndex("UserId");

                    b.ToTable("AplicacionEncuesta", (string)null);
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Users.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Rol", (string)null);
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Users.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("DocumentId")
                        .HasColumnType("bigint");

                    b.Property<string>("DocumentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("JobArea")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Users.UsersRoles", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolUsuario", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("ProyectoIRD.Dominio.Entities.Users.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ProyectoIRD.Dominio.Entities.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProyectoIRD.Dominio.Entities.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ProyectoIRD.Dominio.Entities.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Employee", b =>
                {
                    b.HasOne("ProyectoIRD.Dominio.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Surveys.Answer", b =>
                {
                    b.HasOne("ProyectoIRD.Dominio.Entities.Surveys.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIRD.Dominio.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Surveys.Patient", b =>
                {
                    b.HasOne("ProyectoIRD.Dominio.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Surveys.Question", b =>
                {
                    b.HasOne("ProyectoIRD.Dominio.Entities.Surveys.QuestionSection", "QuestionSection")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIRD.Dominio.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("QuestionSection");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Surveys.QuestionSection", b =>
                {
                    b.HasOne("ProyectoIRD.Dominio.Entities.Surveys.Survey", "Survey")
                        .WithMany("QuestionSections")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIRD.Dominio.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Survey");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Surveys.Result", b =>
                {
                    b.HasOne("ProyectoIRD.Dominio.Entities.Surveys.Answer", "Answer")
                        .WithMany("Results")
                        .HasForeignKey("AnswerId");

                    b.HasOne("ProyectoIRD.Dominio.Entities.Surveys.Question", "Question")
                        .WithMany("Results")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProyectoIRD.Dominio.Entities.Surveys.SurveyAplication", "SurveyAplication")
                        .WithMany("Results")
                        .HasForeignKey("SurveyAplicationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProyectoIRD.Dominio.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Answer");

                    b.Navigation("Question");

                    b.Navigation("SurveyAplication");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Surveys.Survey", b =>
                {
                    b.HasOne("ProyectoIRD.Dominio.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Surveys.SurveyAplication", b =>
                {
                    b.HasOne("ProyectoIRD.Dominio.Entities.Surveys.Patient", "Patient")
                        .WithMany("SurveyAplications")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIRD.Dominio.Entities.Surveys.Survey", "Survey")
                        .WithMany("SurveyAplications")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIRD.Dominio.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Patient");

                    b.Navigation("Survey");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Users.UsersRoles", b =>
                {
                    b.HasOne("ProyectoIRD.Dominio.Entities.Users.Role", "Role")
                        .WithMany("UserRole")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIRD.Dominio.Entities.Users.User", "User")
                        .WithMany("UserRole")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Surveys.Answer", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Surveys.Patient", b =>
                {
                    b.Navigation("SurveyAplications");
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Surveys.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Results");
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Surveys.QuestionSection", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Surveys.Survey", b =>
                {
                    b.Navigation("QuestionSections");

                    b.Navigation("SurveyAplications");
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Surveys.SurveyAplication", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Users.Role", b =>
                {
                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("ProyectoIRD.Dominio.Entities.Users.User", b =>
                {
                    b.Navigation("UserRole");
                });
#pragma warning restore 612, 618
        }
    }
}
