using BLL.DTO.Category;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.ProductDtos
{
    public class ProductCategoryDtoModel
    {
        public int ProductId { get; set; }
        virtual public ProductDTOModel Product { get; set; }
        public int CategoryId { get; set; }
        virtual public CategoryDTOModel Category { get; set; }
    }
}
