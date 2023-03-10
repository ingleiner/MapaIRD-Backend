using Microsoft.EntityFrameworkCore;
using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Interfaces.ISurveys;
using ProyectoIRD.Infraestructura.Datos.Data;

namespace ProyectoIRD.Infraestructura.Datos.Repositories.Surveys
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {

        public PatientRepository(MapaIRDContext context) : base(context)
        {
        }
        public async Task<Patient> GetByDocumentId(string documentId)
        {
            var patient = await _entities.FirstOrDefaultAsync(p => p.DocumentId == documentId);
            return patient!;
        }
    }
}
