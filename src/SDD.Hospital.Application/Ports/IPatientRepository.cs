using System;
using System.Threading.Tasks;
using SDD.Hospital.Domain.Models;

namespace SDD.Hospital.Application.Ports
{
    public interface IPatientRepository
    {
        Task AddAsync(Patient patient);
    }
}
