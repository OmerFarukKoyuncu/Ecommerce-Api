using BLL.DTO.Category;
using BLL.DTO.Seller;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ProductDTOModel : BaseDTOModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public string? PhotoUrl { get; set; }
        public int SellerId { get; set; }
        virtual public SellerDTOModel Seller { get; set; }
        public List<ProductCategory> productCategories { get; set; }


    }
}
