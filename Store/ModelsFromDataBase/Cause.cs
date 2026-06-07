namespace Store.ModelsFromDataBase
{
    public class Cause
    {
        public int IdCause { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int IdPatientPaper {  get; set; }
        public List<PatientPaper> PatientPapers {get; set;}
    }
}
