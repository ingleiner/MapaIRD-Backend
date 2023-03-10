using FluentValidation;
using ProyectoIRD.Dominio.DTOs;

namespace ProyectoIRD.Aplicaciones.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeDTO>
    {
        public EmployeeValidator()
        {
            RuleFor(user => user.IdentityCard)
                .NotEmpty()
                .NotNull()
                .WithMessage("El número de documento es requerido");
            RuleFor(user => user.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Debe ingresar un correo electrónico válido");
            RuleFor(user => user.FirstName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Debe ingresar su nombre");
            RuleFor(user => user.LastName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Debe ingresar al menos un apellido");
            RuleFor(user => user.JobTitle)
                .NotNull()
                .NotEmpty()
                .WithMessage("Debe ingresar su cargo laboral");
        }
    }
}
