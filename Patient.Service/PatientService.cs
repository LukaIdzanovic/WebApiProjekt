using Common;
using Store.Models;
using Store.Repository;
using Store.Service.Common;

namespace Store.Service
{
    public class PatientService : IPatientService
    {
        PatientRepository repository = new PatientRepository();
            
        public int AddPatient(Patient addPatient)
        {
            Patient patient = new Patient();
            patient = addPatient;
            int number = 0;
            if (addPatient != null) { number = repository.AddPatient(patient); }
            return number;
        }

        public int DeletePatient(int id)
        {
            int number = 0;
            number = repository.DeletePatient(id);
            return number;
        }

        public int SwapPatient(Patient patient)
        {
            int number = 0;
            if (patient != null)
            {
                number = repository.SwapPatient(patient);
            }
            return number;
        }
        public Patient GetPatientById(int id)
        {
            Patient patient = new Patient();
            patient = repository.GetPatientById(id);
            return patient;
        }

        public List<Patient> GetAll(PatientFilter filter)
        {
            List<Patient> patients = new List<Patient>();
            patients = repository.GetAll(filter);
            return patients;
        }
    }
}
