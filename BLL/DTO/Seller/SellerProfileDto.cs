using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Seller
{
    public class SellerProfileDto
    {
        public string Firstname { get; set; }//firma adı
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsApproved { get; set; }
        public string? ProfilePictureUrl { get; set; } //logo
        
    }
}
