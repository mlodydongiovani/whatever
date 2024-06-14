namespace Promise.Orders.Models;

public record Order(Guid OrderId, IEnumerable<OrderLine> OrderLines);

