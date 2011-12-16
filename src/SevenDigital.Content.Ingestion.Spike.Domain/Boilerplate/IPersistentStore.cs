using System.Collections.Generic;

namespace SevenDigital.Content.Ingestion.Spike.Domain.Boilerplate
{
    public interface IPersistentStore
    {
        void Store(IPersistable item);
        T Get<T>(PersistentKey key) where T : IPersistable;
        IList<T> All<T>() where T : IPersistable;
    }
}