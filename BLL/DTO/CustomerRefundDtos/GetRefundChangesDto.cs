using BLL.DTO.ProductDtos;
using DAL.Entities;
using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.CustomerRefundDtos
{
    public class GetRefundChangesDto : BaseDTOModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual ProductDtoForRefund Product { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public RequestType Request { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
