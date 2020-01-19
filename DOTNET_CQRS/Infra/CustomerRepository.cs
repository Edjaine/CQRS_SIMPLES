using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOTNET_CQRS.Domain.Customer.Entity;

namespace DOTNET_CQRS.Infra
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<CustomerEntity> Customers {get;}

        public CustomerRepository()
        {
            Customers = new List<CustomerEntity>();
            Customers.Add(new CustomerEntity
                (1,
                "Edjaine",
                "Oliveira",
                "c83edsoliveira@hotmail.com",
                "11985544957"));

        }

        public async Task Save(CustomerEntity customer)
        {
            await Task.Run(() => Customers.Add(customer));
        }
        public async Task Delete(int id)
        {
            var index = Customers.FindIndex(m=> m.Id == id);
            await Task.Run(() => Customers.RemoveAt(id));
        }

        public async Task<IEnumerable<CustomerEntity>> GetAll()
        {
            return await Task.FromResult(Customers.ToList());
        }

        public async Task<CustomerEntity> GetById(int id)
        {
            var result = Customers.Where(p=> p.Id == id).FirstOrDefault();
            return await Task.FromResult(result);
        }


        public async Task Update(int id, CustomerEntity customer)
        {
            var index = Customers.FindIndex(m => m.Id == id);
            if(index >= 0)
                await Task.Run(() => Customers.RemoveAt(index));
        }
    }
}