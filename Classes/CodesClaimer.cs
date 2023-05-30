using HoYoLabApi.interfaces;
using HoYoLabApi.Models;

namespace HoYoLabApi.Classes;

public sealed class CodesClaimer
{
	private readonly IHoYoLabClient m_client;
	private readonly AccountSearcher m_accountSearcher;

	public CodesClaimer(IHoYoLabClient client, AccountSearcher accountSearcher)
	{
		m_client = client;
		m_accountSearcher = accountSearcher;
	}
	
	public async Task<ICodeClaimResult> CodeClaimAsync(ICookies cookies, string code, ClaimRequest request)
	{
		return await m_client.CodeClaimAsync(new CodeClaimRequest(
			request.SubDomain, cookies, request.Region!, code, request.GameAcc!
		)).ConfigureAwait(false);
	}

	public async IAsyncEnumerable<ICodeClaimResult> CodesClaimAsync(
		ICookies cookies,
		string[] codes,
		ClaimRequest request,
		CancellationToken? cancellationToken = null)
	{
		cancellationToken ??= CancellationToken.None;
		foreach (var code in codes)
		{
			if (cancellationToken.Value.IsCancellationRequested)
				yield break;
			
			yield return await CodeClaimAsync(cookies, code, request).ConfigureAwait(false);
		}
	}
}