using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.PromotionsDtos
{
    public class ProductPromotionDtoModel:BaseDTOModel
    {
        public int ProductId { get; set; } // Foreign key to the Product entity
        public ProductDTOModel Product { get; set; } // Navigation property for the related Product

        public int PromotionId { get; set; } // Foreign key to the Promotions entity
        //public PromotionDtoModel Promotion { get; set; } // Navigation property for the related Promotion

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
