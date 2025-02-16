using BLL.DTO.OrderProductDtos;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Abstract
{
    public interface IOrderProductManager : IManager<OrderProductDto,OrderProduct>
    {
        public void AddOrderProduct(int orderId,ShopCartDto shopCartDto);
    }
}
