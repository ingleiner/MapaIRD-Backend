using ProyectoIRD.Aplicaciones.Interfaces.ISurveys;
using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Interfaces.ISurveys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Aplicaciones.Services.Surveys
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWorkSurvey _unitOfWorkSurvey;

        public PatientService(IUnitOfWorkSurvey unitOfWorkSurvey)
        {
            _unitOfWorkSurvey = unitOfWorkSurvey;
        }

        public IEnumerable<Patient> GetPatients()
        {
            return _unitOfWorkSurvey.PatientRepository.GetAll();
        }

        public async Task<Patient> GetPatient(Guid id)
        {
            return await _unitOfWorkSurvey.PatientRepository.GetById(id);
        }

        public async Task<Patient> GetByDocument(string documentId)
        {
            return await _unitOfWorkSurvey.PatientRepository
                                    .GetByDocumentId(documentId);
        }
        public async Task<bool> AddPatient(Patient patient)
        {
            var patientDb = await GetByDocument(patient.DocumentId);
            if (patientDb != null)
            {
                return false;
            }
            await _unitOfWorkSurvey.PatientRepository.Add(patient);
            await _unitOfWorkSurvey.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdatePatient(Patient patient)
        {
            _unitOfWorkSurvey.PatientRepository.Update(patient);
            await _unitOfWorkSurvey.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeletePatient(Guid id)
        {
            await _unitOfWorkSurvey.PatientRepository.Delete(id);
            return true;
        }
    }
}
