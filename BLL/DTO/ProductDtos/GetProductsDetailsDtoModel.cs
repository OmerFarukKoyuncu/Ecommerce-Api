using BLL.DTO.CommentDtos;
using BLL.DTO.ProductDtos;
using BLL.DTO.Seller;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class GetProductsDetailsDtoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public string? PhotoUrl { get; set; }
        public SellerDTOModel Seller { get; set; }
        public List<ProductCategoryDtoModel> Categories { get; set; }


        public List<CommentManagerDto> Comments { get; set; }
    }
}
