namespace Store.ModelsFromDataBase
{
    public class Department
    {
        public int IdDepartment { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<MedicDepartment> MedicDepartments { get; set; }
        public List<HospitalDepartment> HospitalDepartments { get; set; }
    }
}
