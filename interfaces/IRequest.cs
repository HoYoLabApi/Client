namespace HoYoLabApi.interfaces;

public interface IRequest
{
	public ICookies? Cookies { get; }
	
	public string SubDomain { get; set; }
	public string Path { get; }
	
	IDictionary<string, string>? Headers { get; }
	IDictionary<string, string> Query { get; }

	public string GetQueryString();
	public string GetFullPath();
	public Uri GetFullUri();
}