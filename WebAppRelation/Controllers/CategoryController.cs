using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebAppRelation.Data;
using WebAppRelation.Models;

namespace WebAppRelation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _DbContext;

        public CategoryController(AppDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            var category = await _DbContext.Categories.ToListAsync();
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryRequest category)
        {
            var category1 = new Category()
            {
                Name = category.Name,
                Description = category.Description
            };

            var categoryAdd = await _DbContext.Categories.AddAsync(category1);

            await _DbContext.SaveChangesAsync();

            return Ok(categoryAdd);
        }

    }
}
