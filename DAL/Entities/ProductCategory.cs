using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ProductCategory: BaseEntity
    {
        
        public int ProductId { get; set; }
        virtual public Product Product { get; set; }
        public int CategoryId { get; set; }
        virtual public Category Category { get; set; }
    }
}
