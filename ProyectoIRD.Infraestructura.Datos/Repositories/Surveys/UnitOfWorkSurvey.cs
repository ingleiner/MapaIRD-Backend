using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Interfaces;
using ProyectoIRD.Dominio.Interfaces.ISurveys;
using ProyectoIRD.Infraestructura.Datos.Data;

namespace ProyectoIRD.Infraestructura.Datos.Repositories.Surveys
{
    public class UnitOfWorkSurvey : IUnitOfWorkSurvey
    {
        private readonly MapaIRDContext _context;
        private readonly ISurveyRepository _surveyRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IQuestionSectionRepository _qSectionRepository;
        private readonly ResultRepository _resultRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly ISurveyAplicationRepository _surveryAplicationRepository;
        public UnitOfWorkSurvey(MapaIRDContext context)
        {
            _context = context;
        }
        public ISurveyRepository SurveyRepository => _surveyRepository ??
                new SurveyRepository(_context);

        public IPatientRepository PatientRepository => _patientRepository ??
           new PatientRepository(_context);

        public IQuestionRepository QuestionRepository => _questionRepository ??
                new QuestionRepository(_context);

        public IAnswerRepository AnswerRepository => _answerRepository ??
                new AnswerRepository(_context);
        public IQuestionSectionRepository QSectionRepository => _qSectionRepository ??
                new QuestionSectionRepository(_context);

        public IResultRepository ResultRepository => _resultRepository ??
                new ResultRepository(_context);

        public ISurveyAplicationRepository SurveryAplicationRepository => _surveryAplicationRepository ??
                new SurveyAplicationRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
