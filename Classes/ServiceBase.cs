using HoYoLabApi.Enums;
using HoYoLabApi.interfaces;
using HoYoLabApi.Models;
using HoYoLabApi.Static;

namespace HoYoLabApi.Classes;

public abstract class ServiceBase : ServiceRequests
{
	protected ServiceBase(IHoYoLabClient client, Func<GameData, ClaimRequest> codeClaim, ClaimRequest dailyClaim)
		: base(client, codeClaim, dailyClaim)
	{
	}
	
	public Task<IGameResponse> GetGameAccountAsync(string? cookies = null, string? game = null)
	{
		return base.GetGameAccountAsync(cookies?.ParseCookies() ?? Client.Cookies!, game);
	}

	public async Task DailiesClaimAsync(ICookies[] cookies)
	{
		await foreach (var _ in DailiesClaimAsync(cookies, null))
		{
		}
	}

	public async Task CodesClaimAsync(ICookies cookies, string[] codes)
	{
		await foreach (var _ in CodesClaimAsync(cookies, codes, null))
		{
		}
	}

	public Task<IDailyClaimResult> DailyClaimAsync(string cookies)
	{
		return base.DailyClaimAsync(cookies.ParseCookies());
	}

	public Task<IDailyClaimResult> DailyClaimAsync()
	{
		return base.DailyClaimAsync(Client.Cookies!);
	}

	public Task<ICodeClaimResult> CodeClaimAsync(string code)
	{
		return base.CodeClaimAsync(Client.Cookies!, code);
	}

	public IAsyncEnumerable<IDailyClaimResult> DailiesClaimAsync(string[] cookies, CancellationToken? cancellationToken)
	{
		return base.DailiesClaimAsync(cookies.Select(x => x.ParseCookies()).ToArray(), cancellationToken);
	}

	public Task CodesClaimAsync(string cookies, string[] codes)
	{
		return CodesClaimAsync(cookies.ParseCookies(), codes);
	}

	public Task DailiesClaimAsync(string[] cookies)
	{
		return DailiesClaimAsync(cookies.Select(x => x.ParseCookies()).ToArray());
	}

	public IAsyncEnumerable<ICodeClaimResult> CodesClaimAsync(
		string[] codes,
		string? cookies = null,
		Region? region = null,
		CancellationToken? cancellationToken = null)
	{
		return base.CodesClaimAsync(cookies?.ParseCookies() ?? Client.Cookies!, codes, region, cancellationToken);
	}
}