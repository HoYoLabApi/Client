using HoYoLabApi.interfaces;
using HoYoLabApi.Models;
using HoYoLabApi.Static;

namespace HoYoLabApi.Classes;

public sealed class AccountSearcher
{
	private readonly IHoYoLabClient m_client;

	public AccountSearcher(IHoYoLabClient client)
	{
		m_client = client;
	}

	public async Task<(IGameResponse, Headers)> GetGameAccountAsync(ICookies cookies, string? game = null)
	{
		var query = new Dictionary<string, string>
		{
			{ "uid", cookies.AccountId.ToString() },
			{ "sLangKey", cookies.Language.GetLanguageString() }
		};

		if (game is not null)
			query["game_biz"] = game;

		var req = new Request(
			"api-account-os",
			"account/binding/api/getUserGameRolesByCookieToken",
			cookies,
			query
		);

		var (res, headers) = await m_client.GetGamesArrayAsync(req).ConfigureAwait(false);

		return (res, headers);
	}

	public Task<(IGameResponse, Headers)> GetGameAccountAsync(string cookies, string? game = null)
	{
		return GetGameAccountAsync(cookies.ParseCookies(), game);
	}

	public Task<(IGameResponse, Headers)> GetGameAccountAsync()
	{
		return GetGameAccountAsync(m_client.Cookies!);
	}
}