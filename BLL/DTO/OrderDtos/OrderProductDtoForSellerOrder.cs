using BLL.DTO.ProductDtos;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.OrderDtos
{
    public class OrderProductDtoForSellerOrder
    {     
        public int OrderId { get; set; }
        public virtual ProductDtoForCustomerWithoutCategory Product { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
    }
}
