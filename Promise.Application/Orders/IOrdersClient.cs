using Promise.Orders.Models;

namespace Promise.Application.Orders;

public interface IOrdersClient
{
    Task<List<Order>> GetOrdersAsync(int pageNumber, int pageSize);
}
