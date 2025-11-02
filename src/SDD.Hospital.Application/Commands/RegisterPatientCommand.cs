using System;

namespace SDD.Hospital.Application.Commands
{
    public record RegisterPatientCommand(string FirstName, string LastName, DateTime DateOfBirth);
}
