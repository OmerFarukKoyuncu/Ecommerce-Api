using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.ProductDtos
{
    public class ProductDtoForCustomerWithoutCategory
    {  
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal? Price { get; set; }
            public int? Stock { get; set; }
            public string? PhotoUrl { get; set; }        
        
    }
}
