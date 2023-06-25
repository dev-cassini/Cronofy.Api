using MediatR;

namespace Cronofy.Domain.Events;

public class ServiceAccountCreated : INotification
{
    public string Id { get; }

    public ServiceAccountCreated(string id)
    {
        Id = id;
    }
}