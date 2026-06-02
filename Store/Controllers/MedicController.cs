using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicController : ControllerBase
    {
        public static List<Patient> patients;
        public static Medic medic;

        static MedicController()
        {
            patients = PatientsData.patients;
            medic = new Medic(33, "Kunić");
        }

        [HttpGet("GetMedic", Name = "GetMedic")]
        public IActionResult GetMedic()
        {
            if (medic == null)
            {
                return NotFound("nema doktora...");
            }
            return Ok(medic);
        }

        [HttpPost("RestMedic", Name = "RestMedic")]
        public IActionResult RestMedic()
        {
            if (medic.IsActive == false)
            {
                return BadRequest("Već je na odmoru");
            }
            medic.IsActive = false;
            return Ok(medic);
        }

        [HttpPost("HealPatient/{id}", Name = "HealPatient")]
        public IActionResult HealPatient(int id)
        {
            if (patients.Find(x => x.Id ==id).DiseaseType == null)
            {
                return BadRequest("Već je zdrav");
            }
            return Ok(medic.Heal(id, patients));
        }
    }
}
