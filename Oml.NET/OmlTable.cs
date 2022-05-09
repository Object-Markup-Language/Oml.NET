using System.Collections;
using System.Collections.Generic;
using Oml.NET.Base;

namespace Oml.NET
{
    /// <inheritdoc cref="IOmlObject"/>
    public class OmlTable : IOmlTable
    {
        private readonly List<IOmlObject> _backingList;

        public OmlTable()
        {
            _backingList = new List<IOmlObject>();
        }
        
        /// <inheritdoc/>
        public IOmlObject Get(int key) => _backingList[key];

        /// <inheritdoc/>
        public void Set(int key, IOmlObject obj) => _backingList[key] = obj;

        /// <inheritdoc/>
        public void Add(IOmlObject obj) => _backingList.Add(obj);

        /// <inheritdoc/>
        public void Remove(int key) => _backingList.RemoveAt(key);

        /// <inheritdoc/>
        public bool TryGet(int key, out IOmlObject obj)
        {
            if (key < 0 || key >= _backingList.Count)
            {
                obj = null;
                return false;
            }

            obj = _backingList[key];
            return true;
        }

        /// <inheritdoc/>
        public IEnumerator<IOmlObject> GetEnumerator() => _backingList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
