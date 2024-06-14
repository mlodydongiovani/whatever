using Promise.Clients.Authentication.Common;

namespace Promise.Clients.Authentication;

public class AuthenticationTokenProvider : IAuthenticationTokenProvider
{
    public async Task<AccessToken> GetToken()
    {
        return await Task.FromResult(new AccessToken { Token = "made-up-token" });
    }
}
