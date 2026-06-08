using Store.Models;
using Store.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Service.Common;

namespace Store.Service
{
    public class MedicService : IMedicService
    {
        MedicRepository repository = new MedicRepository();

        public Medic GetMedicById(int id)
        {
            Medic medic = new Medic();
            medic = repository.GetMedicById(id);
            return medic;
        }

        public int RestMedic(int id)
        {
            return repository.RestMedic(id);
        }

        public int HealPatient(int id)
        {
            return repository.HealPatient(id);
        }

        public int AddMedic(Medic medic)
        {
            int number = repository.AddMedic(medic);
            return number;
        }

        public int ReturnFromVacation(int id)
        {
            int number = repository.ReturnFromVacation(id);
            return number;
        }
    }
}
