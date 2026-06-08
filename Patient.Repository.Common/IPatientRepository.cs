using Common;
using Common;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Store.Repository.Common
{
    public interface IPatientRepository
    {
        public Task<int> AddPatientAsync(Patient addPatient);
        public Task<int> DeletePatientAsync(int id);
        public Task<int> SwapPatientAsync(Patient patient);
        public Task<Patient> GetPatientByIdAsync(int id);
        public Task<List<Patient>> GetAllAsync(PatientFilter filter);
    }
}
