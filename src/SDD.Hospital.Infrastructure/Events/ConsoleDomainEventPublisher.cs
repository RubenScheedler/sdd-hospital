using System;
using System.Text.Json;
using System.Threading.Tasks;
using SDD.Hospital.Application.Ports;

namespace SDD.Hospital.Infrastructure.Events
{
    public class ConsoleDomainEventPublisher : IDomainEventPublisher
    {
        public Task PublishAsync(object @event)
        {
            var json = JsonSerializer.Serialize(@event, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine($"[DomainEvent] {@event.GetType().Name}: {json}");
            return Task.CompletedTask;
        }
    }
}
