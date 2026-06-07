using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Store.ModelsFromDataBase;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        public static List<Patient> patients;

        private const string connectionString = "Host = localhost;" + 
                                                "Username = postgres;" +
                                                "Password = 5432;" +
                                                "Port = 5432;" +
                                                "Database = DataBaseFromModel";

        static PatientController()
        {
            patients = PatientsData.patients;
        }

        [HttpGet("All", Name = "GetAllPatients")]
        public IActionResult GetAllPatients(string? name, string? sex, string? diseaseType)
        {
            try
            {
                List<Patient> patients = new List<Patient>();

                using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                string commandText = "SELECT * FROM \"Patient\" WHERE 1=1";
                if (!string.IsNullOrEmpty(name))
                    commandText += " AND \"Name\" = @Name";
                else if (!string.IsNullOrEmpty(sex))
                    commandText += " AND \"Sex\" = @Sex";
                else if (!string.IsNullOrEmpty(diseaseType))
                    commandText += " AND \"DiseaseType\" = @DiseaseType";

                using NpgsqlCommand command = new NpgsqlCommand(commandText, connection);
                if (!string.IsNullOrEmpty(name))
                {
                    command.Parameters.AddWithValue("Name", name);
                }
                if (!string.IsNullOrEmpty(sex))
                {
                    command.Parameters.AddWithValue("Sex", sex);
                }
                if (!string.IsNullOrEmpty(diseaseType))
                {
                    command.Parameters.AddWithValue("DiseaseType", diseaseType);
                }

                connection.Open();
                using NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Patient patient = new Patient();
                    patient.IdPatient = Convert.ToInt32(reader[0]);
                    patient.Name = reader[1].ToString();
                    patient.DiseaseType = reader[2].ToString();
                    patient.Sex = reader[3].ToString();
                    patient.IdMedic = Convert.ToInt32(reader[4]);
                    patients.Add(patient);
                }
                connection.Close();

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
                using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                string commandText = "SELECT * FROM \"Patient\" WHERE \"IdPatient\" = @IdPatient";
                using NpgsqlCommand command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("IdPatient", id);

                Patient patient = new Patient();
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) 
                {
                    patient.IdPatient = Convert.ToInt32(reader[0]);
                    patient.Name = Convert.ToString(reader[1]);
                    patient.DiseaseType = reader[2].ToString();
                    patient.Sex = reader[3].ToString();
                    patient.IdMedic = Convert.ToInt32(reader[4]);
                }
                connection.Close();

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
                using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                string commandText = "UPDATE \"Patient\" SET \"Name\" = @Name, \"DiseaseType\" = @DiseaseType, \"Sex\" = @Sex, \"IdMedic\"=@IdMedic WHERE  \"IdPatient\" = @IdPatient";
                using NpgsqlCommand command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("IdPatient", goalPatient.IdPatient);
                command.Parameters.AddWithValue("Name", goalPatient.Name);
                command.Parameters.AddWithValue("DiseaseType", goalPatient.DiseaseType);
                command.Parameters.AddWithValue("Sex", goalPatient.Sex);
                command.Parameters.AddWithValue("IdMedic", goalPatient.IdMedic);

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

        [HttpPost("AddPatient", Name = "AddPatient")]
        public IActionResult AddPatient(Patient patient)
        {
            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                string commandText = "INSERT INTO \"Patient\" (\"IdPatient\", \"Name\", \"DiseaseType\", \"Sex\", \"IdMedic\") VALUES (@IdPatient, @Name, @DiseaseType, @Sex, @IdMedic)";
                using NpgsqlCommand command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("IdPatient", patient.IdPatient);
                command.Parameters.AddWithValue("Name", patient.Name);
                command.Parameters.AddWithValue("DiseaseType", patient.DiseaseType);
                command.Parameters.AddWithValue("Sex", patient.Sex);
                command.Parameters.AddWithValue("IdMedic", patient.IdMedic);

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

        [HttpDelete("DeletePatient/{id}", Name = "DeletePatient")]
        public IActionResult DeletePatient(int id)
        {
            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                string commandText = "DELETE FROM \"Patient\" WHERE \"IdPatient\" = @IdPatient";
                using NpgsqlCommand command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("IdPatient", id);
         
                connection.Open();
                int number = command.ExecuteNonQuery();
                connection.Close();

                return Ok(number);
            }
            catch(Exception ex )
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
