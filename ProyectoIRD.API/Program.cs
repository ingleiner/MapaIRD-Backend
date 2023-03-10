using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProyectoIRD.Aplicaciones.Interfaces;
using ProyectoIRD.Aplicaciones.Interfaces.ISurveys;
using ProyectoIRD.Aplicaciones.Interfaces.IUsers;
using ProyectoIRD.Aplicaciones.Services;
using ProyectoIRD.Aplicaciones.Services.Surveys;
using ProyectoIRD.Aplicaciones.Services.Users;
using ProyectoIRD.Aplicaciones.Validators;
using ProyectoIRD.Dominio.Entities.Users;
using ProyectoIRD.Dominio.Interfaces;
using ProyectoIRD.Dominio.Interfaces.ISurveys;
using ProyectoIRD.Dominio.Interfaces.IUsers;
using ProyectoIRD.Infraestructura.Datos.Data;
using ProyectoIRD.Infraestructura.Datos.Filters;
using ProyectoIRD.Infraestructura.Datos.Repositories;
using ProyectoIRD.Infraestructura.Datos.Repositories.Surveys;
using ProyectoIRD.Infraestructura.Datos.Repositories.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddResponseCaching();

builder.Services.AddDbContext<MapaIRDContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MapaIRDconnection")));

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    // Ignorar referencias circulares entre entidades
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

// Repositorios
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAccountUserRepository, AccountUserRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

//Unidad de trabajo que contiene acceso a los repositorios del módulo Encuesta
builder.Services.AddScoped<IUnitOfWorkSurvey, UnitOfWorkSurvey>();

// Repositorio genérico que contiene operaciones CRUD
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

//Servicios que contienen la lógica de negocio
builder.Services.AddTransient<SeedDb>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAccountUserService, AccountUserService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISurveyService, SurveyService>();
builder.Services.AddScoped<IQSectionService, QSectionService>();
builder.Services.AddScoped<IAnswerService, AnswerService>();
builder.Services.AddScoped<IResultService, ResultService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<ISurveysAplicationService, SurveyAplicationService>();

builder.Services.AddMvc(options =>
{
    // Agregar filtros a nivel de aplicación (en vez de ApiController)
    options.Filters.Add<ValidationFilter>();
});
//Validaciones de propiedades de DTOs
builder.Services.AddValidatorsFromAssemblyContaining<EmployeeValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UserLoginValidator>();
//builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//TODO: Cambiar configutación de password
builder.Services.AddIdentity<User, Role>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
        })
        .AddEntityFrameworkStores<MapaIRDContext>()
        .AddDefaultTokenProviders();

builder.Services.AddCors(options => {
    options.AddDefaultPolicy( builder =>
        builder.WithOrigins("https://www.apirequest.io", "http://localhost:4200").AllowAnyMethod().AllowAnyHeader().WithExposedHeaders());
});

builder.Services
    .AddHttpContextAccessor()
    .AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        //ValidAudience = builder.Configuration["Authentication:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SecretKey"])),
        ClockSkew = TimeSpan.Zero
    };

});
//Agregar políticas de autorización basadas en Claims para diferentes Roles
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("EsAdmin", policy =>  policy.RequireClaim("Admin"));
});
//Limpiar mapeo automático de algunos tipos de Claims de JWT
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

var app = builder.Build();

// Crear un usuario con rol de Admin luedo de crear la BD
SeedData(app);

void SeedData(WebApplication app)
{
    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope? scope = scopedFactory.CreateScope())
    {
        SeedDb? service = scope.ServiceProvider.GetService<SeedDb>();
        service.SeedAsync().Wait();
    }

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseResponseCaching();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
