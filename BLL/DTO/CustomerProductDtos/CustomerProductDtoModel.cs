using BLL.DTO.Category;
using BLL.DTO.CommentDtos;
using BLL.DTO.ProductDtos;
using BLL.DTO.PromotionsDtos;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.CustomerProductDtos
{
    public class CustomerProductDtoModel 
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public string? PhotoUrl { get; set; }
        public int SellerId { get; set; }

        virtual public List<CustomerProductCategoryDtoModel> ProductCategories { get; set; }
        virtual public List<PromotionDtoModel> Promotions { get; set; }
        virtual public List<CommentManagerDto> Comments { get; set; }



    }
}
