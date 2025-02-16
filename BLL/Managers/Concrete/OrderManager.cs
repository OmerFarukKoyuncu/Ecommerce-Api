using AutoMapper;
using BLL.DTO.CustomerOrderDto;
using BLL.DTO.OrderDtos;
using BLL.DTO.OrderProductDtos;
using BLL.Managers.Abstract;
using DAL.Entities;
using DAL.Enums;
using DAL.Repositories.Abstract;
using DAL.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Concrete
{
    public class OrderManager : Manager<OrderManagerDto, Order>, IOrderManager
    {
        private readonly IMapper _mapper;
        private readonly Repository<Order> _repository;
        private readonly Repository<Comment> _commentRepository;
        public OrderManager(IMapper mapper, Repository<Order> repository, Repository<Comment> commentRepository) : base(repository, mapper)
        {
            _mapper = mapper;

            _repository = repository;
            _commentRepository = commentRepository;
        }

        public int AddOrder(ShopCartDto shopCartDto)
        {
            var sellerId = 0;
            foreach (var item in shopCartDto.Items)
            {
                sellerId = item.Product.SellerId;
                break;
            }
            AddOrderDto addOrderDto = new AddOrderDto()
            {
                UserId = shopCartDto.UserId,
                Status = OrderStatus.Preparing,
                SellerId = sellerId
            };

            var order = _mapper.Map<Order>(addOrderDto);
            _repository.Add(order);
            return order.Id;
        }

        public override List<OrderManagerDto> GetAll()
        {
            var orders = _repository.GetAll();

            return _mapper.ProjectTo<OrderManagerDto>(orders).ToList();
        }

        public override OrderManagerDto GetById(int id)
        {
            var order = _repository.GetAll().Where(x => x.Id == id);

            return _mapper.ProjectTo<OrderManagerDto>(order).FirstOrDefault();
        }

        public List<CustomerOrderDto> GetCustomerOrders(string userId)
        {
            var orders = _repository.GetWhere(x => x.UserId == userId).ToList();

            var mappedOrders = _mapper.Map<List<CustomerOrderDto>>(orders);


            // Her bir order için içindeik product lara kullanıcının yorumu varsa getir ve dto ya ekle.
            foreach (var order in mappedOrders)
            {
                foreach (var product in order.OrderProducts)
                {
                    var userComment = _commentRepository.GetWhere(x => x.ProductId == product.ProductId && x.UserId == userId).FirstOrDefault();

                    product.CustomerEvaluation = userComment?.Content;
                    product.CustomerRating = userComment?.ProductRate;
                }
            }

            return mappedOrders;
        }

        
        public OrderSellerDto OrderSellerDto(int sellerId, int orderId)
        {
            var orderSeller = _repository.GetWhere(x => x.SellerId == sellerId && x.Id == orderId).FirstOrDefault();
            var orderSellerDto = _mapper.Map<OrderSellerDto>(orderSeller);

            return orderSellerDto;

        }

        public List<OrderSellerDto> OrderSellerDtos(int sellerId)
        {
            var orders = _repository.GetWhere(x => x.SellerId == sellerId).ToList();
            var orderSellerDtos = _mapper.Map<List<OrderSellerDto>>(orders);
            foreach (var order in orderSellerDtos)
            {
                var orderProducts = order.OrderProducts;

            }

            return orderSellerDtos;

        }

        public List<OrderUserDto> OrderUserDtos(string userId)
        {
            var dateThreshold = DateTime.Now.AddDays(-29);
            var orders = _repository.GetWhere(x => x.UserId == userId && (x.Status == OrderStatus.Preparing || x.Status == OrderStatus.Shipped || x.Status == OrderStatus.Delivered) && x.CreatedDate >= dateThreshold).ToList();

            var orderUserDtos = _mapper.Map<List<OrderUserDto>>(orders);

            foreach (var order in orderUserDtos)
            {
                var orderProducts = order.OrderProducts;

            }
            return orderUserDtos;
        }

        public void UpdateOrderStatus(int id, OrderStatus status)
        {
            var order = _repository.GetAll().Where(x => x.Id == id).FirstOrDefault();

            if (order == null)
                return;

            order.Status = status;
            _repository.Update(order);
        }


    }
}
