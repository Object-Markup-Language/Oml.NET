using System.Collections;
using System.Collections.Generic;
using Oml.NET.Base;

namespace Oml.NET
{
    /// <inheritdoc cref="IOmlObjectList"/>
    public class OmlObjectList : IOmlObjectList
    {
        private readonly List<IOmlObject> _backingList;

        public OmlObjectList()
        {
            _backingList = new List<IOmlObject>();
        }

        public IOmlObject Get(int index) => _backingList[index];
        public void Set(int index, IOmlObject value) => _backingList[index] = value;

        public void Add(IOmlObject value) => _backingList.Add(value);
        public void Remove(IOmlObject value) => _backingList.Remove(value);
        public void RemoveAt(int index) => _backingList.RemoveAt(index);

        public IEnumerator<IOmlObject> GetEnumerator() => _backingList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
