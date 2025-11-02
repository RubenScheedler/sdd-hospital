using System.Threading.Tasks;

namespace SDD.Hospital.Application.Ports
{
    public interface IDomainEventPublisher
    {
        Task PublishAsync(object @event);
    }
}
