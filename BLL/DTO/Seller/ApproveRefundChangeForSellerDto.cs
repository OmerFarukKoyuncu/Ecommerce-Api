using Azure.Core;
using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Seller
{
    public class ApproveRefundChangeForSellerDto
    {
        public RequestType Request  { get; set; }
        public string userId { get; set; }
        public int productId { get; set; }
    }
}
