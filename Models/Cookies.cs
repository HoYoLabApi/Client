using HoYoLabApi.Enums;
using HoYoLabApi.interfaces;
using HoYoLabApi.Static;
using Newtonsoft.Json;

namespace HoYoLabApi.Models;

public class Cookies : ICookies
{
	[JsonIgnore] public Language Language => Mi18NLang.GetLanguageFromString();

	[JsonIgnore] public string CookieString { get; set; } = string.Empty;

	[JsonProperty("account_id")] public ulong AccountId { get; set; }

	[JsonProperty("ltuid")] public ulong Ltuid { get; set; }

	[JsonProperty("mi18nLang")] public string Mi18NLang { get; set; } = string.Empty;
	[JsonProperty("ltoken")] public string Ltoken { get; set; } = string.Empty;
	[JsonProperty("cookie_token")] public string CookieToken { get; set; } = string.Empty;
}