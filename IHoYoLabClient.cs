using HoYoLabApi.interfaces;
using HoYoLabApi.Models;

namespace HoYoLabApi;

public interface IHoYoLabClient
{
	public ICookies? Cookies { get; }
	public Task<(IGameResponse, Headers)> GetGamesArrayAsync(IRequest request);
	public Task<(IDailyClaimResult, Headers)> DailyClaimAsync(IRequest request);
	public Task<(ICodeClaimResult, Headers)> CodeClaimAsync(IRequest request);
}