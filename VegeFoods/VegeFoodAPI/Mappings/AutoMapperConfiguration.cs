using AutoMapper;
using BusinessObjects;
using DataAccess;
using VegeFoodAPI.DTO;

namespace VegeFoodAPI.Mappings
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<LoginDTO, User>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<OrderDTO, Order>();
            CreateMap<Order, OrderDTO>();
            CreateMap<Comment, CommentDTO>();
            CreateMap<CommentDTO, Comment>();
            CreateMap<Order, CreateOrderDTOForCustomer>();
            CreateMap<CreateOrderDTOForCustomer, Order>();
            CreateMap<OrderAdminDTO, Order>();
            CreateMap<Order, OrderAdminDTO>();
        }
    }
}
