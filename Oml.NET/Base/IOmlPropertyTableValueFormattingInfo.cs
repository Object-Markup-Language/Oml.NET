using System;
using System.Collections.Generic;

namespace Oml.NET.Base
{
    public interface IOmlPropertyTableValueFormattingInfo
    {
        public bool GetIsSameLine();
        public void SetIsSameLine(bool value);

        public Dictionary<Type, IOmlPropertyValueSerializer> GetOtherPropertyValueSerializers();
        public void SetOtherPropertyValueSerializers(Dictionary<Type, IOmlPropertyValueSerializer> value);

        public IOmlPropertyValueSerializer GetFallbackSerializer();
        public void SetFallbackSerializer(IOmlPropertyValueSerializer value);

        public IList<IOmlPropertyValueFormattingInfo> GetChildFormattingInfos();
        public void SetChildFormattingInfos(IList<IOmlPropertyValueFormattingInfo> value);

        public bool IsSameLine { get => GetIsSameLine(); set => SetIsSameLine(value); }
        public Dictionary<Type, IOmlPropertyValueSerializer> OtherPropertyValueSerializers { get => GetOtherPropertyValueSerializers(); set => SetOtherPropertyValueSerializers(value); }
        public IOmlPropertyValueSerializer FallbackSerializer { get => GetFallbackSerializer(); set => SetFallbackSerializer(value); }
        public IList<IOmlPropertyValueFormattingInfo> ChildFormattingInfos { get => GetChildFormattingInfos(); set => SetChildFormattingInfos(value); }
    }
}
