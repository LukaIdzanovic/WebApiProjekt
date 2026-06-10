using AutoMapper;
using Common;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Service.Common;


namespace Store.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private IPatientService Service { get; set; }
        public IMapper Mapper { get; set; }

        public PatientController(IPatientService service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        [HttpGet("All", Name = "GetAllPatients")]
        public async Task<IActionResult> GetAllPatientsAsync(PatientFilter filter)
        {
            try
            {
                List<Patient> patients = new List<Patient>();
                List<PatientDto> patientDtos = new List<PatientDto>();
                patients = await Service.GetAllAsync(filter);
                foreach (Patient p in patients) {
                    PatientDto patientDto = Mapper.Map<PatientDto>(p);
                    patientDtos.Add(patientDto);
                }
                return Ok(patientDtos);
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
                Patient patient = await Service.GetPatientByIdAsync(id);
                PatientDto patientDto = Mapper.Map<PatientDto>(patient);
                return Ok(patientDto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Swap/{id}", Name = "SwapPatient")]
        public async Task<IActionResult> SwapPatientAsync(PatientDto goalPatientDto)
        {
            try
            {
                int number = 0;
                Patient goalPatient = Mapper.Map<Patient>(goalPatientDto);
                number = await Service.SwapPatientAsync(goalPatient);
                return Ok(number);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddPatient", Name = "AddPatient")]
        public async Task<IActionResult> AddPatientAsync(PatientDto patientDto)
        {
            try
            {
                Patient patient = Mapper.Map<Patient>(patientDto);
                int number = 0;
                number = await Service.AddPatientAsync(patient);
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
                int number = await Service.DeletePatientAsync(id);
                return Ok(number);
            }
            catch(Exception ex )
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
