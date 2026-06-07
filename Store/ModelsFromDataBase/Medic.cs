namespace Store.ModelsFromDataBase
{
    public class Medic
    {
        public int IdMedic { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Qualification { get; set; }
        public List<PatientPaper> PatientPapers { get; set; }
        public List<MedicDepartment> MedicDepartments { get; set; }
    }
}
