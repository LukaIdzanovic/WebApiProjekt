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
        public int AddPatient(Patient addPatient);
        public int DeletePatient(int id);
        public int SwapPatient(Patient patient);
        public Patient GetPatientById(int id);
        public List<Patient> GetAll(PatientFilter filter);
    }
}
