using AutoMapper;
using BLL.DTO.OrderProductDtos;
using BLL.Managers.Abstract;
using DAL.Entities;
using DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Concrete
{
    public class OrderProductManager : Manager<OrderProductDto, OrderProduct>, IOrderProductManager
    {
        private readonly Repository<OrderProduct> _repository;
        private readonly IMapper _mapper;

        public OrderProductManager(Repository<OrderProduct> repository, IMapper mapper) : base(repository, mapper)
        {
           _repository = repository;
            _mapper = mapper;
            
        }

        public void AddOrderProduct(int orderId, ShopCartDto shopCartDto)
        {
            foreach (var item in shopCartDto.Items)
            {
                AddOrderProductDto addOrderProductDto = new AddOrderProductDto()
                {
                    OrderId = orderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                };
                var orderProduct = _mapper.Map<OrderProduct>(addOrderProductDto);

                _repository.Add(orderProduct);
                
            }
        }
    }
}
