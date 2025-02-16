using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Category:BaseEntity
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
       virtual public List<ProductCategory> ProductCategories { get; set; }
    }
}
