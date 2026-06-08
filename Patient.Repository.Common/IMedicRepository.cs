using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Models;

namespace Store.Repository.Common
{
    public interface IMedicRepository
    {
        public int ReturnFromVacation(int id);
        public int AddMedic(Medic medic);
        public int HealPatient(int id);
        public int RestMedic(int id);
        public Medic GetMedicById(int id);
    }
}
