using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Seller
{
    public class SellerDTOModel : BaseDTOModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactInfo { get; set; }
        public string? ContactName { get; set; }
        public string? CompanyAdress { get; set; }
        public bool IsApproved { get; set; }
        public string? ProfilePictureUrl { get; set; }

        public string? LogoPictureUrl { get; set; }

        public string? UserId { get; set; }


    }
}
