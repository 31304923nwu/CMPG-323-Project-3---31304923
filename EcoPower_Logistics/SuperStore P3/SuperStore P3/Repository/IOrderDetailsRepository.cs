using Models;

namespace EcoPower_Logistics.Repository
{
    public interface IOrderDetailsRepository : IGenericRepository<OrderDetail>
    {
        IEnumerable<OrderDetail> GetAllOrderDetails();
        OrderDetail GetOrderDetailsById(int Id);
        void UpdateOrderDetails(OrderDetail orderDetails);
        void DeleteOrderDetails(int Id);
        bool OrderDetailsExists(int id);
        void CreateOrderDetail(OrderDetail orderDetail);
    }
}
