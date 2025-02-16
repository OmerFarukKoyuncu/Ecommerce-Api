 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Seller
{
    public class SellerProductListDTOModel : BaseDTOModel
    {
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public bool IsApproved { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public List<ProductDTOModel>? Products { get; set; }
    }
}
