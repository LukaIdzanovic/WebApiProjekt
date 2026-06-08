using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Store.Models;
using Store.Repository;
using Store.Service;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using Common;

namespace Store.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        public static List<Patient> patients;
        PatientService service = new PatientService();
        private const string connectionString = "Host = localhost;" + 
                                                "Username = postgres;" +
                                                "Password = 5432;" +
                                                "Port = 5432;" +
                                                "Database = DataBaseFromModel";

        [HttpGet("All", Name = "GetAllPatients")]
        public async Task<IActionResult> GetAllPatientsAsync(PatientFilter filter)
        {
            try
            {
                List<Patient> patients = new List<Patient>();
                patients = await service.GetAllAsync(filter);
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}", Name = "GetPatientById")]
        public async Task<IActionResult> GetPatientByIdAsync(int id)
        {
            try
            {
                Patient patient = await service.GetPatientByIdAsync(id);
                return Ok(patient);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Swap/{id}", Name = "SwapPatient")]
        public async Task<IActionResult> SwapPatientAsync(Patient goalPatient)
        {
            try
            {
                int number = 0;
                number = await service.SwapPatientAsync(goalPatient);
                return Ok(number);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddPatient", Name = "AddPatient")]
        public async Task<IActionResult> AddPatientAsync(Patient patient)
        {
            try
            {
                int number = 0;
                number = await service.AddPatientAsync(patient);
                return Ok(number);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpDelete("DeletePatient/{id}", Name = "DeletePatient")]
        public async Task<IActionResult> DeletePatientAsync(int id)
        {
            try
            {
                int number = await service.DeletePatientAsync(id);
                return Ok(number);
            }
            catch(Exception ex )
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
