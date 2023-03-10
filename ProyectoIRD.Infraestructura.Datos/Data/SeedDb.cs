using Microsoft.AspNetCore.Identity;
using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Entities.Users;
using ProyectoIRD.Dominio.Enums;
using ProyectoIRD.Dominio.Utils;

namespace ProyectoIRD.Infraestructura.Datos.Data
{
    public class SeedDb
    {
        private readonly MapaIRDContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public SeedDb(MapaIRDContext context,
                      UserManager<User> userManager,
                      RoleManager<Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        /// <summary>
        /// Procedimiento para crear un usuario Administrador en el sistema 
        /// Luego de 
        /// </summary>
        /// <returns></returns>
        /// 
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CreateAdminUser();
            await CreatinSurvey();
        }
        public async Task CreateAdminUser()
        {
            var user = new User
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                FirstName = "Leiner",
                LastName = "Solano",
                JobArea = "TICS",
                JobTitle ="Ingeniero de Sistemas",
                PhoneNumber = "3043560784",
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,

            };
            var role = new Role
            {
                Name = "Admin"
            };

            var result = await _userManager.CreateAsync(user, "ab123456");

            if (result.Succeeded)
            {

                var roleResult = await _roleManager.CreateAsync(role);

                if (roleResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                }
            }
        }

