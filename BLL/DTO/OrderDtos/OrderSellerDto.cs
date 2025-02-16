using BLL.DTO.OrderProductDtos;
using BLL.DTO.Seller;
using BLL.DTO.UserDtosForAdmin;
using DAL.Entities;
using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.OrderDtos
{
    public class OrderSellerDto : BaseDTOModel
    {
        public virtual GetUserDto User { get; set; }
        public string UserId { get; set; }
        public OrderStatus Status { get; set; }
        public virtual SellerDTOModel Seller { get; set; }
        public int SellerId { get; set; }   
        public virtual List<OrderProductDtoForSellerOrder> OrderProducts { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
