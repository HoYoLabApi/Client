using HoYoLabApi.Models;

namespace HoYoLabApi.Classes;

public record ClaimRequest(string SubDomain,
	string Path,
	string? ActId = null,
	string? Region = null,
	GameData? GameAcc = null);