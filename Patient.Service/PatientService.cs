using AutoMapper;
using Common;
using Store.Models;
using Store.Repository;
using Store.Repository.Common;
using Store.Service.Common;

namespace Store.Service
{
    public class PatientService : IPatientService
    {
        private IPatientRepository Repository { get; set; }
        public PatientService(IPatientRepository repository)
        {
            Repository = repository;
        }
            
        public async Task<int> AddPatientAsync(Patient addPatient)
        {
            Patient patient = new Patient();
            patient = addPatient;
            int number = 0;
            if (addPatient.Name == null && addPatient.DiseaseType == null && addPatient.Sex == null) { number = 0; }
            else { return await Repository.AddPatientAsync(patient); ; }
                return number;
        }

        public async Task<int> DeletePatientAsync(int id)
        {
            int number = 0;
            number = await Repository.DeletePatientAsync(id);
            return number;
        }

        public async Task<int> SwapPatientAsync(Patient patient)
        {
            int number = 0;
            if (patient != null)
            {
                number = await Repository.SwapPatientAsync(patient);
            }
            return number;
        }
        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            Patient patient = new Patient();
            patient = await Repository.GetPatientByIdAsync(id);
            return patient;
        }

        public async Task<List<Patient>> GetAllAsync(PatientFilter filter)
        {
            List<Patient> patients = new List<Patient>();
            patients = await Repository.GetAllAsync(filter);
            return patients;
        }
    }
}
