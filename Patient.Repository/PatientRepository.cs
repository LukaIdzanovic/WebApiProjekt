using Common;
using Npgsql;
using Store.Models;
using Store.Repository.Common;
using Store.Repository.Common;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Store.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private const string connectionString = "Host = localhost;" +
                                                "Username = postgres;" +
                                                "Password = 5432;" +
                                                "Port = 5432;" +
                                                "Database = DataBaseFromModel";
        public int AddPatient(Patient patient)
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

            return number;
        }

        public int DeletePatient(int id)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            string commandText = "DELETE FROM \"Patient\" WHERE \"IdPatient\" = @IdPatient";
            using NpgsqlCommand command = new NpgsqlCommand(commandText, connection);

            command.Parameters.AddWithValue("IdPatient", id);

            connection.Open();
            int number = command.ExecuteNonQuery();
            connection.Close();

            return number;
        }

        public int SwapPatient(Patient goalPatient)
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

            return number;
        }

        public Patient GetPatientById(int id)
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

            return patient;

        }

        public List<Patient> GetAll(PatientFilter filter)
        {
            List<Patient> patients = new List<Patient>();

            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            string commandText = "SELECT * FROM \"Patient\" WHERE 1=1";
            if (!string.IsNullOrEmpty(filter.Name))
                commandText += " AND \"Name\" = @Name";
            else if (!string.IsNullOrEmpty(filter.Sex))
                commandText += " AND \"Sex\" = @Sex";
            else if (!string.IsNullOrEmpty(filter.DiseaseType))
                commandText += " AND \"DiseaseType\" = @DiseaseType";

            using NpgsqlCommand command = new NpgsqlCommand(commandText, connection);
            if (!string.IsNullOrEmpty(filter.Name))
            {
                command.Parameters.AddWithValue("Name", filter.Name);
            }
            if (!string.IsNullOrEmpty(filter.Sex))
            {
                command.Parameters.AddWithValue("Sex", filter.Sex);
            }
            if (!string.IsNullOrEmpty(filter.DiseaseType))
            {
                command.Parameters.AddWithValue("DiseaseType", filter.DiseaseType);
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

            return patients;
        }
    }
}
