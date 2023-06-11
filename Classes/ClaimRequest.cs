using HoYoLabApi.Models;

namespace HoYoLabApi.Classes;

public record ClaimRequest(string SubDomain,
	string Path,
	string? ActId = null,
	string? Region = null,
	GameData? GameAcc = null)
{
	public static ClaimRequest FromData(GameData? gameData, string subDomain, string? region = null)
	{
		return new ClaimRequest(
			"sg-hk4e-api", "", null, region, gameData
		);
	}
}