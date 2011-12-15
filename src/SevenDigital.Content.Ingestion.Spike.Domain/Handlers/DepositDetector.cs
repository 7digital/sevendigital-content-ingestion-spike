using SevenDigital.Content.Ingestion.Spike.Domain.Commands;

namespace SevenDigital.Content.Ingestion.Spike.Domain.Handlers
{
    public class DepositDetector<T> : IHandles<FileDeposit> where T : IMessage
    {
        public void Handle(FileDeposit cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}