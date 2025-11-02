using System;
using Xunit;
using SDD.Hospital.Domain.Models;

namespace SDD.Hospital.Domain.Tests
{
    public class PatientTests
    {
        [Fact]
        public void CreatingPatient_WithMissingNames_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new Patient(null, null!, "", DateTime.UtcNow));
        }

        [Fact]
        public void CreatingPatient_WithValidData_SetsProperties()
        {
            var id = Guid.NewGuid();
            var p = new Patient(id, "John", "Doe", new DateTime(1990,1,1), "john@example.com", "12345");

            Assert.Equal(id, p.Id);
            Assert.Equal("John", p.FirstName);
            Assert.Equal("Doe", p.LastName);
            Assert.Equal(new DateTime(1990,1,1), p.DateOfBirth);
            Assert.Equal("john@example.com", p.Email);
            Assert.Equal("12345", p.PhoneNumber);
        }
    }
}
