using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        public static List<Patient> patients;

        static PatientController()
        {
            patients = PatientsData.patients;
        }

        [HttpGet("All", Name = "GetAllPatients")]
        public IActionResult GetAllPatients(string? name, string? sex, string? type)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return Ok(patients.Where(x => x.Name == name).ToList());
            }
            else if (!string.IsNullOrEmpty(sex))
            {
                return Ok(patients.Where(x => x.Sex == sex).ToList());
            }
            else if (!string.IsNullOrEmpty(type))
            {
                return Ok(patients.Where(x => x.DiseaseType == type).ToList());
            }
            else 
            { 
                return Ok(patients);
            }
        }

        [HttpGet("{id}", Name = "GetPatientById")]
        public IActionResult GetPatientById(int id)
        {
            if(patients.Find(x => x.Id == id) == null)
            {
                return NotFound("Nema tog pacijenta");
            }
            return Ok(patients.Find(x => x.Id == id));
        }

        [HttpPut("Swap/{id}", Name = "SwapPatient")]
        public IActionResult SwapPatient(int id, Patient goalPatient)
        {
            if (patients.Find(x => x.Id == id) == null)
            {
                return NotFound("Nema tog pacijenta");
            }
            Patient patient = patients.Find(x => x.Id == id);
            patient.Name = goalPatient.Name;
            patient.Sex = goalPatient.Sex;
            patient.DiseaseType = goalPatient.DiseaseType;

            return Ok(patient);
        }

        [HttpPost("AddPatient", Name = "AddPatient")]
        public IActionResult AddPatient(Patient patient)
        {
            patients.Add(patient);
            return Ok(patients);
        }


        [HttpDelete("DeletePatient/{id}", Name = "DeletePatient")]
        public IActionResult DeletePatient(int id)
        {
            if (patients.Exists(x => x.Id == id)){
                return Ok(patients.Remove(patients.Find(x => x.Id == id)));
            }
            else
            {
                return NotFound("Nema tog pacijenta");
            }
        }
    }
}
