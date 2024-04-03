using AutoMapper;
using BusinessObjects;
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
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailRepository _repository;
        private readonly IMapper _mapper;

        public OrderDetailsController(IOrderDetailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("GetOrderDetails/{id}")]
        public IActionResult GetOrderDetails(int id)
        {
            var orderDetail = _repository.ViewOrderDetails(id);

            var response = orderDetail.Select(x => new OrderDetailDTO()
            {
                Id = x.Id,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Price = x.Price,
                Product = x.Product 
            });
            return Ok(response);
        }
    }
}
