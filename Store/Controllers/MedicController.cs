using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Store.Models;
using Store.Service;
using Store.Service.Common;

namespace Store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicController : ControllerBase
    {
        private IMedicService Service { get; set; }
        public IMapper Mapper { get; set; }

        public MedicController (IMedicService service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetMedic")]
        public async Task<IActionResult> GetMedicByIdAsync(int id)
        {
            try
            {
                Medic medic = await Service.GetMedicByIdAsync(id);
                MedicDto medicDto = Mapper.Map<MedicDto>(medic);
                return Ok(medicDto);
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
                number = await Service.RestMedicAsync(id);
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
                number = await Service.HealPatientAsync(PatientId);
                return Ok(number);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddMedic", Name = "AddMedic")]
        public async Task<IActionResult> AddMedicAsync(MedicDto medicDto)
        {
            try
            {
                int number = 0;
                Medic medic = Mapper.Map<Medic>(medicDto);
                number = await Service.AddMedicAsync(medic);
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
                number = await Service.ReturnFromVacationAsync(id);
                return Ok(number);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
