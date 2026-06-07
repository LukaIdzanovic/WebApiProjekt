namespace Store.ModelsFromDataBase
{
    public class MedicDepartment
    {
        public int IdMedic { get; set; }
        public int IdDepartment { get; set; }

        public Medic Medic { get; set; }
        public Department Department { get; set; }
    }
}
