using ProyectoIRD.Dominio.Entities.Surveys;

namespace ProyectoIRD.Aplicaciones.Interfaces.ISurveys
{
    /// <summary>
    /// Interfaz que degine la lógica de negocio sobre la entidad Paciente
    /// 
    /// </summary>
    public interface IPatientService
    {
        IEnumerable<Patient> GetPatients();
        Task<Patient> GetPatient(Guid id);
        Task<bool> AddPatient(Patient patient);
        Task<bool> UpdatePatient(Patient patient);
        Task<bool> DeletePatient(Guid id);
        Task<Patient> GetByDocument(string documentId);
    }
}
