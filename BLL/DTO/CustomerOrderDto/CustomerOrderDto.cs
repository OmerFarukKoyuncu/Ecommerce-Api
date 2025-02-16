using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Enums;

namespace BLL.DTO.CustomerOrderDto
{
    public class CustomerOrderDto: BaseDTOModel
    {
      
        public OrderStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal TotalPrice { get; set; }

        //deniz
        public virtual List<CustomerOrderProductDto> OrderProducts { get; set; }
    }
}
