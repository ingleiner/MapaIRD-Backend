using ProyectoIRD.Dominio.Entities.Surveys;

namespace ProyectoIRD.Dominio.Interfaces.ISurveys
{
    /// <summary>
    /// Repositorio que implementa procedimiento de gestion de información sobre 
    /// la entidad Paciente, ajenos a los del Repositorio Base
    /// </summary>
    public interface IPatientRepository : IBaseRepository<Patient>
    {
        /// <summary>
        /// Obtener un paciente en base a su número de documentode identidad
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task<Patient> GetByDocumentId(string documentId);
    }
}
