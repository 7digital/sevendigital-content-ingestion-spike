using SevenDigital.Content.Ingestion.Spike.Domain.Events;

namespace SevenDigital.Content.Ingestion.Spike.Domain.Handlers
{
    public class DepositHandler<T> : IHandles<DepositDetected> where T : IMessage
    {
        public void Handle(DepositDetected cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}