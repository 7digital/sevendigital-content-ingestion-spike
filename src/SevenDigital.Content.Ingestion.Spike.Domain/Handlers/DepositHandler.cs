using SevenDigital.Content.Ingestion.Spike.Domain.Events;

namespace SevenDigital.Content.Ingestion.Spike.Domain.Handlers
{
    public class DepositHandler : IHandles<DepositDetected>
    {
        public void Handle(DepositDetected cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}