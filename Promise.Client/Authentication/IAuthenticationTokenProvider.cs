using Promise.Clients.Authentication.Common;

namespace Promise.Clients.Authentication
{
    public interface IAuthenticationTokenProvider
    {
        Task<AccessToken> GetToken();
    }
}
