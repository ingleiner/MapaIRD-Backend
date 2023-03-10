using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoIRD.Dominio.Entities;
using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Entities.Users;
using ProyectoIRD.Dominio.Interfaces;
using ProyectoIRD.Infraestructura.Datos.Data.Configurations;
using System.Reflection;

namespace ProyectoIRD.Infraestructura.Datos.Data
{
    public class MapaIRDContext: IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
                                UsersRoles, IdentityUserLogin<string>, IdentityRoleClaim<string>,
                                IdentityUserToken<string>>
    {
       

        public MapaIRDContext(DbContextOptions<MapaIRDContext> options): base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }  
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<QuestionSection> QuestionSections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Forma de agregar una por una las config de las entidades
            //modelBuilder.ApplyConfiguration(new EmployeeConfigurations());

            //Agregar todas las configuraciones de las entidades 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
