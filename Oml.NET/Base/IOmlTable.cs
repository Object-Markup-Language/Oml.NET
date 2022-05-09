using System.Collections;
using System.Collections.Generic;

namespace Oml.NET.Base
{
    /// <summary>
    /// Represents a OML table.
    /// </summary>
    public interface IOmlTable : IEnumerable, IEnumerable<IOmlObject>
    {
        public IOmlObject Get(int key);
        public void Set(int key, IOmlObject obj);

        public void Add(IOmlObject property);
        public void Remove(int key);

        public bool TryGet(int key, out IOmlObject value);

        public IOmlObject this[int key] { get => Get(key); set => Set(key, value); }
    }
}
