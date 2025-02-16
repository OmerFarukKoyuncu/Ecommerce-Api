using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.OrderProductDtos
{
    public class OrderProductDto:BaseDTOModel
    {
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
        public virtual DAL.Entities.Product Product { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
    }
}
