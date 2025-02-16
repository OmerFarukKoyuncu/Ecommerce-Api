using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.OrderDtos
{
    public class MonthlyOrderReportDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int TotalOrders { get; set; }      

    }
}
