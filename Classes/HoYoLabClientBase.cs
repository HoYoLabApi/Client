using System.Net;
using System.Net.Http.Headers;
using ComposableAsync;
using HoYoLabApi.interfaces;
using HoYoLabApi.Static;
using Newtonsoft.Json;
using RateLimiter;

namespace HoYoLabApi.Classes;

public abstract class HoYoLabClientBase
{
	private readonly TimeLimiter m_limiter = TimeLimiter.GetFromMaxCountByInterval(1, TimeSpan.FromSeconds(5));
	private readonly HttpClient s_client;

	public HoYoLabClientBase()
	{
		var cookieContainer = new CookieContainer();
		cookieContainer.PerDomainCapacity = 1;

		var handler = new HttpClientHandler();
		handler.CookieContainer = cookieContainer;
		handler.UseCookies = false;

		s_client = new(handler);
		
		var h = s_client.DefaultRequestHeaders;
		h.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		h.Add("User-Agent",
			"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36");
		h.Add("x-rpc-app_version", "1.5.0");
		h.Add("x-rpc-client_type", "5");
		h.Add("x-rpc-language", "en-us");
	}

	internal async Task<T> GetAsync<T>(Uri uri,
		ICookies cookies,
		IReadOnlyDictionary<string, string>? headers = null,
		CancellationToken? cancellationToken = null)
	{
		var message = new HttpRequestMessage(HttpMethod.Get, uri);
		var h = message.Headers;
		h.Add("Cookie", cookies.CookieString);
		h.Add("x-rpc-language", cookies.Language.GetLanguageString());

		if (!(h.Contains("Referer") || h.Contains("Orig")))
		{
			h.Add("Referer", "https://act.hoyolab.com");
			h.Add("Orig", "https://act.hoyolab.com");
		}

		if (headers is null)
			return await Request<T>(message, cancellationToken).ConfigureAwait(false);

		foreach (var (k, v) in headers)
			h.Add(k, v);

		return await Request<T>(message, cancellationToken).ConfigureAwait(false);
	}

	internal async Task<T> PostAsync<T>(Uri uri,
		ICookies cookies,
		IReadOnlyDictionary<string, string>? headers = null,
		CancellationToken? cancellationToken = null)
	{
		var message = new HttpRequestMessage(HttpMethod.Post, uri);

		var h = message.Headers;
		h.Add("Cookie", cookies.CookieString);
		h.Add("x-rpc-language", cookies.Language.GetLanguageString());

		if (!(h.Contains("Referer") || h.Contains("Orig")))
		{
			h.Add("Referer", "https://act.hoyolab.com");
			h.Add("Orig", "https://act.hoyolab.com");
		}

		if (headers is null)
			return await Request<T>(message, cancellationToken).ConfigureAwait(false);

		foreach (var (k, v) in headers)
			h.Add(k, v);

		return await Request<T>(message, cancellationToken).ConfigureAwait(false);
	}

	private async Task<T> Request<T>(HttpRequestMessage requestMessage,
		CancellationToken? cancellationToken = null)
	{
		await m_limiter;
		var response = await s_client.SendAsync(requestMessage, cancellationToken ?? CancellationToken.None)
			.ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		var str = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
		
		return JsonConvert.DeserializeObject<T>(str)!;
	}
}