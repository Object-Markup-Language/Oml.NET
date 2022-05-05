using System.Collections;
using System.Collections.Generic;
using Oml.NET.Base;

namespace Oml.NET
{
    /// <inheritdoc cref="IOmlHeader"/>
    public class OmlHeader : OmlObject, IOmlHeader
    {
        private readonly IOmlTable _backingTable;

        public OmlHeader()
        {
            _backingTable = new OmlTable();
        }

        /// <inheritdoc/>
        public IOmlProperty Get(string key) => _backingTable.Get(key);
        /// <inheritdoc/>
        public void Set(string key, object value) => _backingTable.Set(key, value);

        /// <inheritdoc/>
        public void Add(IOmlProperty property) => _backingTable.Add(property);
        /// <inheritdoc/>
        public void Remove(string key) => _backingTable.Remove(key);

        /// <inheritdoc/>
        public bool TryGet(string key, out IOmlProperty value) => _backingTable.TryGet(key, out value);
        
        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<string, IOmlProperty>> GetEnumerator() => _backingTable.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
