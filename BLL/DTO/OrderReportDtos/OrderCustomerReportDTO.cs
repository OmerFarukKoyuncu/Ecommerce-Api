using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.OrderReportDtos
{
    public class OrderCustomerReportDTO
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; } 
        public decimal? TotalPrice { get; set; }
        public decimal TotalQuantity { get; set; }
    }
}
