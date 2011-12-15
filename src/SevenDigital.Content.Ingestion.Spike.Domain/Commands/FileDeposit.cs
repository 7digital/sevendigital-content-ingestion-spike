namespace SevenDigital.Content.Ingestion.Spike.Domain.Commands
{
    public class FileDeposit : ICommand, IMessage
    {
        public string Label { get; set; }
        public string Location { get; set; }
    }
}