namespace Store.ModelsFromDataBase
{
    public class PatientPaper
    {
        public DateOnly CameAt { get; set; }
        public int IdMedic {  get; set; }
        public int IdPatient { get; set; }
        public int IdDepartment { get; set; }
        public int IdHospitalDepartment { get; set; }

        public Patient Patient { get; set; }
        public Cause Cause { get; set; }
        public Medic Medic { get; set; }
        public HospitalDepartment HospitalDepartment { get; set; }
    }
}
