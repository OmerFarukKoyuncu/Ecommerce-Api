using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Comment:BaseEntity
    {
        public string Content { get; set; } = string.Empty;

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public string? SellerReply { get; set; }

        public int ProductRate { get; set; }

    }
}
