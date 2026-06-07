namespace Store.ModelsFromDataBase
{
    public class HospitalDepartment
    {
        public int IdHospitalDepartment { get; set; }
        public int IdHospital { get; set; }
        public int IdDepartment { get; set; }

        public Hospital Hospital { get; set; }
        public Department Department { get; set; }
        public List<Patient> Patients { get; set; }
        public List<PatientPaper> PatientPapers { get; set; }
    }
}
