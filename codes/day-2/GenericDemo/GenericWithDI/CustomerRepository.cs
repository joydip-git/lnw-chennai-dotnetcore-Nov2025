
namespace GenericWithDI
{
    public class CustomerRepository : IRepository<Customer, int>
    {
        public CustomerRepository()
        {
            Console.WriteLine("customer repo created");
        }
        public Customer Add(Customer item)
        {
            return item;
        }

        public Customer Delete(int id)
        {
            return new Customer();
        }

        public Customer Get(int id)
        {
            return new Customer();
        }

        public List<Customer> GetAll()
        {
            return new List<Customer>();
        }

        public Customer Update(Customer item)
        {
            return new Customer();
        }
    }
}
