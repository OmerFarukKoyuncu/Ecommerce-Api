using BLL.DTO.CommentDtos;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Abstract
{
    public interface ICommentManager : IManager<CommentManagerDto,Comment>
    {
        public void ReplyToComment(int commentId, string replyContent);

        public List<CommentManagerDto> GetSellersCommentsById(int sellerId);

        public void AddComment(string userId, int productId, string? content, int? productRate);

   
    }

 

}
