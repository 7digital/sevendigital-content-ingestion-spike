using SevenDigital.Content.Ingestion.Spike.Domain.Commands;
using SevenDigital.Content.Ingestion.Spike.Domain.Models;

namespace SevenDigital.Content.Ingestion.Spike.Domain.Handlers
{
    public class DepositDetector : IHandles<FileDeposit>
    {
        public void Handle(FileDeposit cmd)
        {
            var depositJob = new LabelDepositJob(cmd.Label, cmd.Location);
            depositJob.DetectDeposit();
        }
    }
}