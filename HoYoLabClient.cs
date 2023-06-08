﻿using HoYoLabApi.Classes;
using HoYoLabApi.interfaces;
using HoYoLabApi.Models;
using HoYoLabApi.Static;

namespace HoYoLabApi;

public sealed class HoYoLabClient : HoYoLabClientBase, IHoYoLabClient
{
	public HoYoLabClient(ICookies? cookies = null)
	{
		Cookies = cookies;
	}

	public HoYoLabClient(string cookiesString) : this(cookiesString.ParseCookies())
	{
	}

	public ICookies? Cookies { get; }

	public async Task<(IGameResponse, Headers)> GetGamesArrayAsync(IRequest request)
	{
		var cookie = (request.Cookies ?? Cookies)!;
		request.Query["sLangKey"] = cookie.Language.GetLanguageString();
		request.Query["uid"] = cookie.AccountId.ToString();
		return await GetAsync<GameResponse>(request.GetFullUri(), cookie).ConfigureAwait(false);
	}

	public async Task<(IDailyClaimResult, Headers)> DailyClaimAsync(IRequest request)
	{
		return await PostAsync<DailyClaimResult>(request.GetFullUri(), request.Cookies ?? Cookies!)
			.ConfigureAwait(false);
	}

	public async Task<(ICodeClaimResult, Headers)> CodeClaimAsync(IRequest request)
	{
		return await GetAsync<CodeClaimResult>(request.GetFullUri(), request.Cookies ?? Cookies!)
			.ConfigureAwait(false);
	}
}