using SevenDigital.Content.Ingestion.Spike.Domain.Boilerplate;
using SevenDigital.Content.Ingestion.Spike.Domain.Models;

namespace SevenDigital.Content.Ingestion.Spike.Domain.Events
{
    public class DepositDetected : IEvent, IMessage
    {
        public DepositDetected(PersistentKey id, Label label)
        {
            Key = id;
        }

        public PersistentKey Key { get; private set; }

        public Label Label { get; private set; }
    }
}