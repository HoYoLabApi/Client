using HoYoLabApi.interfaces;

namespace HoYoLabApi;

public interface IHoYoLabClient
{
	public ICookies? Cookies { get; }
	public Task<IGameResponse> GetGamesArrayAsync(IRequest request);
	public Task<IDailyClaimResult> DailyClaimAsync(IRequest request);
	public Task<ICodeClaimResult> CodeClaimAsync(IRequest request);
}