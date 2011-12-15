using System;
using SevenDigital.Content.Ingestion.Spike.Domain.Boilerplate;
using SevenDigital.Content.Ingestion.Spike.Domain.Events;

namespace SevenDigital.Content.Ingestion.Spike.Domain.Models
{
    public class LabelDepositJob : AggregateRoot
    {
        private bool _wasDetected;
        private PersistentKey _id;

        public override PersistentKey Id
        {
            get { return _id; }
        }

        private void Apply(DepositDetected e)
        {
            _wasDetected = true;
        }

        public void DetectDeposit()
        {
            if(_wasDetected)
                throw new InvalidOperationException("already been detected!");
            _id = PersistentKey.New();
            ApplyChange(new DepositDetected());
        }
    }
}
