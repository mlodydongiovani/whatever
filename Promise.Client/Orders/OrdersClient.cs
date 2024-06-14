using Newtonsoft.Json;
using Promise.Application.Orders;
using Promise.Clients.Authentication.Common;
using Promise.Orders.Models;

namespace Promise.Clients.Orders;

public class OrdersClient(HttpClient client) : ClientBase(client), IOrdersClient
{
    public async Task<List<Order>> GetOrdersAsync(int pageNumber, int pageSize)
    {
        var response = await _httpClient.GetAsync($"/api/orders?pageNumber={pageNumber}&pageSize={pageSize}");

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<List<Order>>(content)!;
    }
}
