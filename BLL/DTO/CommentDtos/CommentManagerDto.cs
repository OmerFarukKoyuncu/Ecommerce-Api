using BLL.DTO.UserDtosForAdmin;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.CommentDtos
{
    public class CommentManagerDto :BaseDTOModel
    {
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int ProductId { get; set; }

        public string UserId { get; set; }

        public virtual GetUserDto User { get; set; }

        public string? SellerReply { get; set; }

        public int ProductRate { get; set; }
    }
}
