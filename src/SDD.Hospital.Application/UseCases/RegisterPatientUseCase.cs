using System;
using System.Threading.Tasks;
using SDD.Hospital.Application.Commands;
using SDD.Hospital.Application.Ports;
using SDD.Hospital.Domain.Events;
using SDD.Hospital.Domain.Models;

namespace SDD.Hospital.Application.UseCases
{
    public class RegisterPatientUseCase
    {
        private readonly IPatientRepository _repository;
        private readonly IDomainEventPublisher _publisher;

        public RegisterPatientUseCase(IPatientRepository repository, IDomainEventPublisher publisher)
        {
            _repository = repository;
            _publisher = publisher;
        }

        public async Task<Guid> Handle(RegisterPatientCommand command)
        {
            var id = Guid.NewGuid();
            var patient = new Patient(id, command.FirstName, command.LastName, command.DateOfBirth);
            await _repository.AddAsync(patient);

            var @event = new PatientRegisteredEvent(id, command.FirstName, command.LastName, command.DateOfBirth, DateTime.UtcNow);
            await _publisher.PublishAsync(@event);

            return id;
        }
    }
}
