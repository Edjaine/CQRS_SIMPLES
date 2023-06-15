using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cqrssample.Domain.Customer.Entity
{
    public class CustomerEntity
    {
        public CustomerEntity(string firstName, string lastName, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        
    }
}