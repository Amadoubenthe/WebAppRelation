using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebAppRelation.Data;
using WebAppRelation.Models;

namespace WebAppRelation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly AppDbContext _DbContext;

        public ProductController(AppDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            var category = await _DbContext.Products.ToListAsync();
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoleAsync([FromBody] ProductRequest product)
        {

            Product productAdd = new Product()
            {
                
                Name = product.Name,
                CategoryId = product.CategoryId,
                Price = product.Price,

            };

            await _DbContext.Products.AddAsync(productAdd);
            await _DbContext.SaveChangesAsync();

            return Ok(productAdd);
        }

    }
}
