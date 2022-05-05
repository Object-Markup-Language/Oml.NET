using System.Collections.Generic;

namespace Oml.NET.Base
{
    /// <summary>
    /// A collection which can store <see cref="IOmlProperty"/>s.
    /// </summary>
    public interface IOmlTable : IEnumerable<KeyValuePair<string, IOmlProperty>>
    {
        public IOmlProperty Get(string key);
        public void Set(string key, object value);

        public void Add(IOmlProperty property);
        public void Remove(string key);

        public bool TryGet(string key, out IOmlProperty value);

        public IOmlProperty this[string key] { get => Get(key); set => Set(key, value.Value); }

        public T GetObjectValue<T>(string key) => Get(key).GetValue<T>();
        public void SetObjectValue(string key, object value) => Get(key).Value = value;
    }
}
