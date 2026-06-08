using Common;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Common
{
    public interface IPatientService
    {
        public Task<int> AddPatientAsync(Patient addPatient);
        public Task<int> DeletePatientAsync(int id);
        public Task<int> SwapPatientAsync(Patient patient);
        public Task<Patient> GetPatientByIdAsync(int id);
        public Task<List<Patient>> GetAllAsync(PatientFilter filter);
    }
}
