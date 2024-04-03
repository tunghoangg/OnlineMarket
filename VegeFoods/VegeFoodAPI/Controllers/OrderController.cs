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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repository;
        private readonly IOrderDetailRepository _detailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private static int _orderId;

        public OrderController(IOrderRepository repository, IMapper mapper, IOrderDetailRepository orderDetailRepository, IProductRepository productRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _detailRepository = orderDetailRepository;
            _productRepository = productRepository;
        }

        [HttpGet("{page}")]
        public async Task<ActionResult<OrderResponse>> GetOrders(int page)
        {
            var pageResults = 3f;
            var orders = _repository.GetOrders();

            var pageCount = (int)Math.Ceiling(orders.Count() / pageResults);

            var result = orders.Select(x => new OrderDTO()
            {
                OrderId = x.OrderId,
                CustomerId = x.CustomerId,
                OrderDate = x.OrderDate.ToString("dd/MM/yyyy"),
                Address = x.Address,
                Phone = x.Phone,
                //ShipDate = x.ShipDate.ToString("dd/MM/yyyy"),
                Status = x.Status,
                Customer = x.Customer
                
            });

            var ordersOnPage = result
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToList(); // Materialize the results into a List<Product>

            var response = new OrderResponse
            {
                Orders = ordersOnPage,
                CurrentPage = page,
                Pages = pageCount
            };

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditOrder(int id, OrderAdminDTO o)
        {
            var pTmp = _repository.FindOrderById(id);
            var order = _mapper.Map<Order>(o);
            order.OrderId = pTmp.OrderId;
            if (pTmp == null || order == null)
            {
                return NotFound();
            }
            _repository.UpdateOrder(order);
            return NoContent();
        }
        [HttpPost("Create")]
        public IActionResult CreateOrder(CreateOrderDTOForCustomer o)
        {
            var order = _mapper.Map<Order>(o);
            order.OrderDate = DateTime.Now;
            order.Status = "Waiting";
            _repository.AddOrder(order);
            _orderId = order.OrderId;
            return Ok(order);

        }

        [HttpPost("CreateDetail")]
        public IActionResult CreateOrderDetail( List<OrderDetailDTOCreate> orderD )
        {
            decimal totalPrice = 0;
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            OrderDetail temp;
            foreach (OrderDetailDTOCreate order in orderD ) 
            {
                temp = new OrderDetail
                {
                    OrderId = _orderId,
                    Price = _productRepository.GetProductById(order.productId).UnitPrice*order.quantity,
                    ProductId = order.productId,    
                    Quantity = order.quantity,
                };
               totalPrice += temp.Price;
                orderDetails.Add(temp);
            }
            _detailRepository.AddOrderDetails(orderDetails);
            return Ok((Int32)totalPrice);

        }

        [HttpGet("GetOrderById/{id:int}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _repository.FindOrderById(id);
            if (order == null)
            {
                // Return a 404 Not Found response if the order is not found
                return NotFound();
            }

            // Return a 200 OK response with the order if it's found
            return Ok(order);
        }

        [HttpGet("GetOrderByCustomerId/{id}/{page}")]
        public IActionResult GetOrderByCustomerId(int page, int id)
        {
            var pageResults = 5f;
            var orders = _repository.GetOrdersByAccountId(id);
            var pageCount = (int)Math.Ceiling(orders.Count() / pageResults);

            var result = orders.Select(x => new OrderDTO()
            {
                OrderId = x.OrderId,
                CustomerId = x.CustomerId,
                OrderDate = x.OrderDate.ToString("dd/MM/yyyy"),
                Address = x.Address,
                Phone = x.Phone,
                ShipDate = x.ShipDate,
                Status = x.Status,
                Customer = x.Customer

            });

            var productsOnPage = result
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToList(); // Materialize the results into a List<Product>

            var response = new OrderResponse
            {
                Orders = productsOnPage,
                CurrentPage = page,
                Pages = pageCount
            };

            return Ok(response);
        }
    }
}
