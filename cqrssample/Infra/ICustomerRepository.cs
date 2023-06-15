using System.Collections.Generic;
using System.Threading.Tasks;
using cqrssample.Domain.Customer.Entity;

namespace cqrssample.Infra
{
    public interface ICustomerRepository
    {
        Task Save(CustomerEntity customer) ;
        Task Update(string id, CustomerEntity customer);
        Task Delete(string id);
        Task<CustomerEntity> GetById(string id);
        Task<IEnumerable<CustomerEntity>> GetAll(int page, int size);
         
    }
}