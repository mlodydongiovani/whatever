using System.Net.Http.Headers;

namespace Promise.Clients.Authentication.Common;

public class BearerTokenHandler(IAuthenticationTokenProvider authenticationTokenProvider) : DelegatingHandler
{
    private readonly IAuthenticationTokenProvider _authenticationTokenProvider = authenticationTokenProvider;

    // intercepts http methods with bearer token injection
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _authenticationTokenProvider.GetToken();

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);

        return await base.SendAsync(request, cancellationToken);
    }
}
