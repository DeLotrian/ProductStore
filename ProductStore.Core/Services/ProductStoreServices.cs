using MongoDB.Driver;
using ProductStore.Core.DbClients;
using ProductStore.Core.Models;

namespace ProductStore.Core.Services;

public class ProductStoreServices : IProductStoreServices
{
    private readonly IMongoCollection<Category> _categories;
    private readonly IMongoCollection<Customer> _customers;
    public ProductStoreServices(IDbClient dbClient)
    {
        _categories = dbClient.GetCategoriesCollection();
        _customers = dbClient.GetCustomersCollection();
    }

    public Category AddCategory(Category category)
    {
        _categories.InsertOne(category);
        return category;
    }

    public Product AddProduct(Product product)
    {
        var filter = Builders<Category>.Filter.Eq(category => category.Id, product.CategoryId);
        var selectedCategory = _categories.Find<Category>(filter).First();
        selectedCategory.Products.Add(product);
        _categories.ReplaceOne(filter, selectedCategory);
        return product;
    }

    public Review AddReview(Review review)
    {
        Product targetProduct = GetProductById(review.ProductId);
        targetProduct.Reviews.Add(review);
        UpdateProduct(targetProduct);
        return review;
    }

    public void DeleteCategory(string categoryId)
    {
        _categories.DeleteOne(category => category.Id == categoryId);
        return;
    }

    public void DeleteProduct(string productId)
    {
        var filter = Builders<Category>.Filter.ElemMatch(c => c.Products, p => p.Id == productId);
        var update = Builders<Category>.Update.PullFilter(c => c.Products, p => p.Id == productId);
        var updatedCategory = _categories.FindOneAndUpdate(filter, update);
        return;
    }

    public List<CategoryShort> GetCategories()
    {
        List<CategoryShort> result = new List<CategoryShort>();
        foreach (var category in _categories.Find(cat => true).ToList())
        {
            result.Add(new CategoryShort { Id = category.Id, Name = category.Name });
        }
        return result;
    }

    public List<Category> GetCategoriesWithProducts()
    {
        return _categories.Find(category => true).ToList();
    }

    public List<Product> GetProductsByCategory(string categoryId)
    {
        return _categories.Find(category => category.Id == categoryId).First().Products;
    }

    public Product GetProductById(string productId)
    {
        var filter = Builders<Category>.Filter.ElemMatch(c => c.Products, p => p.Id == productId);
        return _categories.Find(filter).First().Products.Find(product => product.Id == productId);
    }

    public Product UpdateProduct(Product product)
    {
        var filter = Builders<Category>.Filter.ElemMatch(c => c.Products, p => p.Id == product.Id);
        var category = _categories.Find(filter).First();

        if (category == null) return null;

        var productToUpdate = category.Products.FirstOrDefault(p => p.Id == product.Id);

        if (productToUpdate == null) return null;

        productToUpdate.Name = product.Name;
        productToUpdate.CategoryId = product.CategoryId;
        productToUpdate.Price = product.Price;
        productToUpdate.Quantity = product.Quantity;
        if (product.Reviews.Count > 0)
            productToUpdate.Reviews = product.Reviews;

        _categories.ReplaceOne(filter, category);
        return productToUpdate;
    }

    public Order AddOrder(Order order)
    {
        Customer targetCustomer = _customers.Find(customer => customer.Id == order.CustomerId).First();
        targetCustomer.Orders.Add(order);
        foreach(var product in order.Products)
        {
            Product reducedQuantity = GetProductById(product.Id);
            reducedQuantity.Quantity = reducedQuantity.Quantity - product.Quantity;
            UpdateProduct(reducedQuantity);
        }
        _customers.ReplaceOne(customer => customer.Id == targetCustomer.Id, targetCustomer);
        return order;
    }

    public Customer AddCustomer(Customer customer)
    {
        _customers.InsertOne(customer);
        return customer;
    }

    public List<Customer> GetCustomers()
    {
        return _customers.Find(customer => true).ToList();
    }
}