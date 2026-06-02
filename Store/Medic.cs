using System.Xml.XPath;

namespace Store
{
    public class Medic
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsActive { get;  set; }

        public Medic(int id, string name)
        {
            Id = id;
            Name = name;
            IsActive = true;
        }

        public List<Patient> Heal(int id, List<Patient> patientList)
        {
            if (IsActive)
                patientList.Find(x => x.Id == id).DiseaseType = null;
                return patientList;
        }
    }
}
