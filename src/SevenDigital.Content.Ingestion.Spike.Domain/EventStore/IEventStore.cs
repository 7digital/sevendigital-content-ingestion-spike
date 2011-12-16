using System.Collections.Generic;
using SevenDigital.Content.Ingestion.Spike.Domain.Boilerplate;
using SevenDigital.Content.Ingestion.Spike.Domain.Events;
using SevenDigital.Content.Ingestion.Spike.Domain.Queuing;

namespace SevenDigital.Content.Ingestion.Spike.Domain.EventStore
{
    public interface IEventStore
    {
        void SaveEvents(PersistentKey aggregateId, IEnumerable<IEvent> events, int expectedVersion);       
    }

    public class EventStore : IEventStore
    {
        private readonly IEventPublisher _publisher;

        public EventStore(IEventPublisher publisher)
        {
            _publisher = publisher;
        }

        public void SaveEvents(PersistentKey aggregateId, IEnumerable<IEvent> events, int expectedVersion)
        {
            foreach(var ev in events)
                _publisher.Publish(ev);
        }
    }
}