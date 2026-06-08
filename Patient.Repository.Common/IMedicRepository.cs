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
        public Task<int> ReturnFromVacationAsync(int id);
        public Task<int> AddMedicAsync(Medic medic);
        public Task<int> HealPatientAsync(int id);
        public Task<int> RestMedicAsync(int id);
        public Task<Medic> GetMedicByIdAsync(int id);
    }
}
