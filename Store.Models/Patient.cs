using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Patient
    {
        public int IdPatient { get; set; }
        public string Name { get; set; }
        public string DiseaseType { get; set; }
        public string Sex { get; set; }
        public int IdMedic { get; set; }
    }
}
