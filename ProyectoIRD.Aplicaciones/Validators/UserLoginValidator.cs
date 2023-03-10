using FluentValidation;
using ProyectoIRD.Dominio.DTOs.UserDtos;

namespace ProyectoIRD.Aplicaciones.Validators
{
    public class UserLoginValidator: AbstractValidator<UserLogin>
    {
        public UserLoginValidator()
        {
            RuleFor(ul => ul.Email)
                .NotNull()
                .EmailAddress()
                .NotEmpty()
                .WithMessage("El email es requerido y con un formato correcto"); ;
            RuleFor(ul => ul.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("La contraseña es requerida"); ;
        }
    }
}
