using Store.Models;
using Store.Repository;
using Store.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Store.Service
{
    public class MedicService : IMedicService
    {
        MedicRepository repository = new MedicRepository();

        public async Task<Medic> GetMedicByIdAsync(int id)
        {
            Medic medic = new Medic();
            medic = await repository.GetMedicByIdAsync(id);
            return medic;
        }

        public async Task<int> RestMedicAsync(int id)
        {
            int number = 0;
            number = await repository.RestMedicAsync(id);
            return number;
        }

        public async Task<int> HealPatientAsync(int id)
        {
            int number = 0;
            number = await repository.HealPatientAsync(id);
            return number;
        }

        public async Task<int> AddMedicAsync(Medic medic)
        {
            int number = 0;
            number = await repository.AddMedicAsync(medic);
            return number;
        }

        public async Task<int> ReturnFromVacationAsync(int id)
        {
            int number = 0;
            number = await repository.ReturnFromVacationAsync(id);
            return number;
        }
    }
}
