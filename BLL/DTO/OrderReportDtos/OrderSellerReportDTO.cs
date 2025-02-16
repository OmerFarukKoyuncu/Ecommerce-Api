using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.OrderReportDtos
{
    public class OrderSellerReportDTO
    {
        public int SellerId { get; set; }
        public string SellerName { get; set; }



        public decimal? TotalPrice { get; set; }
        public decimal TotalQuantity { get; set; }

    }
}
