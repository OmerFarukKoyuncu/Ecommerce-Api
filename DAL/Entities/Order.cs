using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Order:BaseEntity
    {
        public virtual User User { get; set; }
        public string UserId { get; set; }
        public OrderStatus Status { get; set; }
        public virtual Seller Seller { get; set; }
        public int SellerId { get; set; }

        //deniz
        public virtual List<OrderProduct> OrderProducts { get; set; }
    }
}
