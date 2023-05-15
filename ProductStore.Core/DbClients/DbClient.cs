using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductStore.Core.Models;

namespace ProductStore.Core.DbClients
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Category> _categories;
        private readonly IMongoCollection<Customer> _customer;
        public DbClient(IOptions<ProductStoreDbConfig> productStoreDbConfig)
        {
            var client = new MongoClient(productStoreDbConfig.Value.Connection_String);
            var database = client.GetDatabase(productStoreDbConfig.Value.Database_Name);
            _categories = database.GetCollection<Category>(productStoreDbConfig.Value.Categories_Collection_Name);
            _customer = database.GetCollection<Customer>(productStoreDbConfig.Value.Customers_Collection_Name);
        }

        public IMongoCollection<Category> GetCategoriesCollection()
        {
            return _categories;
        }

        public IMongoCollection<Customer> GetCustomersCollection()
        {
            return _customer;
        }
    }
}
