using HoYoLabApi.interfaces;
using HoYoLabApi.Models;
using HoYoLabApi.Static;

namespace HoYoLabApi.Classes;

public sealed class CodeClaimRequest : Request
{
	public CodeClaimRequest(string subDomain, ICookies cookies, string region, string code, GameData gameData)
		: this(
			subDomain,
			"common/apicdkey/api/webExchangeCdkey",
			cookies,
			new Dictionary<string, string>()
			{
				{ "uid", gameData.Uid.ToString() },
				{ "region", region },
				{ "game_biz", gameData.Game },
				{ "cdkey", code },
				{ "sLangKey", cookies.Language.GetLanguageString() },
				{ "lang", cookies.Language.GetShortLang() },
			},
			new Dictionary<string, string>()
			{
				{ "Referer", "https://hsr.hoyoverse.com" },
				{ "Orig", "https://hsr.hoyoverse.com" }
			}
		)
	{
	}
	
	public CodeClaimRequest(string subDomain, string path, ICookies? cookies, IDictionary<string, string>? query = null, IDictionary<string, string>? headers = null)
		: base(subDomain, path, cookies, query, headers)
	{
	}

	public override Uri GetFullUri()
	{
		var invalid = base.GetFullUri().ToString();
		return new Uri(invalid.Replace("hoyolab", "hoyoverse"));
	}
}