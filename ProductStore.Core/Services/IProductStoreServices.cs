using ProductStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Core.Services
{
    public interface IProductStoreServices
    {
        List<Category> GetCategoriesWithProducts();
        List<CategoryShort> GetCategories();
        List<Customer> GetCustomers();
        Category AddCategory(Category category);
        Product AddProduct(Product product);
        List<Product> GetProductsByCategory(string categoryId);
        Product GetProductById(string productId);
        Product UpdateProduct(Product product);
        void DeleteCategory(string categoryId);
        void DeleteProduct(string productId);
        Review AddReview(Review review);
        Order AddOrder(Order order);
        Customer AddCustomer(Customer customer);
    }
}
