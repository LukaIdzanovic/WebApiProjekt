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
        public async Task<IActionResult> GetMedicByIdAsync(int id)
        {
            try
            {
                Medic medic = new Medic();
                medic = await service.GetMedicByIdAsync(id);
                return Ok(medic);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("RestMedic/{id}", Name = "RestMedic")]
        public async Task<IActionResult> RestMedicAsync(int id)
        {
            try
            {
                int number = 0;
                number = await service.RestMedicAsync(id);
                return Ok(number);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("HealPatient", Name = "HealPatient")]
        public async Task<IActionResult> HealPatientAsync(int PatientId)
        {
            try
            {
                int number = 0;
                number = await service.HealPatientAsync(PatientId);
                return Ok(number);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPost("AddMedic", Name = "AddMedic")]
        public async Task<IActionResult> AddMedicAsync(Medic medic)
        {
            try
            {
                int number = 0;
                number = await service.AddMedicAsync(medic);
                return Ok(number);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ReturnFromVacation/{id}", Name = "ReturnFromVacation")]
        public async Task<IActionResult> RetrunFromVacationAsync(int id)
        {
            try
            {
                int number = 0;
                number = await service.ReturnFromVacationAsync(id);
                return Ok(number);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
