using Data;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class OrderDetailsRepository : GenericRepository<OrderDetail>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(SuperStoreContext superStoreContext) : base(superStoreContext)
        {
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails()
        { 
            return _superStoreContext.OrderDetails.ToList();
        }

        // TO DO: Add ‘Get By Id’

        public OrderDetail GetOrderDetailsById(int Id)
        {
            return _superStoreContext.OrderDetails.FirstOrDefault(predicate: x => x.OrderDetailsId == Id);
        }

        // TO DO: Add ‘Create’
        public void CreateOrderDetail(OrderDetail orderDetails)
        {
            if (orderDetails == null)
            {
                throw new ArgumentNullException($"{nameof(orderDetails)} could not be created.");
            }

            _superStoreContext.OrderDetails.Add(orderDetails);
            _superStoreContext.SaveChanges();
        }

        // TO DO: Add ‘Edit’
        public void UpdateOrderDetails(OrderDetail orderDetails)
        {
            if (orderDetails == null)
            {
                throw new ArgumentNullException($"{nameof(orderDetails)} could not be updated.");
            }

            _superStoreContext.OrderDetails.Update(orderDetails);
            _superStoreContext.SaveChanges();

        }
        // TO DO: Add ‘Delete’

        public void DeleteOrderDetails(int Id)
        {
            var OrderDetailsDelete = _superStoreContext.Customers.FirstOrDefault(x => x.CustomerId == Id);
            if (OrderDetailsDelete != null)
            {
                _superStoreContext.Remove(OrderDetailsDelete);
                _superStoreContext.SaveChanges();
            }
        }

        public bool OrderDetailsExists(int id)
        {
            return (_superStoreContext.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }

  
    }
}
