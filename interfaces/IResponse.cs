using Newtonsoft.Json;

namespace HoYoLabApi.interfaces;

public interface IResponse
{
	[JsonProperty("retcode")] public int Code { get; }

	[JsonProperty("message")] public string Message { get; }
}