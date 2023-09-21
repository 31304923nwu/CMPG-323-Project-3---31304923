using Data;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    { 
        protected readonly SuperStoreContext _superStoreContext = new SuperStoreContext();
        
        public CustomerRepository(SuperStoreContext superStoreContext) : base(superStoreContext)
        { 
            
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _superStoreContext.Customers.ToList();
        }

        // TO DO: Add ‘Get By Id’

        public Customer GetCustomerById(int? Id) 
        {
            return _superStoreContext.Customers.FirstOrDefault(predicate: x => x.CustomerId == Id);
        }

        public void CreateCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException($"{nameof(customer)} could not be created.");
            }

            _superStoreContext.Customers.Add(customer);
            _superStoreContext.SaveChanges();
        }

        public void UpdateCustomer(Customer customer) 
        {
            if(customer == null)
            {
                throw new ArgumentNullException($"{nameof(customer)} could not be updated.");
            }

            _superStoreContext.Customers.Update(customer);
            _superStoreContext.SaveChanges();

        }

        public void DeleteCustomer(int? Id) 
        {
            var customerDelete = _superStoreContext.Customers.FirstOrDefault(x => x.CustomerId == Id);
            if (customerDelete != null)
            {
                _superStoreContext.Remove(customerDelete);
                _superStoreContext.SaveChanges();
            }
        }

        public bool CustomerExists(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException($"{nameof(id)} could not be updated.");
            }
            else
            {
                return _superStoreContext.Customers.Any(c => c.CustomerId == id);
            }
        }
    }
}
