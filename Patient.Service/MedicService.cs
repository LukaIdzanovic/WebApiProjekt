using Store.Models;
using Store.Repository;
using Store.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Store.Repository.Common;

namespace Store.Service
{
    public class MedicService : IMedicService
    {
        private IMedicRepository Repository { get; set; }

        public MedicService(IMedicRepository repository)
        {
            Repository = repository;
        }
        public async Task<Medic> GetMedicByIdAsync(int id)
        {
            Medic medic = new Medic();
            medic = await Repository.GetMedicByIdAsync(id);
            return medic;
        }

        public async Task<int> RestMedicAsync(int id)
        {
            int number = 0;
            number = await Repository.RestMedicAsync(id);
            return number;
        }

        public async Task<int> HealPatientAsync(int id)
        {
            int number = 0;
            number = await Repository.HealPatientAsync(id);
            return number;
        }

        public async Task<int> AddMedicAsync(Medic medic)
        {
            int number = 0;
            number = await Repository.AddMedicAsync(medic);
            return number;
        }

        public async Task<int> ReturnFromVacationAsync(int id)
        {
            int number = 0;
            number = await Repository.ReturnFromVacationAsync(id);
            return number;
        }
    }
}
