using System;
using System.ComponentModel.DataAnnotations;

namespace SDD.Hospital.Api.Models
{
    public class RegisterPatientRequest
    {
        [Required]
        public string FirstName { get; init; } = string.Empty;

        [Required]
        public string LastName { get; init; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; } = string.Empty;

        [Required]
        public string PhoneNumber { get; init; } = string.Empty;
    }
}
