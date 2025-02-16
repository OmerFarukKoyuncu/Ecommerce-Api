using BLL.DTO.Seller;
using DAL.Entities;
using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.OrderDtos
{
    public class AddOrderDto
    {
        public virtual User User { get; set; }
        public string UserId { get; set; }
        public OrderStatus Status { get; set; }
        public virtual SellerDTOModel Seller { get; set; }
        public int SellerId { get; set; }

        public virtual List<OrderProduct> OrderProducts { get; set; }
    }
}
