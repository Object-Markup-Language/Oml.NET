using System.Collections.Generic;

namespace Oml.NET.Base
{
    public interface IOmlObjectList : IEnumerable<IOmlObject>
    {
        public IOmlObject Get(int index);
        public void Set(int index, IOmlObject value);

        public void Add(IOmlObject value);
        public void Remove(IOmlObject value);
        public void RemoveAt(int index);

        public IOmlObject this[int index] { get => Get(index); set => Set(index, value); }
    }
}
