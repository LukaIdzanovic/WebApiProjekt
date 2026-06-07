namespace Store.ModelsFromDataBase
{
    public class Patient
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdHospitalDepartment { get; set; }
        public HospitalDepartment HospitalDepartment { get; set; }
        public List<PatientPaper> PatientPapers { get; set; }
    }
}
