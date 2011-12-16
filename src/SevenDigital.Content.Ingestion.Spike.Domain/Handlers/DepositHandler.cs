using SevenDigital.Content.Ingestion.Spike.Domain.Boilerplate;
using SevenDigital.Content.Ingestion.Spike.Domain.Events;

namespace SevenDigital.Content.Ingestion.Spike.Domain.Handlers
{
    public class DepositHandler : IHandles<DepositDetected>
    {
        private readonly IPersistentStore _store;

        public DepositHandler(IPersistentStore store)
        {
            _store = store;
        }

        public void Handle(DepositDetected cmd)
        {
            var depositJob = _store.Get<LabelDepositJobDto>(cmd.Key);
            depositJob.Label = cmd.Label.ToString();
            depositJob.Status = "Waiting for Download";
            _store.Store(depositJob);
        }
    }

    public class LabelDepositJobDto : IPersistable
    {
        public PersistentKey Id { get; set; }
        public string Status { get; set; }
        public string Label { get; set; }
    }
}