using System.Collections.Generic;
using System.Threading.Tasks;
using DOTNET_CQRS.Domain.Customer.Entity;

namespace DOTNET_CQRS.Infra
{
    public interface ICustomerRepository
    {
        Task Save(CustomerEntity customer) ;
        Task Update(string id, CustomerEntity customer);
        Task Delete(string id);
        Task<CustomerEntity> GetById(string id);
        Task<IEnumerable<CustomerEntity>> GetAll();
         
    }
}