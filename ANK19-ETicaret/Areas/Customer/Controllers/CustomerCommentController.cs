using AutoMapper;
using BLL.DTO.CommentDtos;
using BLL.Managers.Abstract;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ANK19_ETicaret.Areas.Customer.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area("Customer")]
    [Authorize]
    public class CustomerCommentController : ControllerBase
    {
        private readonly ICommentManager _commentManager;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public CustomerCommentController(ICommentManager commentManager, IMapper mapper, UserManager<User> userManager)
        {
            _commentManager = commentManager;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        public IActionResult AddComment([FromBody] CommentRequest request, int productId)
        {
            var userId = _userManager.GetUserId(User);

            try
            {
                _commentManager.AddComment(userId, productId, request.Content, request.ProductRate);
                return Ok("Comment added successfully.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
