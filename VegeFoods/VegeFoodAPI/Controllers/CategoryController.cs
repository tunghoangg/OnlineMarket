using AutoMapper;
using BusinessObjects;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using VegeFoodAPI.DTO;

namespace VegeFoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories() => _repository.GetCategories();

        [HttpPost]
        public IActionResult PostCategory(CategoryDTO? c)
        {
            var category = _mapper.Map<Category>(c);
            _repository.CreateCategory(category);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryDTO c)
        {
            var pTmp = _repository.FindCategoryById(id);
            var category = _mapper.Map<Category>(c);
            category.CategoryId = pTmp.CategoryId;
            if (pTmp == null || category == null)
            {
                return NotFound();
            }
            _repository.UpdateCategory(category);
            return NoContent();
        }
    }
}
