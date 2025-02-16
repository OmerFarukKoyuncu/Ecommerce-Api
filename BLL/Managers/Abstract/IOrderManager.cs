using BLL.DTO.CustomerOrderDto;
using BLL.DTO.OrderDtos;
using BLL.DTO.OrderProductDtos;
using DAL.Entities;
using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Abstract
{
    public interface IOrderManager: IManager<OrderManagerDto,Order>
    {
        public void UpdateOrderStatus(int id, OrderStatus status);
        public List<OrderSellerDto> OrderSellerDtos(int sellerId);
        public List<OrderUserDto> OrderUserDtos(string userId);
        public OrderSellerDto OrderSellerDto(int sellerId,int orderId);
        public int AddOrder(ShopCartDto shopCartDto);           
        public List<CustomerOrderDto> GetCustomerOrders(string userId);

       



    }
}
