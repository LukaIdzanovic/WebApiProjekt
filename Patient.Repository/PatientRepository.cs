using Common;
using Npgsql;
using Store.Models;
using Store.Repository.Common;
using AutoMapper;

namespace Store.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private const string connectionString = "Host = localhost;" +
                                                "Username = postgres;" +
                                                "Password = 5432;" +
                                                "Port = 5432;" +
                                                "Database = DataBaseFromModel";
        public async Task<int> AddPatientAsync(Patient patient)
        {
            await using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            string commandText = "INSERT INTO \"Patient\" (\"IdPatient\", \"Name\", \"DiseaseType\", \"Sex\", \"IdMedic\") VALUES (@IdPatient, @Name, @DiseaseType, @Sex, @IdMedic)";
            await using NpgsqlCommand command = new NpgsqlCommand(commandText, connection);

            command.Parameters.AddWithValue("IdPatient", patient.IdPatient);
            command.Parameters.AddWithValue("Name", patient.Name);
            command.Parameters.AddWithValue("DiseaseType", patient.DiseaseType);
            command.Parameters.AddWithValue("Sex", patient.Sex);
            command.Parameters.AddWithValue("IdMedic", patient.IdMedic);

            connection.Open();
            int number = await command.ExecuteNonQueryAsync();
            connection.Close();

            return number;
        }

        public async Task<int> DeletePatientAsync(int id)
        {
            await using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            string commandText = "DELETE FROM \"Patient\" WHERE \"IdPatient\" = @IdPatient";
            await using NpgsqlCommand command = new NpgsqlCommand(commandText, connection);

            command.Parameters.AddWithValue("IdPatient", id);

            connection.Open();
            int number = await command.ExecuteNonQueryAsync();
            connection.Close();

            return number;
        }

        public async Task<int> SwapPatientAsync(Patient goalPatient)
        {
            await using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            string commandText = "UPDATE \"Patient\" SET \"Name\" = @Name, \"DiseaseType\" = @DiseaseType, \"Sex\" = @Sex, \"IdMedic\"=@IdMedic WHERE  \"IdPatient\" = @IdPatient";
            await using NpgsqlCommand command = new NpgsqlCommand(commandText, connection);

            command.Parameters.AddWithValue("IdPatient", goalPatient.IdPatient);
            command.Parameters.AddWithValue("Name", goalPatient.Name);
            command.Parameters.AddWithValue("DiseaseType", goalPatient.DiseaseType);
            command.Parameters.AddWithValue("Sex", goalPatient.Sex);
            command.Parameters.AddWithValue("IdMedic", goalPatient.IdMedic);

            connection.Open();
            int number = await command.ExecuteNonQueryAsync();
            connection.Close();

            return number;
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {

            await using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            string commandText = "SELECT * FROM \"Patient\" WHERE \"IdPatient\" = @IdPatient";
            await using NpgsqlCommand command = new NpgsqlCommand(commandText, connection);

            command.Parameters.AddWithValue("IdPatient", id);

            Patient patient = new Patient();
            connection.Open();
            NpgsqlDataReader reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
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

        public async Task<List<Patient>> GetAllAsync(PatientFilter filter)
        {
            List<Patient> patients = new List<Patient>();

            await using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            string commandText = "SELECT * FROM \"Patient\" WHERE 1=1";
            if (!string.IsNullOrEmpty(filter.Name))
                commandText += " AND \"Name\" = @Name";
            else if (!string.IsNullOrEmpty(filter.Sex))
                commandText += " AND \"Sex\" = @Sex";
            else if (!string.IsNullOrEmpty(filter.DiseaseType))
                commandText += " AND \"DiseaseType\" = @DiseaseType";

            await using NpgsqlCommand command = new NpgsqlCommand(commandText, connection);
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
            await using NpgsqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
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
