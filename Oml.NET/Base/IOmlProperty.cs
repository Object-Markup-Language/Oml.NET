namespace Oml.NET.Base
{
    /// <summary>
    /// Represents an OML object. Each OML object has a unique <see cref="Key"/> and a <see cref="Value"/>.
    /// </summary>
    public interface IOmlProperty : IOmlObject
    {
        public string GetKey();
        public void SetKey(string value);
        public object GetValue();
        public void SetValue(object value);

        public string Key { get => GetKey(); set => SetKey(value); }
        public object Value { get => GetValue(); set => SetValue(value); }

        public T GetValue<T>() => (T)GetValue();
    }
}
