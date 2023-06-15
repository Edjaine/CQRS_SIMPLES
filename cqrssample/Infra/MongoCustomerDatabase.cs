namespace cqrssample.Infra
{
    public class MongoCustomerDatabase : IMongoCustomerDatabase
    {
        public string CQRSCollectionName {get; set;}
        public string ConnectionString  {get; set;}
        public string DatabaseName   {get; set;}
    }
}