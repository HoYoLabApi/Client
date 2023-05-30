using HoYoLabApi.Enums;
using Newtonsoft.Json;

namespace HoYoLabApi.Models;

public class GameData
{
	[JsonProperty("game_biz")]
	public string Game { get; init; }
	
	[JsonProperty("region_name")]
	public string RegionName { get; init; }
	
	[JsonProperty("prod_official_eur")]
	public Region Region { get; }
	
	[JsonProperty("game_uid")]
	public uint Uid { get; init; }
	
	[JsonProperty("nickname")]
	public string Nickname { get; init; }
	
	[JsonProperty("level")]
	public byte Level { get; init; }
	
	[JsonProperty("is_chosen")]
	public bool IsChosen { get; init; }
	
	[JsonProperty("is_official")]
	public bool IsOfficial { get; init; }
}