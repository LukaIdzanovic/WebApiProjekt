using Microsoft.AspNetCore.Mvc;
using Npgsql;

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

        static MedicController()
        {
            patients = PatientsData.patients;
        }

        [HttpGet("{id}", Name = "GetMedic")]
        public IActionResult GetMedicById(int id)
        {
            try
            {
                Medic medic = new Medic();
                string commandText = "SELECT * FROM \"Medic\" WHERE \"MedicId\" = @IdMedic";
                using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                using NpgsqlCommand command = new NpgsqlCommand(commandText, connection);
                command.Parameters.AddWithValue("IdMedic", id);
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    medic.Id = Convert.ToInt32(reader[0]);
                    medic.Name = reader[1].ToString();
                    medic.IsActive = Convert.ToBoolean(reader[2]);
                }
                connection.Close();
                return Ok(medic);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("RestMedic/", Name = "RestMedic")]
        public IActionResult RestMedic(int id)
        {
            try
            {
                string commandText = "UPDATE \"Medic\" SET \"IsActive\" = false WHERE \"MedicId\" = @IdMedic";
                using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                using NpgsqlCommand command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("IdMedic", id);
                connection.Open();
                int number = command.ExecuteNonQuery();
                connection.Close();
                return Ok(number);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("HealPatient", Name = "HealPatient")]
        public IActionResult HealPatient(int PatientId)
        {
            try
            {
                string commandText = "UPDATE \"Patient\" SET \"DiseaseType\" = NULL FROM \"Patient\" p INNER JOIN \"Medic\" m ON p.\"IdMedic\" = m.\"MedicId\" WHERE \"Patient\".\"IdPatient\" = p.\"IdPatient\" AND p.\"IdPatient\" = @PatientId AND m.\"IsActive\" = true";
                using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                using NpgsqlCommand command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("@PatientId", PatientId);
                connection.Open();
                int number = command.ExecuteNonQuery();
                connection.Close();
                return Ok(number);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
