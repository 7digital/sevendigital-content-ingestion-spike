using System;

namespace SevenDigital.Content.Ingestion.Spike.Domain.Boilerplate
{
    public class PersistentKey
    {
        private readonly Guid _key;

        private PersistentKey(Guid key)
        {
            _key = key;
        }

        public static PersistentKey New()
        {
            return new PersistentKey(Guid.NewGuid());
        }

        public static PersistentKey From(Guid key)
        {
            return new PersistentKey(key);
        }

        public Guid ToGuid()
        {
            return _key;
        }

        public override string ToString()
        {
            return _key.ToString();
        }

        public override bool Equals(object obj)
        {
            var comparer = obj as PersistentKey;
            return obj != null && comparer._key.Equals(_key);
        }

        public override int GetHashCode()
        {
            return _key.GetHashCode();
        }
    }
}