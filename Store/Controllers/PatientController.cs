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
        public IActionResult GetAllPatients(PatientFilter filter)
        {
            try
            {
                List<Patient> patients = new List<Patient>();
                patients = service.GetAll(filter);
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}", Name = "GetPatientById")]
        public IActionResult GetPatientById(int id)
        {
            try
            {
                Patient patient = service.GetPatientById(id);
                return Ok(patient);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Swap/{id}", Name = "SwapPatient")]
        public IActionResult SwapPatient(Patient goalPatient)
        {
            try
            {
                int number = 0;
                number = service.SwapPatient(goalPatient);
                return Ok(number);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddPatient", Name = "AddPatient")]
        public IActionResult AddPatient(Patient patient)
        {
            try
            {
                int number = 0;
                number = service.AddPatient(patient);
                return Ok(number);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpDelete("DeletePatient/{id}", Name = "DeletePatient")]
        public IActionResult DeletePatient(int id)
        {
            try
            {
                int number = service.DeletePatient(id);
                return Ok(number);
            }
            catch(Exception ex )
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
