using BLL.DTO.ProductDtos;
using BLL.DTO.UserDtosForAdmin;
using DAL.Entities;
using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.CustomerRefundDtos
{
    public class AddRefundChangeDto
    {      
        public int ProductId { get; set; }       
        public string UserId { get; set; }     
        public RequestType Request { get; set; }  
    }
}
