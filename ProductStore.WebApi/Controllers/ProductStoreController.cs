using Microsoft.AspNetCore.Mvc;
using ProductStore.Core.Models;
using ProductStore.Core.Services;
using System.Net;

namespace ProductStore.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductStoreController : ControllerBase
{
    private readonly IProductStoreServices _productStoreServices;
    public ProductStoreController(IProductStoreServices productStoreServices)
    {
        _productStoreServices = productStoreServices;
    }

    [HttpGet("getCategories")]
    public IActionResult GetCategories()
    {
        try
        {
            return Ok(_productStoreServices.GetCategories());
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

    }

    [HttpGet("getCustomers")]
    public IActionResult GetCustomers()
    {
        try
        {
            return Ok(_productStoreServices.GetCustomers());
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

    }

    [HttpGet("getCategoriesWithProducts")]
    public IActionResult GetCategoriesWithProducts()
    {
        try
        {
            return Ok(_productStoreServices.GetCategoriesWithProducts());
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

    }

    [HttpGet("getProductsByCategory")]
    public IActionResult GetProductsByCategory(string categoruId)
    {
        try
        {
            return Ok(_productStoreServices.GetProductsByCategory(categoruId));
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

    }

    [HttpPost("addCategory")]
    public IActionResult AddCategory(Category category)
    {
        try
        {
            return Ok(_productStoreServices.AddCategory(category));
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

    }

    [HttpPost("addProduct")]
    public IActionResult AddProduct(Product product)
    {
        try
        {
            return Ok(_productStoreServices.AddProduct(product));
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

    }

    [HttpPost("addReview")]
    public IActionResult AddReview(Review review)
    {
        try
        {
            return Ok(_productStoreServices.AddReview(review));
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

    }

    [HttpPost("addOrder")]
    public IActionResult AddOrder(Order order)
    {
        try
        {
            return Ok(_productStoreServices.AddOrder(order));
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

    }

    [HttpPost("addCustomer")]
    public IActionResult AddCustomer(Customer customer)
    {
        try
        {
            return Ok(_productStoreServices.AddCustomer(customer));
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

    }

    [HttpDelete("deleteCategory")]
    public IActionResult DeleteCategory(string categoryId)
    {
        try
        {
            _productStoreServices.DeleteCategory(categoryId);
            return Ok();
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpDelete("deleteProduct")]
    public IActionResult DeleteProduct(string productId)
    {
        try
        {
            _productStoreServices.DeleteProduct(productId);
            return Ok();
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}