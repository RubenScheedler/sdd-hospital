using System;

namespace SDD.Hospital.Domain.Events
{
    public record PatientRegisteredEvent(Guid PatientId, string FirstName, string LastName, DateTime DateOfBirth, DateTime OccurredAt);
}
