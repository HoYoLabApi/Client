using HoYoLabApi.Enums;
using HoYoLabApi.interfaces;
using HoYoLabApi.Models;
using Newtonsoft.Json;

namespace HoYoLabApi.Static;

public static class Extensions
{
	public static ICookies ParseCookies(this string cookieString)
	{
		var objString = cookieString.StartsWith('{') && cookieString.EndsWith('}')
			? cookieString
			: $@"{{""{cookieString.Replace("=", "\":\"").Replace("; ", "\", \"")}""}}";
		var parsed = JsonConvert.DeserializeObject<Cookies>(objString)!;
		parsed.CookieString = cookieString;

		if (parsed.AccountId == 0 && parsed.Ltuid != 0)
			parsed.AccountId = parsed.Ltuid;
		else if (parsed.Ltuid == 0 && parsed.AccountId != 0)
			parsed.Ltuid = parsed.AccountId;

		/*if (parsed.AccountId == string.Empty && parsed.Ltuid != string.Empty)
			parsed.AccountId = parsed.Ltuid;
		else if (parsed.Ltuid == string.Empty && parsed.AccountId != string.Empty)
			parsed.Ltuid = parsed.AccountId;*/

		return parsed;
	}

	public static string GetLanguageString(this Language language)
	{
		return language switch
		{
			Language.English => Languages.English,
			Language.Russian => Languages.Russian,
			_ => Languages.English
		};
	}

	public static Language GetLanguageFromString(this string str)
	{
		return str switch
		{
			Languages.English => Language.English,
			Languages.Russian => Language.Russian,
			_ => Language.English
		};
	}

	public static string GetShortLang(this Language language)
	{
		return language switch
		{
			Language.English => "en",
			Language.Russian => "ru",
			_ => "en"
		};
	}
}