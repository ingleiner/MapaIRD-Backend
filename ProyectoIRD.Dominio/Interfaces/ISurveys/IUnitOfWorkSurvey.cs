using ProyectoIRD.Dominio.Entities.Surveys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Dominio.Interfaces.ISurveys
{
    public interface IUnitOfWorkSurvey : IDisposable
    {
        ISurveyRepository SurveyRepository { get; }
        IBaseRepository<Question> QuestionRepository { get; }
        IBaseRepository<Answer> AnswerRepository { get; }
        IQuestionSectionRepository QSectionRepository { get; }
        IResultRepository ResultRepository { get; }
        IPatientRepository PatientRepository { get; }
        ISurveyAplicationRepository SurveryAplicationRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
