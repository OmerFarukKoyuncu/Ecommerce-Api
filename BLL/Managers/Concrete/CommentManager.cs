using AutoMapper;
using BLL.DTO.CommentDtos;
using BLL.Managers.Abstract;
using DAL.Entities;
using DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Concrete
{
    public class CommentManager : Manager<CommentManagerDto, Comment>, ICommentManager
    {
        private readonly IMapper _mapper;
        private readonly Repository<Comment> _repository;
        private readonly Repository<Order> _orderRepository;

        public CommentManager(Repository<Comment> repository, IMapper mapper, Repository<Order> orderRepository) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public override List<CommentManagerDto> GetAll()
        {
            var comments = _repository.GetAll();
            return _mapper.ProjectTo<CommentManagerDto>(comments).ToList();

        }

        public List<CommentManagerDto> GetSellersCommentsById(int sellerId)
        {
            var comment = _repository.GetAll()
                .Where(x => x.Product.SellerId == sellerId);

            return _mapper.ProjectTo<CommentManagerDto>(comment).ToList();
        }

        public void ReplyToComment(int commentId, string replyContent)
        {
            var comment = _repository.GetById(commentId);
            if (comment == null)
                return;

            comment.SellerReply = replyContent;

            _repository.Update(comment);
        }

        public void AddComment(string userId, int productId, string? content, int? productRate)
        {
            // Check if the user has purchased the product
            var hasPurchased = _orderRepository.GetAll()
                .Any(order => order.UserId == userId && order.OrderProducts.Any(op => op.ProductId == productId));

            if (!hasPurchased)
            {
                throw new InvalidOperationException("User can only comment on products they have purchased.");
            }

            var existingComment = _repository.GetWhere(x => x.ProductId == productId && x.UserId == userId).FirstOrDefault();
            if(existingComment == null)
            {
                if(productRate is null && content is null)
                    return ;

                // Create a new comment
                var newComment = new Comment
                {
                    UserId = userId,
                    ProductId = productId,
                    Content = content,
                    ProductRate = productRate.Value,
                };

                // Add the new comment to the repository
                _repository.Add(newComment);
            }
            else
            {
                if (productRate is null && content is null)
                {
                    _repository.Remove(existingComment);
                }
                else
                {
                    existingComment.ProductRate = productRate.Value;
                    existingComment.Content = content;
                    _repository.Update(existingComment);
                }
              
                  
            }
         

        }

      
    }
}
