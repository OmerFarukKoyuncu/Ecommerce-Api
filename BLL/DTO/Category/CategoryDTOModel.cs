using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Category
{
    public class CategoryDTOModel :BaseDTOModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
     //   public List<ProductCategoryDTOModel>? ProductCategories { get; set; }
    }
}
