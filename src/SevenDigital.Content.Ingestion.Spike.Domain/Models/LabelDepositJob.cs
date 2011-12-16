using System;
using SevenDigital.Content.Ingestion.Spike.Domain.Boilerplate;
using SevenDigital.Content.Ingestion.Spike.Domain.Events;

namespace SevenDigital.Content.Ingestion.Spike.Domain.Models
{
    public class LabelDepositJob : AggregateRoot
    {
        private readonly Label _label;
        private readonly PersistentKey _id;
        private bool _wasDetected;

        public LabelDepositJob() 
            : this("7digitalIndie")
        { }

        public LabelDepositJob(string label)
        {
            _label = new Label(label);

            _id = PersistentKey.New();
        }

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
            
            ApplyChange(new DepositDetected(_id, _label));
        }
    }
}
