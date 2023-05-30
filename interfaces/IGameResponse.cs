using HoYoLabApi.Models;
using Newtonsoft.Json;

namespace HoYoLabApi.interfaces;

public interface IGameResponse : IResponse
{
	[JsonProperty("data")]
	public Data Data { get; init; }
}