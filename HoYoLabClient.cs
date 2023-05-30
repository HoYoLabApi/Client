using System.Net;
using HoYoLabApi.Classes;
using HoYoLabApi.interfaces;
using HoYoLabApi.Models;
using HoYoLabApi.Static;

namespace HoYoLabApi;

public sealed class HoYoLabClient : HoYoLabClientBase, IHoYoLabClient
{
	public ICookies? Cookies { get; }

	public HoYoLabClient(ICookies? cookies = null) => Cookies = cookies;

	public HoYoLabClient(string cookiesString) : this(cookiesString.ParseCookies())
	{
	}

	public async Task<IGameResponse> GetGamesArrayAsync(IRequest request)
	{
		var cookie = (request.Cookies ?? Cookies)!;
		request.Query["sLangKey"] = cookie.Language.GetLanguageString();
		request.Query["uid"] = cookie.AccountId.ToString();
		return await GetAsync<GameResponse>(request.GetFullUri(), cookie).ConfigureAwait(false);
	}

	public async Task<IDailyClaimResult> DailyClaimAsync(IRequest request)
		=> await PostAsync<DailyClaimResult>(request.GetFullUri(), request.Cookies ?? Cookies)
			.ConfigureAwait(false);

	public async Task<ICodeClaimResult> CodeClaimAsync(IRequest request) =>
		await GetAsync<CodeClaimResult>(request.GetFullUri(), request.Cookies ?? Cookies)
			.ConfigureAwait(false);
}