using AutoMapper;
using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;
using VegeFoodAPI.DTO;

namespace VegeFoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{page}")]
        public async Task<ActionResult<ProductResponse>> GetProducts(int page)
        {
            var pageResults = 10f;
            var products = _repository.GetProducts();
            var pageCount = (int)Math.Ceiling(products.Count() / pageResults);

            var productsOnPage = products
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToList(); // Materialize the results into a List<Product>

            var response = new ProductResponse
            {
                Products = productsOnPage,
                CurrentPage = page,
                Pages = pageCount
            };

            return Ok(response);
        }

        [HttpGet("GetProductById/{id:int}")]
        public IActionResult SearchProductById(int id)
        {
            var product = _repository.GetProductById(id);
            if (product == null)
            {
                // Return a 404 Not Found response if the product is not found
                return NotFound();
            }

            // Return a 200 OK response with the product if it's found
            return Ok(product);
        }

        [HttpGet("SearchProductByName/{name}/{page}")]
        public IActionResult SearchProductByName(int page, string name)
        {
            var pageResults = 100f;
            var products = _repository.SearchProductByName(name);
            var pageCount = (int)Math.Ceiling(products.Count() / pageResults);
            var productsOnPage = products
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToList(); // Materialize the results into a List<Product>

            var response = new ProductResponse
            {
                Products = productsOnPage,
                CurrentPage = page,
                Pages = pageCount
            };

            return Ok(response);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDTO p)
        {
            var pTmp = _repository.GetProductById(id);
            var product = _mapper.Map<Product>(p);
            product.ProductId = pTmp.ProductId;
            if (pTmp == null || product == null)
            {
                return NotFound();
            }
            _repository.UpdateProduct(product);
            return NoContent();
        }

        // POST: api/Products
        [HttpPost("Create")]
        public IActionResult PostProduct(ProductDTO? p)
        {
            var product = _mapper.Map<Product>(p);
            _repository.SaveProduct(product);
            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var p = _repository.GetProductById(id);
            if (p == null)
            {
                return NotFound();
            }
            _repository.DeleteProduct(p);
            return NoContent();
        }

        
    }
}
