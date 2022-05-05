using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Oml.NET.Base;
using Oml.NET.Utils;

namespace Oml.NET
{
    /// <inheritdoc cref="IOmlTable"/>
    public class OmlTable : IOmlTable
    {
        private readonly List<IOmlProperty> _backingList;

        public OmlTable()
        {
            _backingList = new List<IOmlProperty>();
        }

        /// <inheritdoc/>
        public IOmlProperty Get(string key) => !_backingList.TryGet(x => HasKey(x, key), out IOmlProperty property)
                ? throw new ArgumentException($"Attempted to get non-existent object with key: {key}")
                : property;

        /// <inheritdoc/>
        public void Set(string key, object value)
        {
            if (!_backingList.TryGet(x => HasKey(x, key), out IOmlProperty property))
                throw new ArgumentException($"Attempted to set non-existent object with key: {key}");
            property.Value = value;
        }

        /// <inheritdoc/>
        public void Add(IOmlProperty property)
        {
            if (_backingList.Any(x => HasKey(x, property.Key)))
                throw new ArgumentException($"An OML object with key {property.Key} already exists in the collection.");

            _backingList.Add(property);
        }

        /// <inheritdoc/>
        public void Remove(string key)
        {
            if (!_backingList.TryGet(x => HasKey(x, key), out IOmlProperty index))
                throw new ArgumentException($"Attempted to remove non-existent object with key: {key}");

            _backingList.Remove(index);
        }

        /// <inheritdoc/>
        public bool TryGet(string key, out IOmlProperty property) => _backingList.TryGet(x => HasKey(x, key), out property);

        private static bool HasKey(IOmlProperty property, string key) => property.Key == key;

        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<string, IOmlProperty>> GetEnumerator() => _backingList.ToDictionary(x => x.Key).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
