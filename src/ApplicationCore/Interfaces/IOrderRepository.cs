using System.Threading.Tasks;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces;

public interface IOrderRepository : IAsyncRepository<Order>
{
    Task<Order> GetByIdWithItemsAsync(int id);
}
