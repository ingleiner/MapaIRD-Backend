using AutoMapper;
using ProyectoIRD.Dominio.DTOs;
using ProyectoIRD.Dominio.DTOs.SurveyDtos;
using ProyectoIRD.Dominio.DTOs.UserDtos;
using ProyectoIRD.Dominio.Entities;
using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Entities.Users;

namespace ProyectoIRD.Infraestructura.Datos.Mappings
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<EmployeeDTO, Employee>().ReverseMap();

            CreateMap<Role, RolDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Survey, SurveyDto>().ReverseMap();
            CreateMap<FullSurveyDto, Survey>().ReverseMap();

            CreateMap<QuestionSection, QSectionDto>().ReverseMap();
            CreateMap<QuestionSection, SectionAndQuestionDto>().ReverseMap();

            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<Question, QuestionAndAnswerDto>().ReverseMap();

            CreateMap<Answer, AnswerDto>().ReverseMap();
            CreateMap<Answer, SingleAnswerDto>().ReverseMap();

            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<Result, ResultDto>().ReverseMap();
            CreateMap<SurveyAplication, SurveyAplicationDto>().ReverseMap();
        }
    }
}
