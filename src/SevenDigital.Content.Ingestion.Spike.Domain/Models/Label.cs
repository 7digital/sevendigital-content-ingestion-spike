namespace SevenDigital.Content.Ingestion.Spike.Domain.Models
{
    public class Label
    {
        private readonly string _name;

        public Label(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}