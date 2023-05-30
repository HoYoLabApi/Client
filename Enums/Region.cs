using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HoYoLabApi.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum Region : byte
{
	[EnumMember(Value = "Europe Server")] Europe,
	[EnumMember(Value = "America Server")] America,
	[EnumMember(Value = "Asia Server")] Asia
}