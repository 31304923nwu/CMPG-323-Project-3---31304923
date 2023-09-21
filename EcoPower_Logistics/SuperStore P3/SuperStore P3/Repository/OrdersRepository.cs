using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class OrdersRepository : GenericRepository<Order>, IOrdersRepository
    {
        private readonly SuperStoreContext _superStoreContext = new SuperStoreContext();

        public OrdersRepository(SuperStoreContext superStoreContext) : base(superStoreContext) 
        {
        
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _superStoreContext.Orders.ToList();
        }

        // TO DO: Add ‘Get By Id’

        public Order GetOrderById(int Id)
        {
            return _superStoreContext.Orders.FirstOrDefault(o => o.OrderId == Id);
        }

        // TO DO: Add ‘Create’
        public void CreateOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException($"{nameof(order)} could not be created.");
            }

            _superStoreContext.Orders.Add(order);
            _superStoreContext.SaveChanges();
        }

        // TO DO: Add ‘Edit’
        public void UpdateOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException($"{nameof(order)} could not be updated.");
            }

            _superStoreContext.Orders.Update(order);
            _superStoreContext.SaveChanges();

        }
        // TO DO: Add ‘Delete’

        public void DeleteOrder(int Id)
        {
            var orderDelete = _superStoreContext.Orders.FirstOrDefault(x => x.CustomerId == Id);
            if (orderDelete != null)
            {
                _superStoreContext.Remove(orderDelete);
                _superStoreContext.SaveChanges();
            }
        }
        // TO DO: Add ‘Exists’
        public bool OrderExists(int id)
        {
            return (_superStoreContext.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}

