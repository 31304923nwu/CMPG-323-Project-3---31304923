using Models;

namespace EcoPower_Logistics.Repository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int? Id);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int? Id);
        bool CustomerExists(int id);
    }
}
