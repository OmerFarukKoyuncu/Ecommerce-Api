using DAL.Entities;
using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.OrderReportDtos
{
    //deniz
    public class OrderReportDto 
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public decimal TotalQuantity { get; set; }
        public string SellerName { get; set; }

       
        public OrderStatus Status { get; set; }
    }
}
