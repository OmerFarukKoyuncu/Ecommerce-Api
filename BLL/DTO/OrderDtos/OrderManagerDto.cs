using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.OrderDtos
{
    public class OrderManagerDto:BaseDTOModel
    {
        public UserDto User { get; set; }
        public string UserId { get; set; }
        public OrderStatus Status { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
