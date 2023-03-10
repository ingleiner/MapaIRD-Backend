using ProyectoIRD.Dominio.Entities.Surveys;

namespace ProyectoIRD.Dominio.Interfaces.ISurveys
{
    /// <summary>
    /// Repositorio que implementa procedimiento de gestion de información sobre 
    /// la entidad Encuesta, ajenos a los del Repositorio Base
    /// </summary>
    public interface ISurveyRepository : IBaseRepository<Survey>
    {
        /// <summary>
        /// Obtener los datos completos relaciondos con una Encuesta
        /// (Secciones, Preguntas y Posibles Respuestas)
        /// </summary>
        /// <param name="surveyId"></param>
        /// <returns></returns>

        Task<Survey> GetFullSurveyById(Guid surveyId);
    }
}
