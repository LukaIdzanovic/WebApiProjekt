using Npgsql;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Repository.Common;

namespace Store.Repository
{
    public class MedicRepository : IMedicRepository
    {
        private const string connectionString = "Host = localhost;" +
                                               "Username = postgres;" +
                                               "Password = 5432;" +
                                               "Port = 5432;" +
                                               "Database = DataBaseFromModel";

        public Medic GetMedicById(int id)
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
            return medic;
        }

        public int RestMedic(int id)
        {

            string commandText = "UPDATE \"Medic\" SET \"IsActive\" = false WHERE \"MedicId\" = @IdMedic AND \"IsActive\" = true";
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            using NpgsqlCommand command = new NpgsqlCommand(commandText, connection);

            command.Parameters.AddWithValue("IdMedic", id);
            connection.Open();
            int number = command.ExecuteNonQuery();
            connection.Close();
            return number;

        }

        public int HealPatient(int PatientId)
        {
            string commandText = "UPDATE \"Patient\" SET \"DiseaseType\" = NULL FROM \"Patient\" p INNER JOIN \"Medic\" m ON p.\"IdMedic\" = m.\"MedicId\" WHERE \"Patient\".\"IdPatient\" = p.\"IdPatient\" AND p.\"IdPatient\" = @PatientId AND m.\"IsActive\" = true";
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            using NpgsqlCommand command = new NpgsqlCommand(commandText, connection);

            command.Parameters.AddWithValue("@PatientId", PatientId);
            connection.Open();
            int number = command.ExecuteNonQuery();
            connection.Close();
            return number;
        }

        public int AddMedic(Medic medic)
        {
            string commandText = "INSERT INTO \"Medic\" (\"MedicId\", \"Name\", \"IsActive\") VALUES (@MedicId ,@Name ,@IsActive)";
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            using NpgsqlCommand command = new NpgsqlCommand(commandText, connection);

            command.Parameters.AddWithValue("@MedicId", medic.Id);
            command.Parameters.AddWithValue("@Name", medic.Name);
            command.Parameters.AddWithValue("IsActive", medic.IsActive);

            connection.Open();
            int number = command.ExecuteNonQuery();
            connection.Close();
            return number;
        }

        public int ReturnFromVacation(int id)
        {
            string commandText = "UPDATE \"Medic\" SET \"IsActive\" = true WHERE \"MedicId\" = @IdMedic AND \"IsActive\" = false";
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            using NpgsqlCommand command = new NpgsqlCommand(commandText, connection);

            command.Parameters.AddWithValue("IdMedic", id);
            connection.Open();
            int number = command.ExecuteNonQuery();
            connection.Close();
            return number;
        }
    }
}
