﻿using HoYoLabApi.Enums;
using Newtonsoft.Json;

namespace HoYoLabApi.interfaces;

public interface ICookies
{
	[JsonIgnore] public Language Language { get; }

	[JsonIgnore] public string CookieString { get; }

	[JsonProperty("account_id")] public uint AccountId { get; }
	[JsonProperty("ltuid")] public uint Ltuid { get; }

	[JsonProperty("mi18nLang")] public string Mi18NLang { get; }
	[JsonProperty("ltoken")] public string Ltoken { get; }
	[JsonProperty("cookie_token")] public string CookieToken { get; }
}