using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ProductPromotion:BaseEntity
    {
        public int ProductId { get; set; } // Foreign key to the Product entity
        public virtual Product Product { get; set; } // Navigation property for the related Product

        public int PromotionId { get; set; } // Foreign key to the Promotions entity
        public virtual Promotion Promotion { get; set; } // Navigation property for the related Promotion

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
