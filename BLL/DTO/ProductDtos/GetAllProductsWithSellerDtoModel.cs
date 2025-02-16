using BLL.DTO.Seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class GetAllProductsWithSellerDtoModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public string? PhotoUrl { get; set; }
        public int SellerId { get; set; }
        virtual public SellerDTOModel Seller { get; set; }
    }
}
