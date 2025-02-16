using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class RefundChange : BaseEntity
    {     
        public int ProductId { get; set; } 
        public virtual Product Product { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public RequestType Request { get; set; }
       
    }
}
