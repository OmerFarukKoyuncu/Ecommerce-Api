using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.PromotionsDtos
{
    public class AddProductPromotionDtoModel
    {
        public int ProductId { get; set; } // Foreign key to the Product entity
        
        public int PromotionId { get; set; } // Foreign key to the Promotions entity
       

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
