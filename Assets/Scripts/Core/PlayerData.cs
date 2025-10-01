using System.Collections.Generic;

namespace Core
{
    public sealed class PlayerData
    {
        private readonly Dictionary<System.Type, object> _store = new();

        public T Get<T>() where T : new()
        {
            if (!_store.TryGetValue(typeof(T), out var value))
            {
                value = new T();
                _store[typeof(T)] = value;
            }

            return (T)value;
        }

        public void Set<T>(T value)
        {
            _store[typeof(T)] = value!;
        }
    }
}