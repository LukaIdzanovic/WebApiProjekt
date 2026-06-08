using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Store.Models;
using Store.Service;

namespace Store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicController : ControllerBase
    {
        public static List<Patient> patients;
        public static Medic medic;

        private const string connectionString = "Host = localhost;" +
                                                "Username = postgres;" +
                                                "Password = 5432;" +
                                                "Port = 5432;" +
                                                "Database = DataBaseFromModel";

        MedicService service = new MedicService();

        [HttpGet("{id}", Name = "GetMedic")]
        public IActionResult GetMedicById(int id)
        {
            try
            {
                Medic medic = new Medic();
                medic = service.GetMedicById(id);
                return Ok(medic);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("RestMedic/{id}", Name = "RestMedic")]
        public IActionResult RestMedic(int id)
        {
            try
            {
                return Ok(service.RestMedic(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("HealPatient", Name = "HealPatient")]
        public IActionResult HealPatient(int PatientId)
        {
            try
            {
                int number = 0;
                number = service.HealPatient(PatientId);
                return Ok(number);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPost("AddMedic", Name = "AddMedic")]
        public IActionResult AddMedic(Medic medic)
        {
            try
            {
                int number = 0;
                number = service.AddMedic(medic);
                return Ok(number);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ReturnFromVacation/{id}", Name = "ReturnFromVacation")]
        public IActionResult RetrunFromVacation(int id)
        {
            try
            {
                return Ok(service.ReturnFromVacation(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
