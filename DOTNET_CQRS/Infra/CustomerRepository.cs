using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOTNET_CQRS.Domain.Customer.Entity;
using MongoDB.Driver;

namespace DOTNET_CQRS.Infra
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<CustomerEntity> _customerDatabase; 
        public CustomerRepository(IMongoCustomerDatabase settings)
        {
          var client = new MongoClient(settings.ConnectionString);
          var database = client.GetDatabase(settings.DatabaseName);
          _customerDatabase = database.GetCollection<CustomerEntity>(
              settings.CQRSCollectionName
          );
        }
        public async Task Save(CustomerEntity customer)
        {
            await Task.Run(() => _customerDatabase.InsertOne(customer));
        }
        public async Task Delete(string id)
        {            
            await Task.Run(() => _customerDatabase.DeleteOne(c => c.Id == id));
        }
        public async Task<IEnumerable<CustomerEntity>> GetAll()
        {
            return await Task.FromResult(_customerDatabase.Find(Customer => true).ToList());
        }
        public async Task<CustomerEntity> GetById(string id)
        {
            var result = _customerDatabase.Find(c => c.Id == id).FirstOrDefault();
            return await Task.FromResult(result);
        }
        public async Task Update(string id, CustomerEntity customer)
        {           
            await Task.Run(() => _customerDatabase.ReplaceOne(c => c.Id == id, customer));
        }
    }
}