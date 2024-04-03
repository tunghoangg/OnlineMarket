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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{page}")]
        public async Task<ActionResult<UserResponse>> GetUsers(int page)
        {
            var pageResults = 3f;
            var users = _repository.GetUsers();
            var pageCount = (int)Math.Ceiling(users.Count() / pageResults);

            var result = users.Select(x => new UserDTO()
            {
                AccountId = x.AccountId,
                UserName = x.UserName,
                FullName = x.FullName,
                Email = x.Email,
                Address = x.Address,
                Phone = x.Phone,
                role = x.role
            });

            var productsOnPage = result
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToList(); // Materialize the results into a List<User>

            var response = new UserResponse
            {
                Users = productsOnPage,
                CurrentPage = page,
                Pages = pageCount
            };

            return Ok(response);
        }

        [HttpGet("SearchUserById/{id}")]
        public IActionResult SearchProductById(int id)
        {
            var user = _repository.FindUserById(id);
            if (user == null)
            {
                // Return a 404 Not Found response if the user is not found
                return NotFound();
            }

            // Return a 200 OK response with the user if it's found
            return Ok(user);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> EditProfile(int id, User p)
        {
            var pTmp = _repository.FindUserById(id);
            var user = _mapper.Map<User>(p);
            user.AccountId = pTmp.AccountId;
            if (pTmp == null || user == null)
            {
                return NotFound();
            }
            _repository.UpdateUser(user);
            return NoContent();
        }

        [HttpGet("SearchUserByName/{name}/{page}")]
        public IActionResult SearchProductByName(string name, int page)
        {

            var pageResults = 100f;
            var users = _repository.SearchUserByName(name);
            var pageCount = (int)Math.Ceiling(users.Count() / pageResults);

            var result = users.Select(x => new UserDTO()
            {
                AccountId = x.AccountId,
                UserName = x.UserName,
                FullName = x.FullName,
                Email = x.Email,
                Address = x.Address,
                Phone = x.Phone,
                role = x.role
            });

            var productsOnPage = result
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToList(); // Materialize the results into a List<User>

            var response = new UserResponse
            {
                Users = productsOnPage,
                CurrentPage = page,
                Pages = pageCount
            };

            return Ok(response);
        }
        [HttpGet("SearchUserByUserName/{userName}")]
        public IActionResult SearchProductByName(string userName)
        {
            User user = new User();
            user = _repository.SearchUserByUserName(userName);
            return Ok(user);
        }
    }
}
