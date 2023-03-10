using ProyectoIRD.Dominio.Entities.Surveys;

namespace ProyectoIRD.Aplicaciones.Interfaces.ISurveys
{
    public interface ISurveysAplicationService
    {
        /// <summary>
        /// OObtener las suma de los las respuestas para las aplicaciones realizadas a una 
        /// encuesta en un mes específico, agrupandolas por secciónes y preguntas
        /// </summary>
        /// <param name="searchDate"></param>
        /// <param name="surveyId"></param>
        /// <returns></returns>
        Task<List<object>> GetResultsBySectionAndQuestions(DateTime searchDate, Guid surveyId);
        
        /// <summary>
        /// Agregar una aplicación de encuesta junto con las respuestas seleccionadas
        /// por el aplicador
        /// </summary>
        /// <param name="surveyAplication"></param>
        /// <returns></returns>
        Task<bool> AddAplication(SurveyAplication surveyAplication );

        /// <summary>
        /// Obtener la cantidad de aplicaciones para una encuesta en un mes específico
        /// </summary>
        /// <param name="surveyId"></param>
        /// <param name="searchDate"></param>
        /// <returns></returns>
        Task<int> GetCountAplicationSurvey(Guid surveyId, DateTime searchDate);

        /// <summary>
        /// Obtener la última encuesta aplicada
        /// </summary>
        /// <returns></returns>
        Task<SurveyAplication> GetLastSurveyAplication();

    }
}
