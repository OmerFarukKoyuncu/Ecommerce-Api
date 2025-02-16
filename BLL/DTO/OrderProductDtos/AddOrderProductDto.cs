using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.OrderProductDtos
{
    public class AddOrderProductDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
    }
}
