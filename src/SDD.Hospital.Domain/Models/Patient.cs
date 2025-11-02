using System;

namespace SDD.Hospital.Domain.Models
{
    public class Patient
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public DateTime DateOfBirth { get; private set; }
        public string? Email { get; private set; }
        public string? PhoneNumber { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // EF Core and serializers
        private Patient() { }

        public Patient(Guid? id, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            Id = (id == null || id == Guid.Empty) ? Guid.NewGuid() : id.Value;
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            DateOfBirth = dateOfBirth;
            Email = string.IsNullOrWhiteSpace(email) ? throw new ArgumentNullException(nameof(email)) : email;
            PhoneNumber = string.IsNullOrWhiteSpace(phoneNumber) ? throw new ArgumentNullException(nameof(phoneNumber)) : phoneNumber;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
