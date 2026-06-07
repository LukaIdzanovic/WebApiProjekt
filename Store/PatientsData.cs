
using System.ComponentModel.DataAnnotations;

namespace Store
{

    public class PatientsData
    {
        public static List<Patient> patients = new List<Patient>()
        {
            new Patient { IdPatient = 1, Name = "Mirko", DiseaseType = "Upala", Sex="Musko"},
            new Patient { IdPatient = 2, Name = "Marko", DiseaseType = "Bol", Sex="Musko" },
            new Patient { IdPatient = 3, Name = "Željko", DiseaseType = "Upala", Sex="Musko" },
            new Patient { IdPatient = 4, Name = "Goran", DiseaseType = "Bol", Sex = "Musko"},
            new Patient { IdPatient = 5, Name = "Gordan", DiseaseType = "Upala", Sex = "Musko"},
            new Patient { IdPatient = 6, Name = "Filip", DiseaseType = "Bol", Sex = "Musko"},
            new Patient { IdPatient = 7, Name = "Ana", DiseaseType = "Upala", Sex = "Zensko"},
            new Patient { IdPatient = 8, Name = "Marija", DiseaseType = "Upala", Sex = "Zensko"},
        };
    }
}