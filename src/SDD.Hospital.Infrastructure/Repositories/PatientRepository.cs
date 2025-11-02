using System.Threading.Tasks;
using SDD.Hospital.Application.Ports;
using SDD.Hospital.Domain.Models;
using SDD.Hospital.Infrastructure.Persistence;

namespace SDD.Hospital.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HospitalDbContext _db;

        public PatientRepository(HospitalDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Patient patient)
        {
            _db.Patients.Add(patient);
            await _db.SaveChangesAsync();
        }
    }
}
