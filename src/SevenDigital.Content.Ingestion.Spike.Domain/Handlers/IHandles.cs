namespace SevenDigital.Content.Ingestion.Spike.Domain.Handlers
{
    public interface IHandles<T> where T : IMessage
    {
        void Handle(T cmd);
    }
}
