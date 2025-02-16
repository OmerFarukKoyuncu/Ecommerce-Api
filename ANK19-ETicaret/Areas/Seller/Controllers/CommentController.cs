using BLL.DTO.CommentDtos;
using BLL.Managers.Abstract;
using BLL.Managers.Concrete;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ANK19_ETicaret.Areas.Seller.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area("Seller")]
   [Authorize(Roles = "Seller")]
    public class CommentController : Controller
    {
        private readonly ICommentManager _commentManager;
        private readonly UserManager<User> _userManager;
        private readonly ISellerManager _sellerManager;

        public CommentController(ICommentManager commentManager, UserManager<User> userManager, ISellerManager sellerManager)
        {
            _commentManager = commentManager;
            _userManager = userManager;
            _sellerManager = sellerManager;
        }

 
        [HttpGet]
        public async Task<ActionResult> GetComments()
        {
            var userId = _userManager.GetUserId(User);

            var sellerId = _sellerManager.GetIdByUserId(userId);


            var comments = _commentManager.GetSellersCommentsById(sellerId);

            return Ok(comments);
        }

        [HttpPost("{commentId}/reply")]
        public ActionResult ReplyToComment(int commentId, [FromBody] ReplyRequest request)
        {
             _commentManager.ReplyToComment(commentId, request.ReplyText);
           
            return Ok();
        }

    }
}
