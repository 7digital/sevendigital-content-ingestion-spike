using SevenDigital.Content.Ingestion.Spike.Domain.Boilerplate;
using SevenDigital.Content.Ingestion.Spike.Domain.Commands;
using SevenDigital.Content.Ingestion.Spike.Domain.EventStore;
using SevenDigital.Content.Ingestion.Spike.Domain.Models;

namespace SevenDigital.Content.Ingestion.Spike.Domain.Handlers
{
    public class DepositDetector : IHandles<FileDeposit>
    {
        private readonly IRepository<LabelDepositJob> _repository;

        public DepositDetector(IRepository<LabelDepositJob> repository)
        {
            _repository = repository;
        }

        public void Handle(FileDeposit cmd)
        {
            var depositJob = new LabelDepositJob(cmd.Label);
            depositJob.DetectDeposit();
            _repository.Save(depositJob, -1);
        }
    }
}