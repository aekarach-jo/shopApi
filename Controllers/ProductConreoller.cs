using StoreBK.Models;
using StoreBK.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using MongoDB.Driver;



namespace StoreBK.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAllProduct() => _productService.GetAllProduct();

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(string id)
        {
            var product = _productService.GetProductById(id);
            
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public Product CreateProduct([FromBody] Product product)
        {
            var data = _productService.GetAllProductForApi();
            int number = data.Count();
            product.ProductId = "P-0" + number.ToString();
            product.Status = "Open";
            _productService.CreateProduct(product);
            return product;
        }

        [HttpPut("{id}")]
        public IActionResult EditProduct([FromBody] Product product, string id)
        {
            var products = _productService.GetProductById(id);
            if (products == null)
            {
                return NotFound();
            }
            product.ProductId = id;
            _productService.EditProduct(id, product);
            return NoContent();
        }

        [HttpGet("{productId}")]
        public IActionResult DeleteProduct(string productId)
        {
            var products = _productService.GetProductById(productId);
            var statusChange = products.Status;
            if (products == null)
            {
                return NotFound();
            }
            if (statusChange == "Open")
            {
                statusChange = "Close";
            }
            products.Status = statusChange;
            _productService.DeleteProduct(productId, products);
            return NoContent();
        }

    }
}