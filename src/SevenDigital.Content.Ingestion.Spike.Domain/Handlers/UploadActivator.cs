using SevenDigital.Content.Ingestion.Spike.Domain.Commands;

namespace SevenDigital.Content.Ingestion.Spike.Domain.Handlers
{
    public class UploadActivator : IHandles<ActivateLabelUpload>
    {
        public void Handle(ActivateLabelUpload cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}