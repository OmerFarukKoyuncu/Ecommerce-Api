using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.OrderReportDtos
{
    public class OrderProductReportDTO
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
      


        public string SellerName { get; set; }


        public OrderStatus Status { get; set; }

        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public decimal Quantity { get; set; }

    }
}
