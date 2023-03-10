using ProyectoIRD.Dominio.Entities.Surveys;

namespace ProyectoIRD.Aplicaciones.Interfaces.ISurveys
{
    /// <summary>
    /// Interfaz de Servicio que define las reglas de negocio sobrela la 
    /// entidad Seccion de Preguntas
    /// </summary>
    public interface IQSectionService
    {
        IEnumerable<QuestionSection> GetQSections();
        Task<QuestionSection> GetQSection(Guid id);
        Task<bool> AddQSection(QuestionSection qsection);
        Task<bool> UpdateQSection(QuestionSection qsection);
        Task<bool> DeleteQSection(Guid id);

        /// <summary>
        /// Obtener la suma total de las respuestas según su descripción, por sección
        /// Eje: Sección 1
        ///         Exelente: 20
        ///         Bueno   : 10
        ///         Regular : 20
        ///         Malo    : 5
        /// </summary>
        /// <param name="surveyId"></param>
        /// <param name="searchDate"></param>
        /// <returns></returns>
        Task<List<object>> GetGralResultsBySection(Guid surveyId, DateTime searchDate);
    }
}
