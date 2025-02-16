using BLL.DTO.Category;
 
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ProductCategoryDTOModel : BaseDTOModel
    {
        public int ProductId { get; set; }
        virtual public ProductDTOModel Product { get; set; }
        public int CategoryId { get; set; }
     }
}
