using Common;
using Store.Models;
using Store.Repository;
using Store.Service.Common;

namespace Store.Service
{
    public class PatientService : IPatientService
    {
        PatientRepository repository = new PatientRepository();
            
        public async Task<int> AddPatientAsync(Patient addPatient)
        {
            Patient patient = new Patient();
            patient = addPatient;
            int number = 0;
            if (addPatient != null) { number = await repository.AddPatientAsync(patient); }
            return number;
        }

        public async Task<int> DeletePatientAsync(int id)
        {
            int number = 0;
            number = await repository.DeletePatientAsync(id);
            return number;
        }

        public async Task<int> SwapPatientAsync(Patient patient)
        {
            int number = 0;
            if (patient != null)
            {
                number = await repository.SwapPatientAsync(patient);
            }
            return number;
        }
        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            Patient patient = new Patient();
            patient = await repository.GetPatientByIdAsync(id);
            return patient;
        }

        public async Task<List<Patient>> GetAllAsync(PatientFilter filter)
        {
            List<Patient> patients = new List<Patient>();
            patients = await repository.GetAllAsync(filter);
            return patients;
        }
    }
}
