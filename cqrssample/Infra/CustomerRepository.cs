using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using cqrssample.Domain.Customer.Entity;
using MongoDB.Driver;

namespace cqrssample.Infra
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
            await _customerDatabase.InsertOneAsync(customer);
        }
        public async Task Delete(string id)
        {
            await _customerDatabase.DeleteOneAsync(c => c.Id == id);
        }
        public async Task<IEnumerable<CustomerEntity>> GetAll(int page, int size, Expression<Func<CustomerEntity, bool>> filter)
        {
            return await _customerDatabase.Find(filter)
                .Skip((page - 1) * size)
                .Limit(size)
                .ToListAsync();
        }
        public async Task<CustomerEntity> GetById(string id)
        {
            return await _customerDatabase
                         .FindAsync(c => c.Id == id)
                         .Result
                         .FirstOrDefaultAsync();

        }
        public async Task Update(string id, CustomerEntity customer)
        {
            await _customerDatabase.ReplaceOneAsync(c => c.Id == id, customer);
        }
    }
}