        public async Task CreatinSurvey()
        {
            if (!_context.Surveys.Any())
            {
                var user = await _userManager.FindByEmailAsync("admin@gmail.com");

                var survey = new Survey
                {
                    Title = "ENCUESTA DE SATISFACION A NUESTROS CLIENTES EXTERNO O USUARIOS",
                    Description = "Medir el grado de satifacción de nuestros usuarios, en relación con los servicios prestados",
                    UserId = user.Id,
                    CreatedAt = Utils.DateNow(),
                    UpdatedAt = Utils.DateNow(),
                    Version = 1,
                    Validity = DateTime.Now,
                    IsActive = true,
                    QuestionSections = new List<QuestionSection>
                {
                    new QuestionSection
                    {
                        Description = "Atención en Facuración",
                        CreatedAt = Utils.DateNow(),
                        UpdatedAt = Utils.DateNow(),
                        UserId = user.Id,
                        Order =+ 1,
                        Questions = new List<Question>
                        {
                            new Question
                            {
                                Description = "La oportunidad con que le atendieron fue...?",
                                QuestionType = QuestionType.RespuestaUnica,
                                CreatedAt = Utils.DateNow(),
                                UpdatedAt = Utils.DateNow(),
                                UserId = user.Id,
                                Order =+ 1,
                                Item = "Oportunidad",
                                Answers = new List<Answer>
                                {
                                    new Answer
                                    {
                                        Description = "Excelente",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 1,
                                    },
                                    new Answer
                                    {
                                        Description = "Bueno",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 2,
                                    },
                                    new Answer
                                    {
                                        Description = "Regular",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 3,
                                    },
                                    new Answer
                                    {
                                        Description = "Malo",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 4,
                                    }
                                }

                            },
                            new Question
                            {
                                Description = "El trato recibido por parte de nuestro personal fue...?",
                                QuestionType = QuestionType.RespuestaUnica,
                                CreatedAt = Utils.DateNow(),
                                UpdatedAt = Utils.DateNow(),
                                UserId = user.Id,
                                Order = + 2,
                                Item = "Trato",
                                Answers = new List<Answer>
                                {
                                    new Answer
                                    {
                                        Description = "Excelente",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 1,
                                    },
                                    new Answer
                                    {
                                        Description = "Bueno",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 2,
                                    },
                                    new Answer
                                    {
                                        Description = "Regular",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 3
                                    },
                                    new Answer
                                    {
                                        Description = "Malo",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 4
                                    }
                                }

                            },
                            new Question
                            {
                                Description = "La información suministrada fue...?",
                                QuestionType = QuestionType.RespuestaUnica,
                                CreatedAt = Utils.DateNow(),
                                UpdatedAt = Utils.DateNow(),
                                UserId = user.Id,
                                Order =+ 3,
                                Item = "Información",
                                Answers = new List<Answer>
                                {
                                    new Answer
                                    {
                                        Description = "Excelente",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 1
                                    },
                                    new Answer
                                    {
                                        Description = "Bueno",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 2
                                    },
                                    new Answer
                                    {
                                        Description = "Regular",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 3
                                    },
                                    new Answer
                                    {
                                        Description = "Malo",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 4
                                    }
                                }

                            },
                        }

                    },
                    new QuestionSection
                    {
                        Description = "Atención Médica",
                        CreatedAt = Utils.DateNow(),
                        UpdatedAt = Utils.DateNow(),
                        UserId = user.Id,
                        Order =+ 2,
                        Questions = new List<Question>
                        {
                            new Question
                            {
                                Description = "La oportunidad en el servicio prestado por parte del profesional médico fue...?",
                                QuestionType = QuestionType.RespuestaUnica,
                                CreatedAt = Utils.DateNow(),
                                UpdatedAt = Utils.DateNow(),
                                UserId = user.Id,
                                Order =+ 1,
                                Item = "Oportunidad",
                                Answers = new List<Answer>
                                {
                                    new Answer
                                    {
                                        Description = "Excelente",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 1,
                                    },
                                    new Answer
                                    {
                                        Description = "Bueno",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 2,
                                    },
                                    new Answer
                                    {
                                        Description = "Regular",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 3,
                                    },
                                    new Answer
                                    {
                                        Description = "Malo",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 4,
                                    }
                                }

                            },
                            new Question
                            {
                                Description = "La atención sumistrada parte del profesional médico fue...?",
                                QuestionType = QuestionType.RespuestaUnica,
                                CreatedAt = Utils.DateNow(),
                                UpdatedAt = Utils.DateNow(),
                                UserId = user.Id,
                                Order =+ 2,
                                Item = "Atención",
                                Answers = new List<Answer>
                                {
                                    new Answer
                                    {
                                        Description = "Excelente",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 1,
                                    },
                                    new Answer
                                    {
                                        Description = "Bueno",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 2,
                                    },
                                    new Answer
                                    {
                                        Description = "Regular",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 3,
                                    },
                                    new Answer
                                    {
                                        Description = "Malo",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 4,

                                    }
                                }

                            },
                            new Question
                            {
                                Description = "El trato recibido por parte del profesional médico fue...?",
                                QuestionType = QuestionType.RespuestaUnica,
                                CreatedAt = Utils.DateNow(),
                                UpdatedAt = Utils.DateNow(),
                                UserId = user.Id,
                                Order =+ 3,
                                Item = "Trato",
                                Answers = new List<Answer>
                                {
                                    new Answer
                                    {
                                        Description = "Excelente",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 1,
                                    },
                                    new Answer
                                    {
                                        Description = "Bueno",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 2,
                                    },
                                    new Answer
                                    {
                                        Description = "Regular",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 3,
                                    },
                                    new Answer
                                    {
                                        Description = "Malo",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 4,
                                    }
                                }

                            },
                        }
                    },
                    new QuestionSection
                    {
                        Description = "Atención de Técnicos Auxiliares",
                        CreatedAt = Utils.DateNow(),
                        UpdatedAt = Utils.DateNow(),
                        UserId = user.Id,
                        Order =+ 3,
                        Questions = new List<Question>
                        {
                            new Question
                            {
                                Description = "La oportunidad en el servicio fue...?",
                                QuestionType = QuestionType.RespuestaUnica,
                                CreatedAt = Utils.DateNow(),
                                UpdatedAt = Utils.DateNow(),
                                UserId = user.Id,
                                Order =+ 1,
                                Item = "Oportunidad",
                                Answers = new List<Answer>
                                {
                                    new Answer
                                    {
                                        Description = "Excelente",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 1,
                                    },
                                    new Answer
                                    {
                                        Description = "Bueno",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 2,
                                    },
                                    new Answer
                                    {
                                        Description = "Regular",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 3,
                                    },
                                    new Answer
                                    {
                                        Description = "Malo",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 4,
                                    }
                                }

                            },
                            new Question
                            {
                                Description = "La información suministrada por nuestro personal técnico fue...?",
                                QuestionType = QuestionType.RespuestaUnica,
                                CreatedAt = Utils.DateNow(),
                                UpdatedAt = Utils.DateNow(),
                                UserId = user.Id,
                                Order =+ 2,
                                Item = "Información",
                                Answers = new List<Answer>
                                {
                                    new Answer
                                    {
                                        Description = "Excelente",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 1,
                                    },
                                    new Answer
                                    {
                                        Description = "Bueno",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 2,
                                    },
                                    new Answer
                                    {
                                        Description = "Regular",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 3,
                                    },
                                    new Answer
                                    {
                                        Description = "Malo",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 4,
                                    }
                                }

                            },
                            new Question
                            {
                                Description = "El trato recibido por parte del personal técnico auxiliar fue...?",
                                QuestionType = QuestionType.RespuestaUnica,
                                CreatedAt = Utils.DateNow(),
                                UpdatedAt = Utils.DateNow(),
                                UserId = user.Id,
                                Order =+ 3,
                                Item = "Trato",
                                Answers = new List<Answer>
                                {
                                    new Answer
                                    {
                                        Description = "Excelente",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 1
                                    },
                                    new Answer
                                    {
                                        Description = "Bueno",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 2,
                                    },
                                    new Answer
                                    {
                                        Description = "Regular",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 3,
                                    },
                                    new Answer
                                    {
                                        Description = "Malo",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 4,
                                    }
                                }

                            },
                        }
                    },
                    new QuestionSection
                    {
                        Description = "Servicios Generales",
                        CreatedAt = Utils.DateNow(),
                        UpdatedAt = Utils.DateNow(),
                        UserId = user.Id,
                        Order =+ 4,
                        Questions = new List<Question>
                        {
                            new Question
                            {
                                Description = "¿Cómo califica el aseo en las instalaciones?",
                                QuestionType = QuestionType.RespuestaUnica,
                                CreatedAt = Utils.DateNow(),
                                UpdatedAt = Utils.DateNow(),
                                UserId = user.Id,
                                Order =+ 1,
                                Item = "Aseo en Istalaciones",
                                Answers = new List<Answer>
                                {
                                    new Answer
                                    {
                                        Description = "Excelente",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 1,
                                    },
                                    new Answer
                                    {
                                        Description = "Bueno",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 2,
                                    },
                                    new Answer
                                    {
                                        Description = "Regular",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 3,
                                    },
                                    new Answer
                                    {
                                        Description = "Malo",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 4,
                                    }
                                }

                            },
                            new Question
                            {
                                Description = "¿Cómo califica la atención en portería?",
                                QuestionType = QuestionType.RespuestaUnica,
                                CreatedAt = Utils.DateNow(),
                                UpdatedAt = Utils.DateNow(),
                                UserId = user.Id,
                                Order =+ 2,
                                Item = "Portería",
                                Answers = new List<Answer>
                                {
                                    new Answer
                                    {
                                        Description = "Excelente",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 1,
                                    },
                                    new Answer
                                    {
                                        Description = "Bueno",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 2,
                                    },
                                    new Answer
                                    {
                                        Description = "Regular",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 3,
                                    },
                                    new Answer
                                    {
                                        Description = "Malo",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 4,
                                    }
                                }

                            },
                        }
                    },
                    new QuestionSection
                    {
                        Description = "Seguridad del Paciente",
                        CreatedAt = Utils.DateNow(),
                        UpdatedAt = Utils.DateNow(),
                        UserId = user.Id,
                        Order =+ 5,
                        Questions = new List<Question>
                        {
                            new Question
                            {
                                Description = "¿Cómo califica las condiciones de seguridad para el paciente en las instalaciones?",
                                QuestionType = QuestionType.RespuestaUnica,
                                CreatedAt = Utils.DateNow(),
                                UpdatedAt = Utils.DateNow(),
                                UserId = user.Id,
                                Order =+ 1,
                                Item = "Condiciones de Seguridad",
                                Answers = new List<Answer>
                                {
                                    new Answer
                                    {
                                        Description = "Excelente",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 1,
                                    },
                                    new Answer
                                    {
                                        Description = "Bueno",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 2,
                                    },
                                    new Answer
                                    {
                                        Description = "Regular",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 3,
                                    },
                                    new Answer
                                    {
                                        Description = "Malo",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 4,
                                    }
                                }

                            },
                            new Question
                            {
                                Description = "¿Las medidas de seguridad en la atención fueron...?",
                                QuestionType = QuestionType.RespuestaUnica,
                                CreatedAt = Utils.DateNow(),
                                UpdatedAt = Utils.DateNow(),
                                UserId = user.Id,
                                Order =+ 2,
                                Item = "Medidas de Seguridad",
                                Answers = new List<Answer>
                                {
                                    new Answer
                                    {
                                        Description = "Excelente",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 1,
                                    },
                                    new Answer
                                    {
                                        Description = "Bueno",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 2,
                                    },
                                    new Answer
                                    {
                                        Description = "Regular",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 3,
                                    },
                                    new Answer
                                    {
                                        Description = "Malo",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 4,
                                    }
                                }

                            },
                        }
                    },
                    new QuestionSection
                    {
                        Description = "Calificación General",
                        CreatedAt = Utils.DateNow(),
                        UpdatedAt = Utils.DateNow(),
                        UserId = user.Id,
                        Order =+ 6,
                        Questions = new List<Question>
                        {
                            new Question
                            {
                                Description = "¿Recomendaría a sus familiares y sus amigos esta IPS?",
                                QuestionType = QuestionType.RespuestaUnica,
                                CreatedAt = Utils.DateNow(),
                                UpdatedAt = Utils.DateNow(),
                                UserId = user.Id,
                                Order =+ 1,
                                Item = "Recomendación IPS",
                                Answers = new List<Answer>
                                {
                                    new Answer
                                    {
                                        Description = "Definitivamente Si",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 1,
                                    },
                                    new Answer
                                    {
                                        Description = "Probablemente Si",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 2,
                                    },
                                    new Answer
                                    {
                                        Description = "Probablemente No",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 3,
                                    },
                                    new Answer
                                    {
                                        Description = "Definitivamente No",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 4,
                                    }
                                }

                            },
                            new Question
                            {
                                Description = "¿Cómo califica su expectativa global respecto a los servicios de salud que ha recibido a través de la IPS?",
                                QuestionType = QuestionType.RespuestaUnica,
                                CreatedAt = Utils.DateNow(),
                                UpdatedAt = Utils.DateNow(),
                                UserId = user.Id,
                                Order =+ 2,
                                Item = "Calificación General",
                                Answers = new List<Answer>
                                {
                                    new Answer
                                    {
                                        Description = "Excelente",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 1,
                                    },
                                    new Answer
                                    {
                                        Description = "Bueno",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 2,
                                    },
                                    new Answer
                                    {
                                        Description = "Regular",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 3,
                                    },
                                    new Answer
                                    {
                                        Description = "Malo",
                                        CreatedAt = Utils.DateNow(),
                                        UpdatedAt = Utils.DateNow(),
                                        UserId = user.Id,
                                        Order =+ 4,
                                    }
                                }

                            },
                        }
                    },
                }
                };
                _context.Surveys.Add(survey);
                await _context.SaveChangesAsync();
            }
        }
    }
}
