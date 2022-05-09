using Oml.NET.Base;

namespace Oml.NET
{
    /// <inheritdoc cref="IOmlProperty"/>
    public class OmlProperty : OmlObject, IOmlProperty
    {
        private string _key;
        private object _value;

        public OmlProperty(string key = null, object value = null)
        {
            _key = key;
            _value = value;
        }

        /// <inheritdoc/>
        public override OmlObjectType OmlType => OmlObjectType.Comment;

        /// <inheritdoc/>
        public string GetKey() => _key;
        /// <inheritdoc/>
        public object GetValue() => _value;

        /// <inheritdoc/>
        public void SetKey(string value) => _key = value;
        /// <inheritdoc/>
        public void SetValue(object value) => _value = value;
    }
}
