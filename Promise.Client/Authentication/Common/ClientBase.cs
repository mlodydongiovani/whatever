namespace Promise.Clients.Authentication.Common;

public abstract class ClientBase(HttpClient httpClient)
{
    protected readonly HttpClient _httpClient = httpClient;
}
