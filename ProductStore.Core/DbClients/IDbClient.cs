using MongoDB.Driver;
using ProductStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Core.DbClients
{
    public interface IDbClient
    {
        IMongoCollection<Category> GetCategoriesCollection();
        IMongoCollection<Customer> GetCustomersCollection();
    }
}
