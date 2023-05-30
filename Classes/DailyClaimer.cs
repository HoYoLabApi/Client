using HoYoLabApi.interfaces;
using HoYoLabApi.Static;

namespace HoYoLabApi.Classes;

public sealed class DailyClaimer
{
	private readonly IHoYoLabClient Client;
	private readonly ClaimRequest m_dailyClaim;

	public DailyClaimer(IHoYoLabClient client, ClaimRequest dailyClaim)
	{
		Client = client;
		m_dailyClaim = dailyClaim;
	}
	
	public async Task<IDailyClaimResult> DailyClaimAsync(ICookies cookies)
	{
		return await Client.DailyClaimAsync(new Request(
			m_dailyClaim.SubDomain,
			m_dailyClaim.Path,
			cookies,
			new Dictionary<string, string>
			{
				{ "act_id", m_dailyClaim.ActId! },
				{ "lang", cookies.Language.GetLanguageString() }
			}
		)).ConfigureAwait(false);
	}
	
	public async IAsyncEnumerable<IDailyClaimResult> DailiesClaimAsync(ICookies[] cookies, CancellationToken? cancellationToken = null)
	{
		cancellationToken ??= CancellationToken.None;
		foreach (var cookie in cookies)
		{
			if (cancellationToken.Value.IsCancellationRequested)
				yield break;
			
			yield return await DailyClaimAsync(cookie).ConfigureAwait(false);
		}
	}
}