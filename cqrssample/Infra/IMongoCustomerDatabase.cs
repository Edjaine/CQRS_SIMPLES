namespace cqrssample.Infra
{
    public interface IMongoCustomerDatabase
    {
         string CQRSCollectionName {get; set;}
         string ConnectionString {get; set;}
         string DatabaseName {get; set;}
    }
}