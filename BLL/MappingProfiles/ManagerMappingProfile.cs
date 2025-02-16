using AutoMapper;
using BLL.DTO;
using BLL.DTO.Category;
using BLL.DTO.Seller;
 
using BLL.DTO.UserDtos;
using BLL.DTO.UserDtosForAdmin;
using BLL.DTO.OrderDtos;
using BLL.DTO.OrderProductDtos;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO.ProductDtos;
using BLL.DTO.ContentDtos;
using BLL.DTO.CommentDtos;
using BLL.DTO.PromotionsDtos;
using BLL.DTO.CustomerDto;
using BLL.DTO.CustomerRefundDtos;
using BLL.DTO.CustomerProductDtos;
using BLL.DTO.CustomerOrderDto;
using BLL.DTO.CustomerRegisterDTO;

namespace BLL.MappingProfiles
{
    public class ManagerMappingProfile : Profile
    {
        public ManagerMappingProfile()
        {
            
            CreateMap<Product, ProductDTOModel>().ReverseMap();

            CreateMap<Category, CategoryDTOModel>().ReverseMap();
            CreateMap<Category, AddCategoryDTOModel>().ReverseMap();
            CreateMap<CategoryDTOModel, AddCategoryDTOModel>().ReverseMap();

            CreateMap<Seller, SellerDTOModel>().ReverseMap();
            CreateMap<SellerDTOModel, SellerProductListDTOModel> ().ReverseMap();
            

            CreateMap<ProductCategory, ProductCategoryDtoModel>().ReverseMap();
            CreateMap<Product, AddProductDtoModel>().ReverseMap();
            CreateMap<ProductDTOModel, AddProductDtoModel>().ReverseMap();
            CreateMap<Product, UpdateProductDtoModel>().ReverseMap();
            CreateMap<ProductDTOModel, GetAllProductsDtoModel>().ReverseMap();
            CreateMap<Product, GetAllProductsDtoModel>().ReverseMap();
            CreateMap<ProductDTOModel, GetAllProductsWithSellerDtoModel>().ReverseMap();
            CreateMap<Product, GetAllProductWithCategoriesDtoModel>().ReverseMap();
            CreateMap<Product, ProductDtoForRefund>().ReverseMap();
            CreateMap<Product, CustomerProductDtoModel>().ReverseMap();
            CreateMap<ProductCategory, CustomerProductCategoryDtoModel>().ReverseMap();
            



            CreateMap<Product, CustomerProductDtoModel>().ReverseMap();
            CreateMap<Product, ProductDtoForCustomerWithoutCategory>().ReverseMap();
            CreateMap<ProductCategory, CustomerProductCategoryDtoModel>().ReverseMap();
            




            CreateMap<User, AddUserDto>().ReverseMap();
            CreateMap<User, GetAllUsersDto>().ReverseMap();
            CreateMap<User, GetUserDto>().ReverseMap();
            CreateMap<User, CustomerDtoModel>().ReverseMap();


            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<User, GetUsersWithRolesDto>().ReverseMap();
            CreateMap<User, SellerProfileDto>().ReverseMap();

         //   CreateMap<BaseDTOModel, BaseEntity>().ReverseMap();



            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, AddOrderDto>().ReverseMap();
            CreateMap<Order, CustomerOrderDto>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate)).ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src =>
        src.OrderProducts.Sum(op => op.Product.Price * (decimal)op.Quantity))).ReverseMap();
            CreateMap<OrderProduct, OrderProductDto>().ReverseMap();
            CreateMap<OrderProduct, AddOrderProductDto>().ReverseMap();
            CreateMap<OrderProduct, CustomerOrderProductDto>()
    .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.Id))
    .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price)).ReverseMap();
    

            CreateMap<UserDto,User>().ReverseMap();

            CreateMap<Order, OrderManagerDto>().ReverseMap();
            CreateMap<Content, ContentDto>().ReverseMap();
            CreateMap<ShopCart, ShopCartDto>()
                .ForMember(x=>x.Items,src=>src.MapFrom(p=>p.Items.Where(i=>i.IsDeleted == false))).ReverseMap();
            CreateMap<ShopCartItem, ShopCartItemDto>().ReverseMap();


            //deneme omer
            CreateMap<Order, OrderSellerDto>()
         .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
         .ForMember(dest => dest.Seller, opt => opt.MapFrom(src => src.Seller))
         .ForMember(dest => dest.OrderProducts, opt => opt.MapFrom(src => src.OrderProducts));

            CreateMap<Order, OrderUserDto>()
         .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))      
         .ForMember(dest => dest.OrderProducts, opt => opt.MapFrom(src => src.OrderProducts));

            CreateMap<OrderProduct, OrderProductDto>();  // OrderProduct -> OrderProductDto
            CreateMap<User, GetUserDto>();  // User -> GetUserDto
            CreateMap<Seller, SellerDTOModel>();

            CreateMap<OrderProduct, OrderProductDtoForSellerOrder>().ReverseMap();
            CreateMap<Product, ProductDtoForSeller>().ReverseMap();

            CreateMap<Comment, CommentManagerDto>()
         .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));



            //promotion için
            CreateMap<Promotion, PromotionDtoModel>().ReverseMap();
            CreateMap<AddPromotionDtoModel, PromotionDtoModel>().ReverseMap();
            CreateMap<ProductPromotion, ProductPromotionDtoModel>().ReverseMap();
            CreateMap<AddProductPromotionDtoModel, ProductPromotionDtoModel>().ReverseMap();

            //refund maps
            CreateMap<RefundChange, AddRefundChangeDto>().ReverseMap();
            CreateMap<RefundChange, GetRefundChangesDto>().ReverseMap();


            CreateMap<CustomerRegisterDTO, User> ().ReverseMap ();
            CreateMap<SellerRegisterDTO, SellerDTOModel> ().ReverseMap ();
            CreateMap<SellerRegisterDTO, Seller> ().ReverseMap ();

        }
    }
}
