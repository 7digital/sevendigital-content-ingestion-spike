using SevenDigital.Content.Ingestion.Spike.Domain.Events;

namespace SevenDigital.Content.Ingestion.Spike.Domain.Handlers
{
    public class UploadDeactivator : IHandles<LabelUploadActivated>
    {
        public void Handle(LabelUploadActivated cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}