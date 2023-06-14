using System.Text;
using HoYoLabApi.interfaces;

namespace HoYoLabApi.Classes;

public class Request : IRequest
{
	public Request(string subDomain,
		string path,
		ICookies? cookies,
		IDictionary<string, string>? query = null,
		IDictionary<string, string>? headers = null)
	{
		SubDomain = subDomain;
		Path = path;
		Cookies = cookies;
		Query = query ?? new Dictionary<string, string>();
		Headers = headers;
	}

	public ICookies? Cookies { get; }

	public string SubDomain { get; set; }
	public string Path { get; }
	public IDictionary<string, string>? Headers { get; }
	public IDictionary<string, string> Query { get; }

	public virtual string GetQueryString()
	{
		if (Query.Count < 1)
			return string.Empty;

		var builder = new StringBuilder("?");

		foreach (var (k, v) in Query) builder.AppendFormat("{0}={1}&", k, v);

		builder.Remove(builder.Length - 1, 1);

		return builder.ToString();
	}

	public virtual string GetFullPath()
	{
		return $"{Path}{GetQueryString()}";
	}

	public virtual Uri GetFullUri()
	{
		var uri = new Uri(
			$"{(SubDomain.StartsWith("https://") ? SubDomain : $"https://{SubDomain}")}.hoyolab.com/{GetFullPath()}");
		return uri;
	}
}