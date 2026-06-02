
using System.ComponentModel.DataAnnotations;

namespace Store
{

    public class PatientsData
    {
        public static List<Patient> patients = new List<Patient>()
        {
            new Patient { Id = 1, Name = "Mirko", DiseaseType = "Upala", Sex="Musko"},
            new Patient { Id = 2, Name = "Marko", DiseaseType = "Bol", Sex="Musko" },
            new Patient { Id = 3, Name = "Željko", DiseaseType = "Upala", Sex="Musko" },
            new Patient { Id = 4, Name = "Goran", DiseaseType = "Bol", Sex = "Musko"},
            new Patient { Id = 5, Name = "Gordan", DiseaseType = "Upala", Sex = "Musko"},
            new Patient { Id = 6, Name = "Filip", DiseaseType = "Bol", Sex = "Musko"},
            new Patient { Id = 7, Name = "Ana", DiseaseType = "Upala", Sex = "Zensko"},
            new Patient { Id = 8, Name = "Marija", DiseaseType = "Upala", Sex = "Zensko"},
        };
    }
}