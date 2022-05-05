namespace Oml.NET.Base
{
    public interface IOmlPropertyIntegerValueFormattingInfo
    {
        public int GetBase();
        public void SetBase(int value);

        public int Base { get => GetBase(); set => SetBase(value); }
    }
}
