namespace Store.ModelsFromDataBase
{
    public class Hospital
    {
        public int IdHospital { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<HospitalDepartment> HospitalDepartments { get; set; }
    }
}
