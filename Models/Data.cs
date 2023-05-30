using Newtonsoft.Json;

namespace HoYoLabApi.Models;

public class Data
{
	[JsonProperty("list")] public GameData[] GameAccounts { get; init; }
}