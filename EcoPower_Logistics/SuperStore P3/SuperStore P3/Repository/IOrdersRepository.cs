using Models;

namespace EcoPower_Logistics.Repository
{
    public interface IOrdersRepository : IGenericRepository<Order>
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int Id);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int Id);
        bool OrderExists(int id);

    }
}
