using HoYoLabApi.interfaces;
using HoYoLabApi.Models;

namespace HoYoLabApi.Classes;

public sealed class CodesClaimer
{
	private readonly AccountSearcher m_accountSearcher;
	private readonly IHoYoLabClient m_client;

	public CodesClaimer(IHoYoLabClient client, AccountSearcher accountSearcher)
	{
		m_client = client;
		m_accountSearcher = accountSearcher;
	}

	public async Task<(ICodeClaimResult, Headers)> CodeClaimAsync(ICookies cookies, string code, ClaimRequest request)
	{
		return await m_client.CodeClaimAsync(new CodeClaimRequest(
			request.SubDomain, cookies, request.Region!, code, request.GameAcc!
		)).ConfigureAwait(false);
	}
}