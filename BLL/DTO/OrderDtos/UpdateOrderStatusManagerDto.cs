using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.OrderDtos
{
    public class UpdateOrderStatusManagerDto
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
    }
}
